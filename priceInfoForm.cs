using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nettleieKalkulator1._0._0
{
    public partial class priceInfoForm : Form
    {
        public priceInfoForm()
        {
            InitializeComponent();
            OldEnergyPriceTextBox.Text = ConfigurationManager.AppSettings["oldEnergyPrice"];
            oldMonthlyFeeTextBox.Text = ConfigurationManager.AppSettings["oldMonthlyPrice"];
            dayPriceTextBox.Text = ConfigurationManager.AppSettings["newDayPrice"];
            nightPriceTextBox.Text = ConfigurationManager.AppSettings["newNightPrice"];
            newMonthlyFeeTextBox.Text = ConfigurationManager.AppSettings["newMonthlyPrice"];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void priceInfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
