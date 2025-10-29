using Contracts.BusinessLogicsContracts;
using Contracts.SearchModels;
using Microsoft.Extensions.Logging;

namespace Views
{
	public partial class FormAuthorization : Form
	{
		private readonly ILogger<FormAuthorization> _logger;
		private readonly IClientLogic _clientLogic;

		public FormAuthorization(ILogger<FormAuthorization> logger, IClientLogic clientLogic)
		{
			InitializeComponent();
			_logger = logger;
			_clientLogic = clientLogic;
		}

		private void ButtonLogin_Click(object sender, EventArgs e)
		{
			_logger.LogInformation("Попытка входа пользователя {Login}", textBoxLogin.Text);
			try
			{
				if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
				{
					MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var user = _clientLogic.ReadElement(new ClientSearchModel
				{
					Login = textBoxLogin.Text,
					Password = textBoxPassword.Text
				});

				if (user == null)
				{
					MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				_logger.LogInformation("Успешный вход пользователя {Login}", user.Login);
				MessageBox.Show($"Добро пожаловать, {user.Login}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

				var mainForm = Program.ServiceProvider?.GetService(typeof(FormMain)) as FormMain;
				if (mainForm != null)
				{
					//mainForm.CurrentClient = user;
					mainForm.Show();
					Hide();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка авторизации");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LinkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			_logger.LogInformation("Переход на форму регистрации");
			var form = Program.ServiceProvider?.GetService(typeof(FormRegister)) as FormRegister;
			if (form != null)
			{
				form.ShowDialog();
			}
		}
	}
}
