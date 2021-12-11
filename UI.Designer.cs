namespace nettleieKalkulator1._0._0
{
    partial class UI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.netteiereComboBox = new System.Windows.Forms.ComboBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.timeStampLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPowerConsumptionTextBox = new System.Windows.Forms.TextBox();
            this.newPriceTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.oldPriceTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.powerDonutChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.newCostDognutChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.maxPowerDongutChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.oldCostDognutChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.kapasitetsLeddPrisTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.priceInfoButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sidePanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.powerDonutChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newCostDognutChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPowerDongutChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldCostDognutChart)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.sidePanel.Controls.Add(this.priceInfoButton);
            this.sidePanel.Controls.Add(this.browseButton);
            this.sidePanel.Controls.Add(this.exitButton);
            this.sidePanel.Controls.Add(this.button1);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 75);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 831);
            this.sidePanel.TabIndex = 1;
            this.sidePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.sidePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.sidePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.topPanel.Controls.Add(this.label5);
            this.topPanel.Controls.Add(this.netteiereComboBox);
            this.topPanel.Controls.Add(this.warningLabel);
            this.topPanel.Controls.Add(this.timeStampLabel);
            this.topPanel.Controls.Add(this.label15);
            this.topPanel.Controls.Add(this.label14);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1307, 75);
            this.topPanel.TabIndex = 2;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label5.Location = new System.Drawing.Point(1002, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "Netteier:";
            // 
            // netteiereComboBox
            // 
            this.netteiereComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.netteiereComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.netteiereComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.netteiereComboBox.FormattingEnabled = true;
            this.netteiereComboBox.Location = new System.Drawing.Point(1086, 1);
            this.netteiereComboBox.Name = "netteiereComboBox";
            this.netteiereComboBox.Size = new System.Drawing.Size(221, 29);
            this.netteiereComboBox.TabIndex = 3;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.ForeColor = System.Drawing.Color.Orange;
            this.warningLabel.Location = new System.Drawing.Point(590, 30);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(318, 21);
            this.warningLabel.TabIndex = 32;
            this.warningLabel.Text = "Warning, data is not a complete month";
            this.warningLabel.Visible = false;
            // 
            // timeStampLabel
            // 
            this.timeStampLabel.AutoSize = true;
            this.timeStampLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.timeStampLabel.Location = new System.Drawing.Point(590, 9);
            this.timeStampLabel.Name = "timeStampLabel";
            this.timeStampLabel.Size = new System.Drawing.Size(128, 21);
            this.timeStampLabel.TabIndex = 31;
            this.timeStampLabel.Text = "Data tidspunkt";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(265, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "by sTech";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label14.Location = new System.Drawing.Point(12, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(296, 40);
            this.label14.TabIndex = 29;
            this.label14.Text = "Ny nettleie kalkulator";
            this.label14.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label1.Location = new System.Drawing.Point(754, 881);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Totalt forbruk:";
            // 
            // totalPowerConsumptionTextBox
            // 
            this.totalPowerConsumptionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.totalPowerConsumptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalPowerConsumptionTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.totalPowerConsumptionTextBox.Location = new System.Drawing.Point(871, 880);
            this.totalPowerConsumptionTextBox.Name = "totalPowerConsumptionTextBox";
            this.totalPowerConsumptionTextBox.Size = new System.Drawing.Size(427, 20);
            this.totalPowerConsumptionTextBox.TabIndex = 4;
            // 
            // newPriceTextBox
            // 
            this.newPriceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.newPriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newPriceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.newPriceTextBox.Location = new System.Drawing.Point(824, 452);
            this.newPriceTextBox.Name = "newPriceTextBox";
            this.newPriceTextBox.Size = new System.Drawing.Size(474, 20);
            this.newPriceTextBox.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label12.Location = new System.Drawing.Point(754, 453);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 19);
            this.label12.TabIndex = 27;
            this.label12.Text = "Ny pris:";
            // 
            // oldPriceTextBox
            // 
            this.oldPriceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.oldPriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oldPriceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.oldPriceTextBox.Location = new System.Drawing.Point(324, 452);
            this.oldPriceTextBox.Name = "oldPriceTextBox";
            this.oldPriceTextBox.Size = new System.Drawing.Size(425, 20);
            this.oldPriceTextBox.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label13.Location = new System.Drawing.Point(205, 453);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 19);
            this.label13.TabIndex = 25;
            this.label13.Text = "Gammel pris:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // powerDonutChart
            // 
            this.powerDonutChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.powerDonutChart.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.powerDonutChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.AxisX2.LabelStyle.Enabled = false;
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea1.Name = "ChartArea1";
            this.powerDonutChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            legend1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.powerDonutChart.Legends.Add(legend1);
            this.powerDonutChart.Location = new System.Drawing.Point(758, 528);
            this.powerDonutChart.Name = "powerDonutChart";
            this.powerDonutChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(68)))));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.powerDonutChart.Series.Add(series1);
            this.powerDonutChart.Size = new System.Drawing.Size(540, 350);
            this.powerDonutChart.TabIndex = 29;
            title1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            title1.Name = "Title1";
            title1.Text = "Energibruk fordeling";
            this.powerDonutChart.Titles.Add(title1);
            this.powerDonutChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.powerDonutChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.powerDonutChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // newCostDognutChart
            // 
            this.newCostDognutChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.newCostDognutChart.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.newCostDognutChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.AxisX2.LabelStyle.Enabled = false;
            chartArea2.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea2.Name = "ChartArea1";
            this.newCostDognutChart.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            legend2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.newCostDognutChart.Legends.Add(legend2);
            this.newCostDognutChart.Location = new System.Drawing.Point(758, 100);
            this.newCostDognutChart.Name = "newCostDognutChart";
            this.newCostDognutChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(68)))));
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.newCostDognutChart.Series.Add(series2);
            this.newCostDognutChart.Size = new System.Drawing.Size(540, 350);
            this.newCostDognutChart.TabIndex = 30;
            title2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            title2.Name = "Title1";
            title2.Text = "Ny kostnadsfordeling";
            this.newCostDognutChart.Titles.Add(title2);
            this.newCostDognutChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.newCostDognutChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.newCostDognutChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // maxPowerDongutChart
            // 
            this.maxPowerDongutChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.maxPowerDongutChart.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.maxPowerDongutChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.AxisX2.LabelStyle.Enabled = false;
            chartArea3.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.AxisX2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.AxisY2.LabelStyle.Enabled = false;
            chartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea3.Name = "ChartArea1";
            this.maxPowerDongutChart.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            legend3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.maxPowerDongutChart.Legends.Add(legend3);
            this.maxPowerDongutChart.Location = new System.Drawing.Point(209, 528);
            this.maxPowerDongutChart.Name = "maxPowerDongutChart";
            this.maxPowerDongutChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.IsValueShownAsLabel = true;
            series3.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(68)))));
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.maxPowerDongutChart.Series.Add(series3);
            this.maxPowerDongutChart.Size = new System.Drawing.Size(540, 350);
            this.maxPowerDongutChart.TabIndex = 31;
            title3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            title3.Name = "Title1";
            title3.Text = "Max effekt";
            this.maxPowerDongutChart.Titles.Add(title3);
            this.maxPowerDongutChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.maxPowerDongutChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.maxPowerDongutChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // oldCostDognutChart
            // 
            this.oldCostDognutChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.oldCostDognutChart.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.oldCostDognutChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea4.AxisX.LabelStyle.Enabled = false;
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.AxisX2.LabelStyle.Enabled = false;
            chartArea4.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.AxisX2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.AxisY.LabelStyle.Enabled = false;
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.AxisY.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.AxisY2.LabelStyle.Enabled = false;
            chartArea4.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.AxisY2.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            chartArea4.Name = "ChartArea1";
            this.oldCostDognutChart.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            legend4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.oldCostDognutChart.Legends.Add(legend4);
            this.oldCostDognutChart.Location = new System.Drawing.Point(209, 100);
            this.oldCostDognutChart.Name = "oldCostDognutChart";
            this.oldCostDognutChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.IsValueShownAsLabel = true;
            series4.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(68)))));
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.oldCostDognutChart.Series.Add(series4);
            this.oldCostDognutChart.Size = new System.Drawing.Size(540, 350);
            this.oldCostDognutChart.TabIndex = 32;
            title4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            title4.Name = "Title1";
            title4.Text = "Gammel kostnadsfordeling";
            this.oldCostDognutChart.Titles.Add(title4);
            this.oldCostDognutChart.Click += new System.EventHandler(this.oldCostDognutChart_Click);
            this.oldCostDognutChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.oldCostDognutChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.oldCostDognutChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label2.Location = new System.Drawing.Point(205, 881);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Kapasitetsledd pris:";
            // 
            // kapasitetsLeddPrisTextBox
            // 
            this.kapasitetsLeddPrisTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.kapasitetsLeddPrisTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kapasitetsLeddPrisTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.kapasitetsLeddPrisTextBox.Location = new System.Drawing.Point(367, 880);
            this.kapasitetsLeddPrisTextBox.Name = "kapasitetsLeddPrisTextBox";
            this.kapasitetsLeddPrisTextBox.Size = new System.Drawing.Size(382, 20);
            this.kapasitetsLeddPrisTextBox.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label3.Location = new System.Drawing.Point(205, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Kostnadsdetaljer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.label4.Location = new System.Drawing.Point(205, 506);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "Forbruksdetaljer:";
            // 
            // priceInfoButton
            // 
            this.priceInfoButton.BackColor = System.Drawing.Color.Transparent;
            this.priceInfoButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.priceInfoButton.Enabled = false;
            this.priceInfoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.priceInfoButton.FlatAppearance.BorderSize = 0;
            this.priceInfoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.priceInfoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.priceInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.priceInfoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.priceInfoButton.Image = global::nettleieKalkulator1._0._0.Properties.Resources.euro;
            this.priceInfoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.priceInfoButton.Location = new System.Drawing.Point(0, 50);
            this.priceInfoButton.Margin = new System.Windows.Forms.Padding(5);
            this.priceInfoButton.Name = "priceInfoButton";
            this.priceInfoButton.Size = new System.Drawing.Size(200, 50);
            this.priceInfoButton.TabIndex = 3;
            this.priceInfoButton.Text = "Pris info";
            this.priceInfoButton.UseVisualStyleBackColor = false;
            this.priceInfoButton.Click += new System.EventHandler(this.priceInfoButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.Transparent;
            this.browseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.browseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.browseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.browseButton.Image = global::nettleieKalkulator1._0._0.Properties.Resources.folder;
            this.browseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseButton.Location = new System.Drawing.Point(0, 731);
            this.browseButton.Margin = new System.Windows.Forms.Padding(5);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(200, 50);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Velg fil fra disk";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.exitButton.Image = global::nettleieKalkulator1._0._0.Properties.Resources.logout;
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.Location = new System.Drawing.Point(0, 781);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 50);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Avslutt";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(188)))));
            this.button1.Image = global::nettleieKalkulator1._0._0.Properties.Resources.analytics__2_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Analyser data";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1307, 906);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kapasitetsLeddPrisTextBox);
            this.Controls.Add(this.oldCostDognutChart);
            this.Controls.Add(this.maxPowerDongutChart);
            this.Controls.Add(this.newCostDognutChart);
            this.Controls.Add(this.powerDonutChart);
            this.Controls.Add(this.newPriceTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.oldPriceTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.totalPowerConsumptionTextBox);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elhub data kalkulator";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onMouseUp);
            this.sidePanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.powerDonutChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newCostDognutChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPowerDongutChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldCostDognutChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox totalPowerConsumptionTextBox;
        private System.Windows.Forms.TextBox newPriceTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox oldPriceTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataVisualization.Charting.Chart powerDonutChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart newCostDognutChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart maxPowerDongutChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart oldCostDognutChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kapasitetsLeddPrisTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label timeStampLabel;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox netteiereComboBox;
        private System.Windows.Forms.Button priceInfoButton;
    }
}