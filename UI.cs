using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nettleieKalkulator1._0._0
{
    public partial class UI : Form
    {
        #region variables for UI
    
        List<DateTime> fromDate = new List<DateTime>();     //List to store our from dates(From elhub)
        List<DateTime> toDate = new List<DateTime>();       //List to store our to dates(From elhub)
        List<double> hourlyConsumption = new List<double>();//List to store our hourly power measurments(From elhub)
        //TODO: Add more netteiere and function for their setup
        string[] nettEiere = { "Haugaland kraft" };         //List of supported "netteiere"
        string fileExtension = "";                          //Chosen file location by user
        int movX;                                           //position x
        int movY;                                           //position y
        bool isMoving;                                      //moving flag
        #endregion

        #region UI init
        public UI()
        {
            InitializeComponent();
            //Bind our supported "netteiere"
            netteiereComboBox.DataSource = nettEiere;
        }
        #endregion

        #region buttons
        //Analyze button click
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (nettEiere[netteiereComboBox.SelectedIndex])
                {
                    case "Haugaland kraft":
                        analyzeFileForHkraft();                                         //Analyze elhub data for hkraft
                        if(warningLabel.Visible == true)warningLabel.Visible = false;   //hide warning label incase visible
                        break;
                    default:
                        warningLabel.Text = "Warning, ukjent netteier velg en annen.";  //Update warning label for UI
                        if (warningLabel.Visible == false)warningLabel.Visible = true;  //show warning label incase not visible
                        break;
                }
            }
            catch
            {
                //TODO: notify user
                warningLabel.Text = "Warning, ukjent netteier velg en annen.";          //Update warning label for UI
                if (warningLabel.Visible == false)warningLabel.Visible = true;          //show warning label incase not visible
            }
        }

        //Exit button click
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();                                                               //Exit application
        }

        //'Browse' button
        private void settingsButton_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",                                              //Initial directory to open when browsing
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)                        //If file where chosen
            {
                fileExtension = openFileDialog1.FileName;                               //Get and save path
                if (readElhubCsvFileAndLoadToLists(fileExtension))                      //Read file
                {
                    if (button1.Enabled == false)button1.Enabled = true;                //Enable analyze button
                    timeStampLabel.Text = Elhub.relatedFunctions.getFromToDateAsString(fromDate, toDate); //Show timestamp for data to user
                    if (!Elhub.relatedFunctions.completeMonth(fromDate, toDate))        //Show warning if not a full month of data
                    {
                        warningLabel.Text = "Warning, data fra fil er ikke en hel måned.";//Update warning label for UI
                        if (warningLabel.Visible == false)warningLabel.Visible = true;  //show warning label incase not visible
                    }
                    else
                    {
                        if (warningLabel.Visible == true)warningLabel.Visible = false;  //hide warning label incase visible
                    }
                }
                else
                {
                    if(button1.Enabled == true)button1.Enabled = false;                 //Disable analyze button as we dont have data to analyze
                    warningLabel.Text = "Warning, ukjent filtype åpnet. Velg korrekt fil.";//Update warning label for UI
                    if (warningLabel.Visible == false)warningLabel.Visible = true;      //show warning label incase not visible
                }
            }
        }
        #endregion

        #region elhub analyzes
        private bool analyzeFileForHkraft()
        {
            try
            {
                //Prices TODO: import from JSON file? 
                double elavgift = 8.91;         //'el avgift' as of 1.1.22
                double enovaavgift = 1.0;       //'enova avgift' as of 08.12.21
                double moms = 1.25;             //'Moms' as of 08.12.21
                double dagEnergiledd = 26.0;    //Day energy price
                double kveldEnergiledd = 16.0;  //Night/weekend/holliday energy price
                double dayPriceEnergy = (dagEnergiledd + (elavgift + enovaavgift) * moms) / 100.0;                  //Total price for daytime
                double nightPriceEnergy = (kveldEnergiledd + (elavgift + enovaavgift) * moms) / 100.0;              //Total price for night/weekend/holiday
                double oldPriceEnergy = 49.10 / 100.0;                                                              //Old energy price
                int oldMonthlyCost = 225;                                                                           //Old monthly cost

                //Get calculated data
                //Power data
                double? maxHourlyPower = Elhub.relatedFunctions.getMaxPower(hourlyConsumption);                     //Get max hourly power consumption from elhub data
                double? totalPowerConsumption = Elhub.relatedFunctions.getTotalPower(hourlyConsumption);            //Get total power consumption from elhub data
                double? weekendConsumption = Hkraft.relatedFunctions.weekendPower(fromDate, hourlyConsumption);     //Get total weekend power consumption from elhub data
                double? nightConsumption = Hkraft.relatedFunctions.nightTimePower(fromDate, hourlyConsumption);     //Get total night power consumption from elhub data
                double? dayConsumption = Hkraft.relatedFunctions.dayTimePower(fromDate, hourlyConsumption);         //Get total day power consumption from elhub data

                //Make sure we did not fail to get data from elhub data
                if (maxHourlyPower == null || totalPowerConsumption == null || weekendConsumption == null || nightConsumption == null || dayConsumption == null)
                {
                    warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                    if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                    return false; //Failed to get some data, so we wont display TODO: need to show error to user
                }

                double monthlyCostNewRegime;                //new montly cost variable
                switch (maxHourlyPower)
                {
                    case double n when n < 5:
                        monthlyCostNewRegime = 290.0;       //Level one monthly cost
                        break;
                    case double n when n < 10:
                        monthlyCostNewRegime = 390.0;       //Level two monthly cost
                        break;  
                    case double n when n < 15:
                        monthlyCostNewRegime = 490.0;       //Level three monthly cost
                        break;
                    default:
                        monthlyCostNewRegime = 590.0;       //Level four monthly cost
                        break;
                }
                double energyCostForWeekendConsumption = (double)weekendConsumption * nightPriceEnergy; //Calculate cost for weekend power consumption
                double energyCostForNightConsumption = (double)nightConsumption * nightPriceEnergy;     //Calculate cost for night power consumption
                double energyCostForDayConsumption = (double)dayConsumption * dayPriceEnergy;           //Calculate cost for day power consumption
                double energyCostForOldConsumption = (double)totalPowerConsumption * oldPriceEnergy;    //Calculate old cost for power consumption     
                double monthlyCostOldRegime = oldMonthlyCost;                                           //'Calculate' old montly cost
                double newTotalCost = energyCostForWeekendConsumption + energyCostForNightConsumption + energyCostForDayConsumption + monthlyCostNewRegime; //Calculate new total cost
                double oldTotalCost = energyCostForOldConsumption + monthlyCostOldRegime;               //Calculate old total cost


                //Update UI
                //Power details
                //Power consumption chart
                double[] yValuesPower = { Math.Round((double)dayConsumption, 2), Math.Round((double)nightConsumption, 2), Math.Round((double)weekendConsumption, 2) };
                string[] xValuesPower = { "Dag", "Natt", "Helg" };
                powerDonutChart.Series["Series1"].Points.DataBindXY(xValuesPower, yValuesPower);
                totalPowerConsumptionTextBox.Text = Math.Round((double)totalPowerConsumption, 2).ToString() + " kWh.";

                //Max power consumption chart
                double[] yValuesMaxPower = { Math.Round((double)maxHourlyPower, 2), 20.0 };
                string[] xValuesMaxPower = { "Max timeforbruk", "Max kapasitetledd" };
                maxPowerDongutChart.Series["Series1"].Points.DataBindXY(xValuesMaxPower, yValuesMaxPower);
                kapasitetsLeddPrisTextBox.Text = Math.Round(monthlyCostNewRegime, 2).ToString() + " NOK.";

                //Cost details
                //New cost chart
                double[] yValuesCost = { Math.Round(energyCostForDayConsumption, 2), Math.Round(energyCostForNightConsumption, 2), Math.Round(energyCostForWeekendConsumption, 2), Math.Round(monthlyCostNewRegime, 2) };
                string[] xValuesCost = { "Dag", "Natt", "Helg", "Kapasitetsledd" };
                newCostDognutChart.Series["Series1"].Points.DataBindXY(xValuesCost, yValuesCost);
                newPriceTextBox.Text = Math.Round(newTotalCost, 2).ToString() + " NOK.";

                //Old cost chart
                double[] yValuesOldCost = { Math.Round(energyCostForOldConsumption, 2), Math.Round(monthlyCostOldRegime, 2) };
                string[] xValuesOldCost = { "Energiledd", "Fastledd" };
                oldCostDognutChart.Series["Series1"].Points.DataBindXY(xValuesOldCost, yValuesOldCost);
                oldPriceTextBox.Text = Math.Round(oldTotalCost, 2).ToString() + " NOK.";

                //Finished 
                return true;
            }
            catch
            {
                warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                return false;
            }
        }
        #endregion

        #region csv reader
        private bool readElhubCsvFileAndLoadToLists(string fileExtension)
        {
            try
            {
                int lineCounter = 0;                //Used to count lines read
                string readLine = "";               //Used to store the line we read
                string[] splitValues;               //Array for splitted csv values
                string tempConsumptionString = "";  //Temp string to add power consumption
                using (var reader = new StreamReader(fileExtension))
                {
                    fromDate.Clear();               //Clear list incase it has anything in it
                    toDate.Clear();                 //Clear list incase it has anything in it
                    hourlyConsumption.Clear();      //Clear list incase it has anything in it
                    while (!reader.EndOfStream)     //Read our file to the end
                    {
                        readLine = reader.ReadLine();//Read a line of our file
                        lineCounter++;              //Increment read lines
                        if (lineCounter == 1)       //When reading the first line we will check if it is a valid document and break if not
                        {
                            if (!readLine.Contains("Fra,Til,KWH 60 Forbruk")) //Check if the header of the file is as expected
                            {
                                warningLabel.Text = "Warning, feil filtype oppdaget. Prøv en annen fil.";  //Update warning label for UI
                                if (warningLabel.Visible == false) warningLabel.Visible = true;            //show warning label incase not visible
                                return false;       //Wrong file, abort!
                            }
                        }
                        splitValues = readLine.Split(',');//Split the read line where it is delimited
                        if (splitValues.Length == 4)//Where we have 4 values we have the data we are looking for, other is jibberish for us
                        {
                            fromDate.Add(Convert.ToDateTime(splitValues[0]));//Get the from datetime and add to our list
                            toDate.Add(Convert.ToDateTime(splitValues[1]));  //Get the to datetime and add to our list
                            tempConsumptionString = (splitValues[2] + '.' + splitValues[3]).Replace("\"", " "); //Modify the power string to be readdy to be converted to a double
                            hourlyConsumption.Add(Convert.ToDouble(tempConsumptionString));//Convert our string to double and add to our list
                        }
                    }
                }
                return true;                        //Finished
            }
            catch
            {
                //TODO: notify user?
                warningLabel.Text = "Warning, feil under lesing av fil. Prøv en annen fil.";  //Update warning label for UI
                if (warningLabel.Visible == false) warningLabel.Visible = true;            //show warning label incase not visible
                return false; 
            }
        }
        #endregion

        #region move UI functions
        private void onMouseDown(object sender, MouseEventArgs e)
        {
            // Assign this method to mouse_Down event of Form or Panel,whatever you want
            isMoving = true;
            movX = e.X;
            movY = e.Y;
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            // Assign this method to Mouse_Move event of that Form or Panel
            if (isMoving)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            // Assign this method to Mouse_Up event of Form or Panel.
            isMoving = false;
        }
        #endregion

        #region Non used UI functions
        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void oldCostDognutChart_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        #endregion
    }
}
