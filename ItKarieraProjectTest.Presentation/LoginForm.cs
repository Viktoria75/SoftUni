using System;
using System.Windows.Forms;
using ItKarieraProjectTest.Presentation.Utility;


namespace ItKarieraProjectTest.Presentation
{
    public partial class LoginForm : Form
    {
		public LoginForm(ILoginController loginController)
		{
			InitializeComponent();
			this.errorLabel.Visible = false;
			this.loginController = loginController;
		}

		private ILoginController loginController;

        private void loginButton_Click(object sender, EventArgs e)
        {

			try
			{
				string hashedPassword = PasswordHelper.HashPassword(this.passwordTextBox.Text);

				//int userId = 
			    this.loginController.Login(this.usernameTextBox.Text, hashedPassword);

				//RedirectLogin(userId);

				var MainMenuForm = FormFactory.GetFormInstance<MainMenu>();
				MainMenuForm.Show();

				this.Hide();
			}
			catch (Exception exception)
			{

				this.errorLabel.Visible = true;
				this.errorLabel.Text = exception.Message;
			}
		}

		//private void RedirectLogin(int userId) 
		//{
			//var MainMenuForm = FormFactory.GetFormInstance<MainMenu>();
			//MainMenuForm.Show();
			//this.Hide();
		//}

        private void registerButton_Click(object sender, EventArgs e)
        {
			this.Hide();

			var registerForm = FormFactory.GetFormInstance<RegisterForm>();
			registerForm.Show();
		}
    }
}
