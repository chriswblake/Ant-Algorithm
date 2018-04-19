using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ch4_Ants
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        List<City> cities;
        List<Ant> ants;

        //Typical values for alpha and beta
        /*
         alpha      beta
         0.5        5.0
         1.0        1.0
         1.0        2.0
         1.0        5.0
             */

        public Form1()
        {
            InitializeComponent();

            //Get from interface
            int countCities = Convert.ToInt32(tbCityCount.Text);
            double alpha = Convert.ToDouble(tbAlpha.Text);
            double beta = Convert.ToDouble(tbBeta.Text);
            double rho = Convert.ToDouble(tbRho.Text);

            //Send to creator
            cities = createCities(countCities, 100, alpha, beta, rho);
            ants = createAnts(cities, rho);

            //Display on chart
            graphCities(chartResults, cities);
            graphRoads(chartResults, cities);
            graphAnts(chartResults, ants);
        }

        //Methods - Setup
        public List<City> createCities(int numCities, int maxXY, double alpha, double beta, double rho)
        {
            //Generate random cities
            List<City> cities = new List<City>();
            for (int id = 0; id < numCities; id++)
            {
                int X = rand.Next(maxXY);
                int Y = rand.Next(maxXY);
                cities.Add(new City(id, X, Y));
            }

            //Generate roads
            List<Road> roads = new List<Road>();
            int roadID = 0;
            double initPheromone = 1.0 / numCities;
            foreach (City from in cities)
            {
                foreach (City to in cities)
                {
                    //Skip self
                    if (to == from)
                        continue;

                    //Determine pathID (smaller ID is always first)
                    string pathID = "";
                    if (from.ID < to.ID)
                    { pathID = from.ID + "," + to.ID; }
                    else
                    { pathID = to.ID + "," + from.ID; }

                    //If pathID already existing, skip
                    if (roads.FindIndex(r => r.pathID == pathID) >= 0)
                        continue;

                    //Create a road
                    roads.Add(new Road(roadID, from, to, initPheromone, alpha, beta, rho));
                    roadID++;
                }
            }

            //Add roads to cities
            foreach (City c in cities)
            {
                c.Roads = roads.FindAll(r => r.A == c || r.B == c).ToList();
            }

            //Return list
            return cities;
        }
        public List<Ant> createAnts(List<City> cities, double rho)
        {
            //List for holding the ants
            List<Ant> ants = new List<Ant>();

            //Add one ant to each city, give it the same id as the city (not required, but convienient)
            foreach (City c in cities)
            {
                ants.Add(new Ant(c.ID, c, rho));
            }

            //Return the list
            return ants;
        }

        //Methods - Processing
        public bool moveAnts(List<Ant> ants)
        {
            //Get list of ants that need to move
            List<Ant> antsToMove = ants.FindAll(a => a.IsFinished == false);

            //If there are ants that have not finished, move them
            if (antsToMove.Count > 0)
            {
                //Move ants
                foreach (Ant a in antsToMove)
                { a.goToNextCity(); }

                //Return not finished
                return false;
            }
            else
            {
                //Deposit pheromones and reset
                foreach (Ant a in ants)
                {
                    //Deposit pheromones for travel
                    a.depositPheromone();

                    //Reset
                    a.reset();
                }

                //Evaporate pheromones
                evaporatePheromone(cities);

                //Return finished
                return true;
            }

        }
        public void evaporatePheromone(List<City> cities)
        {
            //Collect Roads
            HashSet<Road> roads = new HashSet<Road>();
            foreach (City c in cities)
            {
                //Add all roads to the list
                foreach (Road r in c.Roads)
                    roads.Add(r);
            }

            //Cycle through each road
            foreach (Road r in roads)
            {
                //Evaporate 
                r.evaporatePheromone();
            }

        }

        //Methods - Display
        public void graphCities(Chart theChart, List<City> cities)
        {
            //Remove old data
            theChart.Series["cities"].Points.Clear();

            //Show cities and IDs
            foreach (City c in cities)
            {
                DataPoint dp = new DataPoint(c.location.X, c.location.Y) { Label = c.ID.ToString() };
                theChart.Series["cities"].Points.Add(dp);
            }
        }
        public void graphRoads(Chart theChart, List<City> cities)
        {
            //Remove old roads
            theChart.Series["roads"].Points.Clear();
            theChart.Series.Where(r => r.Name.Contains("road")).ToList();
            

            //Collect Roads
            HashSet<Road> roads = new HashSet<Road>();
            double maxPheromone = 0;
            foreach (City c in cities)
            {
                //Add all roads to the list
                foreach (Road r in c.Roads)
                {
                    //Add to list
                    roads.Add(r);

                    //Get max amount of pherome (for scaling later)
                    if (r.Pheromone > maxPheromone)
                        maxPheromone = r.Pheromone;
                }
            }

            //Show Roads
            foreach (Road r in roads)
            {
                //Don't display if really low
                if (r.Pheromone / maxPheromone < 0.05) continue;

                //Determine road color. The more pheromone, the dark the line
                int alpha = Convert.ToInt32((r.Pheromone / maxPheromone) * 255);
                Color roadColor = Color.FromArgb(alpha, 0, 0, 0);

                //Create Points
                DataPoint dpA = new DataPoint(r.A.location.X, r.A.location.Y) { Color = roadColor };
                DataPoint dpMiddle = new DataPoint((int)(r.A.location.X + r.B.location.X) / 2.0, (int)(r.A.location.Y + r.B.location.Y) / 2.0)
                {
                    Color = roadColor,
                    Label = r.ID + ":" + r.Pheromone.ToString("F3")
                };
                DataPoint dpB = new DataPoint(r.B.location.X, r.B.location.Y) { Color = roadColor };

                //Add to chart
                theChart.Series["roads"].Points.Add(new DataPoint() { IsEmpty = true });
                theChart.Series["roads"].Points.Add(dpA);
                theChart.Series["roads"].Points.Add(dpMiddle);
                theChart.Series["roads"].Points.Add(dpB);
                theChart.Series["roads"].Points.Add(new DataPoint() { IsEmpty = true });

            }
        }
        public void graphAnts(Chart theChart, List<Ant> ants)
        {
            //Remove old data
            theChart.Series["ants"].Points.Clear();

            //Show cities and IDs
            foreach (Ant a in ants)
            {
                DataPoint dp = new DataPoint(a.CurrentCity.location.X, a.CurrentCity.location.Y) { Label = a.ID.ToString() };
                theChart.Series["ants"].Points.Add(dp);
            }
        }

        //Classes
        public class Ant
        {
            //Phereomone Deposit
            double depositAmount = 100.0; //Amount of pheromone to share across the path
            double rho = 0.5;

            //Fields       
            public readonly int ID;
            //public bool isFinished = false;
            private City currentCity;
            private List<Road> VisitedRoads = new List<Road>();

            //Constructor
            public Ant(int ID, City currentCity, double rho)
            {
                //Set ID
                this.ID = ID;

                //Set Rho
                this.rho = rho;

                //Store list of cities
                VisitedCities = new List<City>();

                //Store current location
                this.currentCity = currentCity;
                VisitedCities.Add(currentCity);
            }

            //Methods         
            public void goToNextCity()
            {
                //Check finished state
                if (IsFinished) return;

                #region Get possible roads
                //Get current cities roads
                List<Road> roads = currentCity.Roads.ToList();

                //Remove visited cities
                foreach (City vCity in VisitedCities.FindAll(c => c != currentCity))
                {
                    roads.RemoveAll(r => r.A == vCity || r.B == vCity);
                }
                #endregion

                //Check if no roads (all cities visited)
                if (roads.Count == 0)
                {
                    //isFinished = true;
                    return;
                }

                #region Determine next road / city
                //Get sum of road probabilities
                double sumMovementProbability = 0;
                foreach (Road r in roads)
                { sumMovementProbability += r.MovementProbablity; }

                //Get relative probably of taking a road
                Road theRoad = null;
                while (theRoad == null)
                    foreach (Road r in roads)
                    {
                        //Compute relative probability
                        double probability = r.MovementProbablity / sumMovementProbability;
                        double randVal = rand.NextDouble();

                        //Compare to random number
                        if (randVal < probability)
                        {
                            theRoad = r;
                            break;
                        }
                    }
                #endregion

                //Go to next city
                if (theRoad.A == currentCity)
                    currentCity = theRoad.B;
                else
                    currentCity = theRoad.A;

                //Add to visited List
                VisitedCities.Add(currentCity);
                VisitedRoads.Add(theRoad);
            }
            public void depositPheromone()
            {
                //Calculate distance traveled
                double distance = 0;
                foreach (Road r in VisitedRoads)
                    distance += r.distance;

                //Calculate amount to put per road
                double pheromonePerRoad = depositAmount / distance;

                //Add to each road
                foreach (Road r in VisitedRoads)
                {
                    r.Pheromone += (pheromonePerRoad * rho);
                }
            }
            public void reset()
            {
                //Go back to original city
                currentCity = VisitedCities[0];

                //Clear visited
                VisitedCities.Clear();
                VisitedCities.Add(currentCity);
                VisitedRoads.Clear();
            }

            //Properties
            public bool IsFinished
            {
                get { return (VisitedRoads.Count == currentCity.Roads.Count); }
            }
            public City CurrentCity
            {
                get
                {
                    return currentCity;
                }
            }
            public List<City> VisitedCities = new List<City>();
            public double Distance
            {
                get
                {
                    //Calculate distance traveled
                    double distance = 0;
                    foreach (Road r in VisitedRoads)
                        distance += r.distance;

                    return distance;
                }
            }

            //Helper
            public override string ToString()
            {
                return "ID:" + ID + "  City: " + currentCity.ID + "  Vis:" + VisitedCities.Count + "Dist: " + Distance.ToString("F2");
            }
        }
        public class City
        {
            //Fields
            public readonly int ID;
            public readonly Point location;

            //Constructor
            public City(int ID, int X, int Y)
            {
                this.ID = ID;
                location.X = X;
                location.Y = Y;
            }

            //Properties
            public List<Road> Roads;
            public override string ToString()
            {
                return "ID:" + ID + "  Pos: " + location.X + ", " + location.Y;
            }
        }
        public class Road : IComparable<Road>
        {
            //Calculation constants
            double alpha;
            double beta;
            double rho;

            //Fields
            public readonly int ID;
            public readonly string pathID;
            public readonly City A;
            public readonly City B;
            public readonly double distance;
            private double pheromone;

            //Constructor
            public Road(int ID, City A, City B, double pheromone, double alpha, double beta, double rho)
            {
                //Store ID
                this.ID = ID;
                this.alpha = alpha;
                this.beta = beta;
                this.rho = rho;

                //Determine pathID (smaller ID is always first)
                if (A.ID < B.ID)
                {
                    this.pathID = A.ID + "," + B.ID;
                }
                else
                {
                    this.pathID = B.ID + "," + A.ID;
                }

                //Store Cities
                this.A = A;
                this.B = B;

                //Store pheromone
                this.pheromone = pheromone;

                //Calculate distance between cities
                double dx = Math.Abs(A.location.X - B.location.X);
                double dy = Math.Abs(A.location.Y - B.location.Y);
                this.distance = Math.Sqrt(dx * dx + dy * dy);
            }

            //Methods
            public void evaporatePheromone()
            {
                pheromone *= (1.0 - rho);
            }

            //Properties
            public double MovementProbablity
            {
                get
                {
                    return Math.Pow(pheromone, alpha) * Math.Pow((1.0 / distance), beta);
                }
            }
            public double Pheromone
            {
                get { return pheromone; }
                set { pheromone = value; }
            }
            public override string ToString()
            {
                return "ID:" + ID + "  Path: " + A.ID + "," + B.ID + "  Ph: " + Pheromone.ToString("F3");
            }

            //Interface suppor
            int IComparable<Road>.CompareTo(Road other)
            {
                if (this.Pheromone > other.Pheromone) return 1;
                else if (this.Pheromone < other.Pheromone) return -1;
                else return 0;
            }
        }

        //Controls
        private void btnCreateCities_Click(object sender, EventArgs e)
        {
            try
            {
                //Get from interface
                int countCities = Convert.ToInt32(tbCityCount.Text);
                double alpha = Convert.ToDouble(tbAlpha.Text);
                double beta = Convert.ToDouble(tbBeta.Text);
                double rho = Convert.ToDouble(tbRho.Text);

                //Send to creator
                cities = createCities(countCities, 100, alpha, beta, rho);
                ants = createAnts(cities, rho);

                //Display on chart
                graphCities(chartResults, cities);
                graphRoads(chartResults, cities);
                graphAnts(chartResults, ants);
            }
            catch { }
        }
        private void btnMoveAnts_Click(object sender, EventArgs e)
        {
            //Move
            moveAnts(ants);

            //Update chart
            graphRoads(chartResults, cities);
            graphAnts(chartResults, ants);
        }
        private void chboxShowAnts_CheckedChanged(object sender, EventArgs e)
        {
            //Change sender to checkbox
            CheckBox cb = (CheckBox)sender;

            //Toggle visibility of Ants series
            chartResults.Series["ants"].Enabled = cb.Checked;
        }
        private void btnMoveOneCycle_Click(object sender, EventArgs e)
        {
            //Move ants until one cycle completes
            bool isFinished = false;
            int cycles = 10;
            while (!isFinished && cycles >= 0)
            {
                isFinished = moveAnts(ants);
                cycles--;
            }

            //Update chart
            graphRoads(chartResults, cities);
            graphAnts(chartResults, ants);
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            //Move ants until ants take same path
            int moves = 100*ants.Count; //cycles
            while (moves > 0) //prevent inf loop
            {
                //Move the ants
                moveAnts(ants);

                //Prevent inf loop
                moves--;
            }

            //Update chart
            graphRoads(chartResults, cities);
            graphAnts(chartResults, ants);
        }
        private void chartResults_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chartResults.SaveImage(ms, ChartImageFormat.Bmp);
                Bitmap bm = new Bitmap(ms);
                Clipboard.SetImage(bm);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            //Reset roads
            double initPheromone = 1.0 / cities.Count;
            foreach (City c in cities)
            {
                foreach (Road r in c.Roads)
                {
                    r.Pheromone = initPheromone;
                }
            }

            //Reset Ants
            foreach(Ant a in ants)
            {
                a.reset();
            }

            //Graph
            graphRoads(chartResults, cities);
            graphAnts(chartResults, ants);
        }
    }
}