namespace Views
{
	partial class FormRegister
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
			this.buttonEnter = new System.Windows.Forms.Button();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelLogin = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonEnter
			// 
			this.buttonEnter.Location = new System.Drawing.Point(115, 123);
			this.buttonEnter.Name = "buttonEnter";
			this.buttonEnter.Size = new System.Drawing.Size(190, 34);
			this.buttonEnter.TabIndex = 14;
			this.buttonEnter.Text = "Зарегистрироваться";
			this.buttonEnter.UseVisualStyleBackColor = true;
			this.buttonEnter.Click += new System.EventHandler(this.ButtonRegister_Click);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(88, 86);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(297, 31);
			this.textBoxPassword.TabIndex = 13;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(88, 48);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(297, 31);
			this.textBoxEmail.TabIndex = 12;
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Location = new System.Drawing.Point(88, 12);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(297, 31);
			this.textBoxLogin.TabIndex = 11;
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(4, 89);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(78, 25);
			this.labelPassword.TabIndex = 10;
			this.labelPassword.Text = "Пароль:";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(4, 48);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(66, 25);
			this.labelEmail.TabIndex = 9;
			this.labelEmail.Text = "Почта:";
			// 
			// labelLogin
			// 
			this.labelLogin.AutoSize = true;
			this.labelLogin.Location = new System.Drawing.Point(4, 12);
			this.labelLogin.Name = "labelLogin";
			this.labelLogin.Size = new System.Drawing.Size(66, 25);
			this.labelLogin.TabIndex = 8;
			this.labelLogin.Text = "Логин:";
			// 
			// FormRegister
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 168);
			this.Controls.Add(this.buttonEnter);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelLogin);
			this.Name = "FormRegister";
			this.Text = "Регистрация";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Button buttonEnter;
		private TextBox textBoxPassword;
		private TextBox textBoxEmail;
		private TextBox textBoxLogin;
		private Label labelPassword;
		private Label labelEmail;
		private Label labelLogin;
	}
}