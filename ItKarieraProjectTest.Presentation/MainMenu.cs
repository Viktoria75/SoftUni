using ItKarieraProjectTest.Models;
using ItKarieraProjectTest.DAO;
using ItKarieraProjectTest.Presentation.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ItKarieraProjectTest.Presentation
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.currentpaymentLabel.Visible = false;
            this.currentUser = Session.CurrentUser;
            this.nameLabel.Text = $"{this.currentUser.FirstName} {this.currentUser.LastName}";
            this.balanceLabel.Text = $"{this.currentUser.Money}";
            this.companyLabel.Text = $"{this.currentUser.Company}";

            switch (this.currentUser.CompanyId)
            {
               case 1:
                    this.companyLabel.Text = "Sealord";
                    break;
                case 2:
                    this.companyLabel.Text = "Feil Group";
                    break;
                case 3:
                    this.companyLabel.Text = "Halvorson LLC";
                    break;
               case 4:
                    this.companyLabel.Text = "Grant-Howell";
                    break;
                case 5:
                    this.companyLabel.Text = "Gislason";
                    break;
            }

            this.workhoursLabel.Text = $"{this.currentUser.WorkHours}";
            //this.currentpaymentLabel.Text = (this.currentUser.WorkHours * this.currentUser.Company.Rate).ToString();

        }

        private PersonInfo currentUser;

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var loginForm = FormFactory.GetFormInstance<LoginForm>();
            loginForm.Show();

        }

        //private void Updater(RegistrationViewModel registrationViewModel) { registrationViewModel.WorkHours = int.Parse(workhoursLabel.Text); }

        private void button1_Click(object sender, EventArgs e)
        {


            int add = int.Parse(this.textBox1.Text);
            int current = int.Parse(workhoursLabel.Text);
            int ac = (add + current);
            this.workhoursLabel.Text = $"{ac}";
            //this.workhoursLabel.Text = $"{this.currentUser.WorkHours}";

            //Session currentuser = new Session();
            //WorkHoursDAO.GetHours(currentUser.WorkHours);
            this.currentUser.WorkHours = int.Parse(workhoursLabel.Text);
            //this.currentUser.WorkHours = int.Parse(this.workhoursLabel.Text);
            this.textBox1.Clear();
        }

        //private void Updater()
        //{
        //    currentUser.WorkHours = int.Parse(workhoursLabel.Text);
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            int rate;
            int sum;
            switch (this.currentUser.CompanyId)
            {
                case 1:
                    rate = 6;
                    sum = rate * (int.Parse(this.workhoursLabel.Text));
                    this.currentpaymentLabel.Text = $"{sum}";
                    break;
                case 2:
                    rate = 9;
                    sum = rate * (int.Parse(this.workhoursLabel.Text));
                    this.currentpaymentLabel.Text = $"{sum}";
                    break;
                case 3:
                    rate = 3;
                    sum = rate * (int.Parse(this.workhoursLabel.Text));
                    this.currentpaymentLabel.Text = $"{sum}";
                    break;
                case 4:
                    rate = 9;
                    sum = rate * (int.Parse(this.workhoursLabel.Text));
                    this.currentpaymentLabel.Text = $"{sum}";
                    break;
                case 5:
                    rate = 2;
                    sum = rate * (int.Parse(this.workhoursLabel.Text));
                    this.currentpaymentLabel.Text = $"{sum}";
                    break;
            }

            this.currentpaymentLabel.Visible = true;
            //var sum = rate * (int.Parse(this.workhoursLabel.Text));
            //this.currentpaymentLabel.Text = 
        }
    }
}
