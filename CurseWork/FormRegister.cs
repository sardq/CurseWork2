using Contracts.BusinessLogicsContracts;
using Contracts.BindingModels;
using DataModels.Enums;
using Microsoft.Extensions.Logging;

namespace Views
{
	public partial class FormRegister : Form
	{
		private readonly ILogger<FormRegister> _logger;
		private readonly IClientLogic _clientLogic;

		public FormRegister(ILogger<FormRegister> logger, IClientLogic clientLogic)
		{
			InitializeComponent();
			_logger = logger;
			_clientLogic = clientLogic;
		}

		private void ButtonRegister_Click(object sender, EventArgs e)
		{
			_logger.LogInformation("Попытка регистрации пользователя {Login}", textBoxLogin.Text);
			try
			{
				if (string.IsNullOrWhiteSpace(textBoxLogin.Text) ||
					string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
					string.IsNullOrWhiteSpace(textBoxPassword.Text))
				{
					MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var model = new ClientBindingModel
				{
					Login = textBoxLogin.Text,
					Email = textBoxEmail.Text,
					Password = textBoxPassword.Text,
					Role = ClientRole.User
				};

				if (_clientLogic.Create(model))
				{
					MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show("Ошибка при регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка регистрации");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
