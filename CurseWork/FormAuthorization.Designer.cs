namespace Views
{
	partial class FormAuthorization
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelLogin = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonEnter = new System.Windows.Forms.Button();
			this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// labelLogin
			// 
			this.labelLogin.AutoSize = true;
			this.labelLogin.Location = new System.Drawing.Point(12, 18);
			this.labelLogin.Name = "labelLogin";
			this.labelLogin.Size = new System.Drawing.Size(66, 25);
			this.labelLogin.TabIndex = 0;
			this.labelLogin.Text = "Логин:";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(12, 54);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(66, 25);
			this.labelEmail.TabIndex = 1;
			this.labelEmail.Text = "Почта:";
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(12, 95);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(78, 25);
			this.labelPassword.TabIndex = 2;
			this.labelPassword.Text = "Пароль:";
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Location = new System.Drawing.Point(96, 18);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(297, 31);
			this.textBoxLogin.TabIndex = 3;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(96, 54);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(297, 31);
			this.textBoxEmail.TabIndex = 4;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(96, 92);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(297, 31);
			this.textBoxPassword.TabIndex = 5;
			// 
			// buttonEnter
			// 
			this.buttonEnter.Location = new System.Drawing.Point(150, 129);
			this.buttonEnter.Name = "buttonEnter";
			this.buttonEnter.Size = new System.Drawing.Size(112, 34);
			this.buttonEnter.TabIndex = 6;
			this.buttonEnter.Text = "Войти";
			this.buttonEnter.UseVisualStyleBackColor = true;
			this.buttonEnter.Click += new System.EventHandler(this.ButtonLogin_Click);
			// 
			// linkLabelRegister
			// 
			this.linkLabelRegister.AutoSize = true;
			this.linkLabelRegister.Location = new System.Drawing.Point(115, 186);
			this.linkLabelRegister.Name = "linkLabelRegister";
			this.linkLabelRegister.Size = new System.Drawing.Size(178, 25);
			this.linkLabelRegister.TabIndex = 7;
			this.linkLabelRegister.TabStop = true;
			this.linkLabelRegister.Text = "Зарегистрироваться";
			this.linkLabelRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelRegister_LinkClicked);
			// 
			// FormAuthorization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 220);
			this.Controls.Add(this.linkLabelRegister);
			this.Controls.Add(this.buttonEnter);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelLogin);
			this.Name = "FormAuthorization";
			this.Text = "Авторизация";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label labelLogin;
		private Label labelEmail;
		private Label labelPassword;
		private TextBox textBoxLogin;
		private TextBox textBoxEmail;
		private TextBox textBoxPassword;
		private Button buttonEnter;
		private LinkLabel linkLabelRegister;
	}
}