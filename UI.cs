using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        debug.logToFile debugToFile = new debug.logToFile("calcLog");   //Object for logging
        List<DateTime> fromDate = new List<DateTime>();     //List to store our from dates(From elhub)
        List<DateTime> toDate = new List<DateTime>();       //List to store our to dates(From elhub)
        List<double> hourlyConsumption = new List<double>();//List to store our hourly power measurments(From elhub)
        //TODO: Add more netteiere and function for their setup
        string[] nettEiere = { "Haugaland kraft", "Norgesnet" , "Lede", "Elvia"};         //List of supported "netteiere"
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
                //analyzeFileForNnet
                switch (nettEiere[netteiereComboBox.SelectedIndex])
                {
                    case "Haugaland kraft":
                        analyzeFileForHkraft();                                         //Analyze elhub data for hkraft
                        if(warningLabel.Visible == true)warningLabel.Visible = false;   //hide warning label incase visible
                        break;
                    case "Norgesnet":
                        analyzeFileForNnet();                                         //Analyze elhub data for hkraft
                        if (warningLabel.Visible == true) warningLabel.Visible = false;   //hide warning label incase visible
                        break;
                    case "Lede":
                        analyzeFileForLede();                                         //Analyze elhub data for hkraft
                        if (warningLabel.Visible == true) warningLabel.Visible = false;   //hide warning label incase visible
                        break;
                    case "Elvia":
                        analyzeFileForElvia();                                         //Analyze elhub data for hkraft
                        if (warningLabel.Visible == true) warningLabel.Visible = false;   //hide warning label incase visible
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
        private bool analyzeFileForElvia()
        {
            try
            {
                //Prices TODO: import from JSON file? 
                double dayPriceEnergyVinter = 41.7 / 100.0;                  //Total price for daytime
                double nightPriceEnergyVinter = 29.2 / 100.0;              //Total price for night/weekend/holiday
                double dayPriceEnergySummer = 37.35 / 100.0;                  //Total price for daytime
                double nightPriceEnergySummer = 31.1 / 100.0;              //Total price for night/weekend/holiday
                double oldPriceEnergy = 44.80 / 100.0;                                                              //Old energy price
                int oldMonthlyCost = 115;                                                                           //Old monthly cost

                //Get calculated data
                //Power data
                double? maxHourlyPower = Elhub.relatedFunctions.getMaxPower(hourlyConsumption);                     //Get max hourly power consumption from elhub data
                double? totalPowerConsumption = Elhub.relatedFunctions.getTotalPower(hourlyConsumption);            //Get total power consumption from elhub data
                double? weekendConsumption = elvia.relatedFunctions.weekendPower(fromDate, hourlyConsumption);     //Get total weekend power consumption from elhub data
                double? nightConsumption = elvia.relatedFunctions.nightTimePower(fromDate, hourlyConsumption);     //Get total night power consumption from elhub data
                double? dayConsumption = elvia.relatedFunctions.dayTimePower(fromDate, hourlyConsumption);         //Get total day power consumption from elhub data

                //Make sure we did not fail to get data from elhub data
                if (maxHourlyPower == null || totalPowerConsumption == null || weekendConsumption == null || nightConsumption == null || dayConsumption == null)
                {
                    debugToFile.writeToLog("Failed getting data from file:");
                    warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                    if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                    return false; //Failed to get some data, so we wont display TODO: need to show error to user
                }

                double monthlyCostNewRegime;                //new montly cost variable
                switch (maxHourlyPower)
                {
                    case double n when n < 2:
                        monthlyCostNewRegime = 130.0;       //Level one monthly cost
                        break;
                    case double n when n < 5:
                        monthlyCostNewRegime = 190.0;       //Level two monthly cost
                        break;
                    case double n when n < 10:
                        monthlyCostNewRegime = 280.0;       //Level three monthly cost
                        break;
                    case double n when n < 15:
                        monthlyCostNewRegime = 375.0;       //Level three monthly cost
                        break;
                    default:
                        monthlyCostNewRegime = 470.0;       //Level four monthly cost
                        break;
                }
                double energyCostForWeekendConsumption = 0;
                double energyCostForNightConsumption = 0;
                double energyCostForDayConsumption = 0;
                if (elvia.relatedFunctions.isVinter(fromDate))
                {
                    energyCostForWeekendConsumption = (double)weekendConsumption * nightPriceEnergyVinter; //Calculate cost for weekend power consumption
                    energyCostForNightConsumption = (double)nightConsumption * nightPriceEnergyVinter;     //Calculate cost for night power consumption
                    energyCostForDayConsumption = (double)dayConsumption * dayPriceEnergyVinter;           //Calculate cost for day power consumption
                }
                else
                {
                    energyCostForWeekendConsumption = (double)weekendConsumption * nightPriceEnergySummer; //Calculate cost for weekend power consumption
                    energyCostForNightConsumption = (double)nightConsumption * nightPriceEnergySummer;     //Calculate cost for night power consumption
                    energyCostForDayConsumption = (double)dayConsumption * dayPriceEnergySummer;           //Calculate cost for day power consumption
                }
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
            catch (Exception e)
            {
                debugToFile.writeToLog("Catched analyzing data: " + e);
                warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                return false;
            }
        }
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
                    debugToFile.writeToLog("Failed getting data from file:");
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
            catch(Exception e)
            {
                debugToFile.writeToLog("Catched analyzing data: " + e);
                warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                return false;
            }
        }

        private bool analyzeFileForNnet()
        {
            try
            {
                //Prices TODO: import from JSON file? 
                double elavgift = 8.91;         //'el avgift' as of 1.1.22
                double enovaavgift = 1.0;       //'enova avgift' as of 08.12.21
                double moms = 1.25;             //'Moms' as of 08.12.21
                double dagEnergiledd = 22.5;    //Day energy price
                double kveldEnergiledd = 11.25;  //Night/weekend/holliday energy price
                double dayPriceEnergy = (dagEnergiledd + (elavgift + enovaavgift) * moms) / 100.0;                  //Total price for daytime
                double nightPriceEnergy = (kveldEnergiledd + (elavgift + enovaavgift) * moms) / 100.0;              //Total price for night/weekend/holiday
                double oldPriceEnergySummer = 43.10 / 100.0;                                                              //Old energy price
                double oldPriceEnergyVinter = 45.10 / 100.0;                                                              //Old energy price
                int oldMonthlyCost = 218;                                                                           //Old monthly cost

                //Get calculated data
                //Power data
                double? maxHourlyPower = Elhub.relatedFunctions.getMaxPower(hourlyConsumption);                     //Get max hourly power consumption from elhub data
                double? totalPowerConsumption = Elhub.relatedFunctions.getTotalPower(hourlyConsumption);            //Get total power consumption from elhub data
                double? nightConsumption = Nnet.relatedFunctions.nightTimePower(fromDate, hourlyConsumption);     //Get total night power consumption from elhub data
                double? dayConsumption = Nnet.relatedFunctions.dayTimePower(fromDate, hourlyConsumption);         //Get total day power consumption from elhub data

                //Make sure we did not fail to get data from elhub data
                if (maxHourlyPower == null || totalPowerConsumption == null || nightConsumption == null || dayConsumption == null)
                {
                    debugToFile.writeToLog("Failed getting data from file:");
                    warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                    if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                    return false; //Failed to get some data, so we wont display TODO: need to show error to user
                }

                double monthlyCostNewRegime;                //new montly cost variable
                switch (maxHourlyPower)
                {
                    case double n when n < 2:
                        monthlyCostNewRegime = 145.0;       //Level one monthly cost
                        break;
                    case double n when n < 5:
                        monthlyCostNewRegime = 180.0;       //Level two monthly cost
                        break;
                    case double n when n < 10:
                        monthlyCostNewRegime = 305.0;       //Level three monthly cost
                        break;
                    case double n when n < 15:
                        monthlyCostNewRegime = 490.0;       //Level three monthly cost
                        break;
                    case double n when n < 20:
                        monthlyCostNewRegime = 670.0;       //Level three monthly cost
                        break;
                    case double n when n < 25:
                        monthlyCostNewRegime = 1010.0;       //Level three monthly cost
                        break;
                    case double n when n < 50:
                        monthlyCostNewRegime = 1575.0;       //Level three monthly cost
                        break;
                    case double n when n < 75:
                        monthlyCostNewRegime = 2150.0;       //Level three monthly cost
                        break;
                    case double n when n < 100:
                        monthlyCostNewRegime = 2750.0;       //Level three monthly cost
                        break;
                    default:
                        monthlyCostNewRegime = 4375.0;       //Level three monthly cost
                        break;
                }
                double energyCostForNightConsumption = (double)nightConsumption * nightPriceEnergy;     //Calculate cost for night power consumption
                double energyCostForDayConsumption = (double)dayConsumption * dayPriceEnergy;           //Calculate cost for day power consumption
                     
                  
                double monthlyCostOldRegime = oldMonthlyCost;                                           //'Calculate' old montly cost
                double newTotalCost = energyCostForNightConsumption + energyCostForDayConsumption + monthlyCostNewRegime; //Calculate new total cost
                double energyCostForOldConsumption = 0;
                if (Nnet.relatedFunctions.isVinter(fromDate))
                {
                    

                    energyCostForOldConsumption = (double)totalPowerConsumption * oldPriceEnergyVinter;    //Calculate old cost for power consumption  
                   
                }
                else
                {
                    energyCostForOldConsumption = (double)totalPowerConsumption * oldPriceEnergySummer;    //Calculate old cost for power consumption
                }
                double oldTotalCost = energyCostForOldConsumption + monthlyCostOldRegime;               //Calculate old total cost


                //Update UI
                //Power details
                //Power consumption chart
                double[] yValuesPower = { Math.Round((double)dayConsumption, 2), Math.Round((double)nightConsumption, 2) };
                string[] xValuesPower = { "Dag", "Natt" };
                powerDonutChart.Series["Series1"].Points.DataBindXY(xValuesPower, yValuesPower);
                totalPowerConsumptionTextBox.Text = Math.Round((double)totalPowerConsumption, 2).ToString() + " kWh.";

                //Max power consumption chart
                double[] yValuesMaxPower = { Math.Round((double)maxHourlyPower, 2), 20.0 };
                string[] xValuesMaxPower = { "Max timeforbruk", "Max kapasitetledd" };
                maxPowerDongutChart.Series["Series1"].Points.DataBindXY(xValuesMaxPower, yValuesMaxPower);
                kapasitetsLeddPrisTextBox.Text = Math.Round(monthlyCostNewRegime, 2).ToString() + " NOK.";

                //Cost details
                //New cost chart
                double[] yValuesCost = { Math.Round(energyCostForDayConsumption, 2), Math.Round(energyCostForNightConsumption, 2), Math.Round(monthlyCostNewRegime, 2) };
                string[] xValuesCost = { "Dag", "Natt", "Kapasitetsledd" };
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
            catch (Exception e)
            {
                debugToFile.writeToLog("Catched analyzing data: " + e);
                warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                return false;
            }
        }

        private bool analyzeFileForLede()
        {
            try
            {
                //Prices TODO: import from JSON file? 
                double elavgift = 8.91;         //'el avgift' as of 1.1.22
                double enovaavgift = 1.0;       //'enova avgift' as of 08.12.21
                double moms = 1.25;             //'Moms' as of 08.12.21
                double dagEnergileddVinter = 16.0;    //Day energy price
                double kveldEnergileddVinter = 8.0;  //Night/weekend/holliday energy price
                double dagEnergileddSommer = 13.5;    //Day energy price
                double kveldEnergileddSommer = 6.75;  //Night/weekend/holliday energy price
                double dayPriceEnergyVinter = (dagEnergileddVinter + (elavgift + enovaavgift) * moms) / 100.0;                  //Total price for daytime
                double nightPriceEnergyVinter = (kveldEnergileddVinter + (elavgift + enovaavgift) * moms) / 100.0;              //Total price for night/weekend/holiday
                double dayPriceEnergySummer = (dagEnergileddSommer + (elavgift + enovaavgift) * moms) / 100.0;                  //Total price for daytime
                double nightPriceEnergySummer = (kveldEnergileddSommer + (elavgift + enovaavgift) * moms) / 100.0;              //Total price for night/weekend/holiday
                double oldPriceEnergyVinter = 41.74 / 100.0;                                                              //Old energy price
                double oldMonthlyCost = 287.5;                                                                           //Old monthly cost

                //Get calculated data
                //Power data
                double? maxHourlyPower = Elhub.relatedFunctions.getMaxPower(hourlyConsumption);                     //Get max hourly power consumption from elhub data
                double? totalPowerConsumption = Elhub.relatedFunctions.getTotalPower(hourlyConsumption);            //Get total power consumption from elhub data
                double? nightConsumption = lede.relatedFunctions.nightTimePower(fromDate, hourlyConsumption);     //Get total night power consumption from elhub data
                double? dayConsumption = lede.relatedFunctions.dayTimePower(fromDate, hourlyConsumption);         //Get total day power consumption from elhub data

                //Make sure we did not fail to get data from elhub data
                if (maxHourlyPower == null || totalPowerConsumption == null || nightConsumption == null || dayConsumption == null)
                {
                    debugToFile.writeToLog("Failed getting data from file:");
                    warningLabel.Text = "Warning, feil ved innhenting av data. Prøv en annen fil.";  //Update warning label for UI
                    if (warningLabel.Visible == false) warningLabel.Visible = true;                  //show warning label incase not visible
                    return false; //Failed to get some data, so we wont display TODO: need to show error to user
                }

                double monthlyCostNewRegime = 0;                //new montly cost variable
                switch (maxHourlyPower)
                {
                    case double n when n < 5:
                        monthlyCostNewRegime = 213.0;       //Level two monthly cost
                        break;
                    case double n when n < 10:
                        monthlyCostNewRegime = 383.0;       //Level three monthly cost
                        break;
                    case double n when n < 15:
                        monthlyCostNewRegime = 553.0;       //Level three monthly cost
                        break;
                    case double n when n < 20:
                        monthlyCostNewRegime = 724.0;       //Level three monthly cost
                        break;
                    case double n when n < 25:
                        monthlyCostNewRegime = 894.0;       //Level three monthly cost
                        break;
                    case double n when n < 50:
                        monthlyCostNewRegime = 1404.0;       //Level three monthly cost
                        break;
                    case double n when n < 75:
                        monthlyCostNewRegime = 2255.0;       //Level three monthly cost
                        break;
                    case double n when n < 100:
                        monthlyCostNewRegime = 3106.0;       //Level three monthly cost
                        break;
                }
                double energyCostForNightConsumption = 0;
                double energyCostForDayConsumption = 0;
                if (lede.relatedFunctions.isVinter(fromDate))
                {


                    energyCostForNightConsumption = (double)nightConsumption * nightPriceEnergyVinter;     //Calculate cost for night power consumption
                    energyCostForDayConsumption = (double)dayConsumption * dayPriceEnergyVinter;           //Calculate cost for day power consumption 

                }
                else
                {
                    energyCostForNightConsumption = (double)nightConsumption * nightPriceEnergySummer;     //Calculate cost for night power consumption
                    energyCostForDayConsumption = (double)dayConsumption * dayPriceEnergySummer;           //Calculate cost for day power consumption
                }



                double monthlyCostOldRegime = oldMonthlyCost;                                           //'Calculate' old montly cost
                double newTotalCost = energyCostForNightConsumption + energyCostForDayConsumption + monthlyCostNewRegime; //Calculate new total cost
                double energyCostForOldConsumption = (double)totalPowerConsumption * oldPriceEnergyVinter;    //Calculate old cost for power consumption 
                double oldTotalCost = energyCostForOldConsumption + monthlyCostOldRegime;               //Calculate old total cost


                //Update UI
                //Power details
                //Power consumption chart
                double[] yValuesPower = { Math.Round((double)dayConsumption, 2), Math.Round((double)nightConsumption, 2) };
                string[] xValuesPower = { "Dag", "Natt" };
                powerDonutChart.Series["Series1"].Points.DataBindXY(xValuesPower, yValuesPower);
                totalPowerConsumptionTextBox.Text = Math.Round((double)totalPowerConsumption, 2).ToString() + " kWh.";

                //Max power consumption chart
                double[] yValuesMaxPower = { Math.Round((double)maxHourlyPower, 2), 20.0 };
                string[] xValuesMaxPower = { "Max timeforbruk", "Max kapasitetledd" };
                maxPowerDongutChart.Series["Series1"].Points.DataBindXY(xValuesMaxPower, yValuesMaxPower);
                kapasitetsLeddPrisTextBox.Text = Math.Round(monthlyCostNewRegime, 2).ToString() + " NOK.";

                //Cost details
                //New cost chart
                double[] yValuesCost = { Math.Round(energyCostForDayConsumption, 2), Math.Round(energyCostForNightConsumption, 2), Math.Round(monthlyCostNewRegime, 2) };
                string[] xValuesCost = { "Dag", "Natt", "Kapasitetsledd" };
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
            catch (Exception e)
            {
                debugToFile.writeToLog("Catched analyzing data: " + e);
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
                                debugToFile.writeToLog("Error in file header: " + readLine);
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
                            hourlyConsumption.Add(Convert.ToDouble(tempConsumptionString, CultureInfo.InvariantCulture));//Convert our string to double and add to our list
                        }
                    }
                }
                return true;                        //Finished
            }
            catch(Exception e)
            {
                //TODO: notify user?
                debugToFile.writeToLog("Catched reading file: " + e);
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
