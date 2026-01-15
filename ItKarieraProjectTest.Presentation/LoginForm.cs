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

			    this.loginController.Login(this.usernameTextBox.Text, hashedPassword);

				passwordTextBox.Clear();
				usernameTextBox.Clear();
				this.Hide();

				var MainMenuForm = FormFactory.GetFormInstance<MainMenu>();
				MainMenuForm.Show();
			}
			catch (Exception exception)
			{

				this.errorLabel.Visible = true;
				this.errorLabel.Text = exception.Message;
			}
		}

        private void registerButton_Click(object sender, EventArgs e)
        {
			passwordTextBox.Clear();
			usernameTextBox.Clear();
			this.Hide();

			var registerForm = FormFactory.GetFormInstance<RegisterForm>();
			registerForm.Show();
		}
    }
}
