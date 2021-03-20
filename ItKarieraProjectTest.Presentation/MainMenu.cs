using ItKarieraProjectTest.Models;
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
            this.currentUser = Session.CurrentUser;
            this.nameLabel.Text = $"{this.currentUser.FirstName} {this.currentUser.LastName}";
            this.balanceLabel.Text = $"{this.currentUser.Money}";
            //this.companyLabel.Text = $"{this.currentUser.Company}";

            //switch (this.currentUser.CompanyId)
            //{
               // case 1:
                    //this.companyLabel.Text = "Sealord";
                    //break;
                //case 2:
                    //this.companyLabel.Text = "Feil Group";
                    //break;
               // case 3:
                    //this.companyLabel.Text = "Halvorson LLC";
                  //  break;
               // case 4:
                  //  this.companyLabel.Text = "Grant-Howell";
                 //   break;
               // case 5:
               //     this.companyLabel.Text = "Gislason";
               //     break;
          //  }

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
    }
}
