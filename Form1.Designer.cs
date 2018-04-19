namespace Ch4_Ants
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblCityCount;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(25D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(38D, 38D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(50D, 50D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(25D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(50D, 50D);
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(25D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(25D, 25D);
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panControls = new System.Windows.Forms.Panel();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnMoveOneCycle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.tbBeta = new System.Windows.Forms.TextBox();
            this.tbRho = new System.Windows.Forms.TextBox();
            this.btnMoveAnts = new System.Windows.Forms.Button();
            this.chboxShowAnts = new System.Windows.Forms.CheckBox();
            this.tbCityCount = new System.Windows.Forms.TextBox();
            this.btnCreateCities = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            lblCityCount = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            this.tableLayout.SuspendLayout();
            this.panControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCityCount
            // 
            lblCityCount.Location = new System.Drawing.Point(29, 22);
            lblCityCount.Name = "lblCityCount";
            lblCityCount.Size = new System.Drawing.Size(100, 23);
            lblCityCount.TabIndex = 2;
            lblCityCount.Text = "Cities:";
            lblCityCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Right;
            label1.Location = new System.Drawing.Point(14, 62);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 37);
            label1.TabIndex = 8;
            label1.Text = "Beta:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Right;
            label2.Location = new System.Drawing.Point(3, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 37);
            label2.TabIndex = 10;
            label2.Text = "Alpha:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Right;
            label3.Location = new System.Drawing.Point(19, 99);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 37);
            label3.TabIndex = 11;
            label3.Text = "Rho:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(label4, 2);
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(179, 25);
            label4.TabIndex = 10;
            label4.Text = "Parameters";
            // 
            // chartResults
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.Maximum = 100D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea1);
            this.chartResults.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartResults.Legends.Add(legend1);
            this.chartResults.Location = new System.Drawing.Point(3, 3);
            this.chartResults.Name = "chartResults";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Black;
            series1.CustomProperties = "LabelStyle=Center";
            series1.Legend = "Legend1";
            series1.Name = "roads";
            dataPoint1.Color = System.Drawing.Color.Black;
            dataPoint2.Color = System.Drawing.Color.Black;
            dataPoint2.Label = "0: 0.200";
            dataPoint3.Color = System.Drawing.Color.Black;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.ShadowColor = System.Drawing.Color.Empty;
            series1.SmartLabelStyle.Enabled = false;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.DimGray;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.LabelForeColor = System.Drawing.Color.DimGray;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.Black;
            series2.MarkerSize = 15;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "cities";
            dataPoint4.Label = "0";
            dataPoint5.Label = "1";
            series2.Points.Add(dataPoint4);
            series2.Points.Add(dataPoint5);
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.LabelBackColor = System.Drawing.Color.Black;
            series3.LabelBorderColor = System.Drawing.Color.Black;
            series3.LabelBorderWidth = 0;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.Transparent;
            series3.MarkerSize = 0;
            series3.Name = "ants";
            dataPoint6.Label = "0";
            dataPoint6.LabelBackColor = System.Drawing.Color.Black;
            dataPoint6.LabelBorderColor = System.Drawing.Color.Black;
            dataPoint7.Label = "1";
            dataPoint7.LabelBackColor = System.Drawing.Color.Black;
            dataPoint7.LabelBorderColor = System.Drawing.Color.Black;
            series3.Points.Add(dataPoint6);
            series3.Points.Add(dataPoint7);
            series3.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Empty;
            series3.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Round;
            series3.SmartLabelStyle.CalloutLineWidth = 3;
            this.chartResults.Series.Add(series1);
            this.chartResults.Series.Add(series2);
            this.chartResults.Series.Add(series3);
            this.chartResults.Size = new System.Drawing.Size(1133, 1000);
            this.chartResults.TabIndex = 0;
            this.chartResults.Text = "chart1";
            this.chartResults.Click += new System.EventHandler(this.chartResults_Click);
            // 
            // tableLayout
            // 
            this.tableLayout.AutoSize = true;
            this.tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayout.Controls.Add(this.chartResults, 0, 0);
            this.tableLayout.Controls.Add(this.panControls, 1, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(1389, 1006);
            this.tableLayout.TabIndex = 1;
            // 
            // panControls
            // 
            this.panControls.Controls.Add(this.btnReset);
            this.panControls.Controls.Add(this.btnSolve);
            this.panControls.Controls.Add(this.btnMoveOneCycle);
            this.panControls.Controls.Add(this.tableLayoutPanel1);
            this.panControls.Controls.Add(this.btnMoveAnts);
            this.panControls.Controls.Add(this.chboxShowAnts);
            this.panControls.Controls.Add(lblCityCount);
            this.panControls.Controls.Add(this.tbCityCount);
            this.panControls.Controls.Add(this.btnCreateCities);
            this.panControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panControls.Location = new System.Drawing.Point(1142, 3);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(244, 1000);
            this.panControls.TabIndex = 1;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(44, 663);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(124, 73);
            this.btnSolve.TabIndex = 11;
            this.btnSolve.Text = "100 Cycles";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnMoveOneCycle
            // 
            this.btnMoveOneCycle.Location = new System.Drawing.Point(44, 576);
            this.btnMoveOneCycle.Name = "btnMoveOneCycle";
            this.btnMoveOneCycle.Size = new System.Drawing.Size(124, 81);
            this.btnMoveOneCycle.TabIndex = 10;
            this.btnMoveOneCycle.Text = "Move Cycle";
            this.btnMoveOneCycle.UseVisualStyleBackColor = true;
            this.btnMoveOneCycle.Click += new System.EventHandler(this.btnMoveOneCycle_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbAlpha, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbBeta, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbRho, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 328);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(185, 136);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(82, 28);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(100, 31);
            this.tbAlpha.TabIndex = 5;
            this.tbAlpha.Text = "1.0";
            // 
            // tbBeta
            // 
            this.tbBeta.Location = new System.Drawing.Point(82, 65);
            this.tbBeta.Name = "tbBeta";
            this.tbBeta.Size = new System.Drawing.Size(100, 31);
            this.tbBeta.TabIndex = 6;
            this.tbBeta.Text = "1.0";
            // 
            // tbRho
            // 
            this.tbRho.Location = new System.Drawing.Point(82, 102);
            this.tbRho.Name = "tbRho";
            this.tbRho.Size = new System.Drawing.Size(100, 31);
            this.tbRho.TabIndex = 7;
            this.tbRho.Text = "0.5";
            // 
            // btnMoveAnts
            // 
            this.btnMoveAnts.Location = new System.Drawing.Point(44, 496);
            this.btnMoveAnts.Name = "btnMoveAnts";
            this.btnMoveAnts.Size = new System.Drawing.Size(124, 74);
            this.btnMoveAnts.TabIndex = 4;
            this.btnMoveAnts.Text = "Move Ants";
            this.btnMoveAnts.UseVisualStyleBackColor = true;
            this.btnMoveAnts.Click += new System.EventHandler(this.btnMoveAnts_Click);
            // 
            // chboxShowAnts
            // 
            this.chboxShowAnts.AutoSize = true;
            this.chboxShowAnts.Checked = true;
            this.chboxShowAnts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxShowAnts.Location = new System.Drawing.Point(20, 277);
            this.chboxShowAnts.Name = "chboxShowAnts";
            this.chboxShowAnts.Size = new System.Drawing.Size(146, 29);
            this.chboxShowAnts.TabIndex = 3;
            this.chboxShowAnts.Text = "Show Ants";
            this.chboxShowAnts.UseVisualStyleBackColor = true;
            this.chboxShowAnts.CheckedChanged += new System.EventHandler(this.chboxShowAnts_CheckedChanged);
            // 
            // tbCityCount
            // 
            this.tbCityCount.Location = new System.Drawing.Point(131, 18);
            this.tbCityCount.Name = "tbCityCount";
            this.tbCityCount.Size = new System.Drawing.Size(50, 31);
            this.tbCityCount.TabIndex = 1;
            this.tbCityCount.Text = "15";
            // 
            // btnCreateCities
            // 
            this.btnCreateCities.Location = new System.Drawing.Point(52, 64);
            this.btnCreateCities.Name = "btnCreateCities";
            this.btnCreateCities.Size = new System.Drawing.Size(124, 72);
            this.btnCreateCities.TabIndex = 0;
            this.btnCreateCities.Text = "Create Cities";
            this.btnCreateCities.UseVisualStyleBackColor = true;
            this.btnCreateCities.Click += new System.EventHandler(this.btnCreateCities_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(44, 752);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 65);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1389, 1006);
            this.Controls.Add(this.tableLayout);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Ch4 - Ants";
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            this.tableLayout.ResumeLayout(false);
            this.panControls.ResumeLayout(false);
            this.panControls.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel panControls;
        private System.Windows.Forms.Button btnCreateCities;
        private System.Windows.Forms.TextBox tbCityCount;
        private System.Windows.Forms.CheckBox chboxShowAnts;
        private System.Windows.Forms.Button btnMoveAnts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.TextBox tbBeta;
        private System.Windows.Forms.TextBox tbRho;
        private System.Windows.Forms.Button btnMoveOneCycle;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnReset;
    }
}

