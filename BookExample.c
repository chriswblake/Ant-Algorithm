#define MAX_CITIES         30
#define MAX_DISTANCE       100
#define MAX_TOUR   (MAX_CITIES * MAX_DISTANCE)
#define MAX_ANTS 30

typedef struct {
	int x;
	int y;
} cityType;
typedef struct {
	int curCity;
	int nextCity;
	unsigned char tabu[MAX_CITIES];
	int pathIndex;
	unsigned char path[MAX_CITIES];
	double tourLength;
} antType;

#define ALPHA      1.0
#define BETA       5.0     /* Favor Distance over Pheromone */
#define RHO        0.5     /* Intensity / Evaporation */
#define QVAL       100

#define MAX_TOURS          20
#define MAX_TIME   (MAX_TOURS * MAX_CITIES)
#define INIT_PHEROMONE    (1.0 / MAX_CITIES)

cityType cities[MAX_CITIES];
antType ants[MAX_ANTS];
double   distance[MAX_CITIES][MAX_CITIES]; // [from][to]
double   pheromone[MAX_CITIES][MAX_CITIES]; // [from][to]
double  best = (double)MAX_TOUR;
int     bestIndex;


void init(void)
{
	int from, to, ant;

	/* Create the cities and their locations */
	for (from = 0; from < MAX_CITIES; from++) {

		/* Randomly place cities around the grid */
		cities[from].x = getRand(MAX_DISTANCE);
		cities[from].y = getRand(MAX_DISTANCE);

		for (to = 0; to < MAX_CITIES; to++) {
			distance[from][to] = 0.0;
			pheromone[from][to] = INIT_PHEROMONE;
		}

	}

	/* Compute the distances for each of the cities on the map */
	for (from = 0; from < MAX_CITIES; from++) {

		for (to = 0; to < MAX_CITIES; to++) {

			if ((to != from) && (distance[from][to] == 0.0)) {
				int xd = abs(cities[from].x - cities[to].x);
				int yd = abs(cities[from].y - cities[to].y);

				distance[from][to] = sqrt((xd * xd) + (yd * yd));
				distance[to][from] = distance[from][to];
			}

		}

	}

	/* Initialize the ants */
	to = 0;
	for (ant = 0; ant < MAX_ANTS; ant++) {

		/* Distribute the ants to each of the cities uniformly */
		if (to == MAX_CITIES) to = 0;
		ants[ant].curCity = to++;


		for (from = 0; from < MAX_CITIES; from++) {
			ants[ant].tabu[from] = 0;
			ants[ant].path[from] = -1;
		}

		ants[ant].pathIndex = 1;
		ants[ant].path[0] = ants[ant].curCity;
		ants[ant].nextCity = -1;
		ants[ant].tourLength = 0.0;

		/* Load the ant's current city into tabu<au: Should this be
		tabu? Yes> */
		ants[ant].tabu[ants[ant].curCity] = 1;

	}
}
int main()
{
	int curTime = 0;

	srand(time(NULL));

	init();

	while (curTime++ < MAX_TIME) {

		if (simulateAnts() == 0) {
			updateTrails();

			if (curTime != MAX_TIME)
				restartAnts();

			printf("Time is %d (%g)\n", curTime, best);

		}

	}

	printf("best tour %g\n", best);
	printf("\n\n");

	emitDataFile(bestIndex);

	return 0;
}

int simulateAnts(void)
{
	int k;
	int moving = 0;

	for (k = 0; k < MAX_ANTS; k++)
	{
		/* Ensure this ant still has cities to visit */
		if (ants[k].pathIndex < MAX_CITIES) {
			ants[k].nextCity = selectNextCity(k);
			ants[k].tabu[ants[k].nextCity] = 1;
			ants[k].path[ants[k].pathIndex++] = ants[k].nextCity;
			ants[k].tourLength += distance[ants[k].curCity][ants[k].nextCity];

			/* Handle the final case (last city to first) */
			if (ants[k].pathIndex == MAX_CITIES)
			{
				ants[k].tourLength += distance[ants[k].path[MAX_CITIES - 1]][ants[k].path[0]];
			}

			ants[k].curCity = ants[k].nextCity;
			moving++;
		}
	}

	return moving;
}
void updateTrails(void)
{
	int from, to, i, ant;

	/* Pheromone Evaporation */
	for (from = 0; from < MAX_CITIES; from++)
	{
		for (to = 0; to < MAX_CITIES; to++)
		{
			if (from != to)
			{
				pheromone[from][to] *= (1.0 - RHO);
				if (pheromone[from][to] < 0.0)
					pheromone[from][to] = INIT_PHEROMONE;
			}
		}
	}

	/* Add new pheromone to the trails */

	/* Look at the tours of each ant */
	for (ant = 0; ant < MAX_ANTS; ant++) {

		/* Update each leg of the tour given the tour length */
		for (i = 0; i < MAX_CITIES; i++) {

			if (i < MAX_CITIES - 1)
			{
				from = ants[ant].path[i];
				to = ants[ant].path[i + 1];
			}
			else
			{
				from = ants[ant].path[i];
				to = ants[ant].path[0];
			}

			pheromone[from][to] += (QVAL / ants[ant].tourLength);
			pheromone[to][from] = pheromone[from][to];

		}

	}

	for (from = 0; from < MAX_CITIES; from++) {
		for (to = 0; to < MAX_CITIES; to++) {
			pheromone[from][to] *= RHO;
		}
	}

}
void restartAnts(void)
{
	int ant, i, to = 0;

	for (ant = 0; ant < MAX_ANTS; ant++) {

		if (ants[ant].tourLength < best) {
			best = ants[ant].tourLength;
			bestIndex = ant;
		}

		ants[ant].nextCity = -1;
		ants[ant].tourLength = 0.0;

		for (i = 0; i < MAX_CITIES; i++) {
			ants[ant].tabu[i] = 0;
			ants[ant].path[i] = -1;
		}

		if (to == MAX_CITIES) to = 0;
		ants[ant].curCity = to++;
		ants[ant].pathIndex = 1;
		ants[ant].path[0] = ants[ant].curCity;

		ants[ant].tabu[ants[ant].curCity] = 1;

	}

}

double antProduct(int from, int to)
{
	return ((pow(pheromone[from][to], ALPHA) *
		pow((1.0 / distance[from][to]), BETA)));
}
int selectNextCity(int ant)
{
	int from, to;
	double denom = 0.0;

	/* Choose the next city to visit */
	from = ants[ant].curCity;

	/* Compute denom */
	for (to = 0; to < MAX_CITIES; to++) {
		if (ants[ant].tabu[to] == 0) {
			denom += antProduct(from, to);
		}
	}

	assert(denom != 0.0);
	do {

		double p;

		to++;
		if (to >= MAX_CITIES) to = 0;

		if (ants[ant].tabu[to] == 0) {

			p = antProduct(from, to) / denom;

			if (getSRand() < p) break;

		}

	} while (1);

	return to;
}

