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

        }

        private PersonInfo currentUser;
    }
}
