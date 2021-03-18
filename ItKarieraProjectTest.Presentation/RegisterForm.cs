using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItKarieraProjectTest.Presentation.Utility;

namespace ItKarieraProjectTest.Presentation
{
    public partial class RegisterForm : Form
    {
		public RegisterForm(ILoginController loginController)
		{
			this.loginController = loginController;

			InitializeComponent();
			this.errorLabel.Visible = false;
		}

		private ILoginController loginController;

		private void registerButton_Click(object sender, EventArgs e)
		{
			try
			{

				if (!PasswordHelper.IsSame(this.passwordTextBox.Text, this.repeatPasswordTextBox.Text)) throw new Exception("Password mismatch");

				RegistrationViewModel registrationViewModel = new RegistrationViewModel();

				registrationViewModel.FirstName = this.firstNameTextBox.Text;
				registrationViewModel.LastName = this.lastNameTextBox.Text;
				registrationViewModel.Company = int.Parse(companyTextBox.Text);
				registrationViewModel.WorkHours = int.Parse(workhoursTextBox.Text);
				registrationViewModel.Balance = int.Parse(balanceTextBox.Text);

				registrationViewModel.Username = this.usernameTextBox.Text;
				registrationViewModel.Password = PasswordHelper.HashPassword(this.passwordTextBox.Text);

				this.loginController.Register(registrationViewModel);
				this.Close();
				var homeForm = FormFactory.GetFormInstance<LoginForm>();
				homeForm.Show();
			}
			catch (Exception error)
			{

				this.errorLabel.Visible = true;
				this.errorLabel.Text = error.Message;
			}


		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
		{

			var loginForm = FormFactory.GetFormInstance<LoginForm>();
			loginForm.Show();
		}
    }
}
