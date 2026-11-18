#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Stivity
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblStudentNumber = null!;
        private TextBox txtStudentNumber = null!;
        private Label lblPassword = null!;
        private TextBox txtPassword = null!;
        private CheckBox chkShowPassword = null!;
        private Button btnLogin = null!;
        private Button btnGoToRegister = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblStudentNumber = new Label();
            txtStudentNumber = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            btnGoToRegister = new Button();
            SuspendLayout();

            ClientSize = new Size(400, 390);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.White;
            Text = "Stivity - Student Login";

            lblTitle.Text = "STIVITY";
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(40, 25);
            lblTitle.AutoSize = true;

            lblSubtitle.Text = "Student Account Portal";
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(43, 62);
            lblSubtitle.AutoSize = true;

            lblStudentNumber.Text = "Student Number";
            lblStudentNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStudentNumber.Location = new Point(43, 105);
            lblStudentNumber.AutoSize = true;

            txtStudentNumber.Font = new Font("Segoe UI", 11F);
            txtStudentNumber.Location = new Point(43, 128);
            txtStudentNumber.Size = new Size(310, 27);

            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.Location = new Point(43, 170);
            lblPassword.AutoSize = true;

            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(43, 193);
            txtPassword.Size = new Size(310, 27);
            txtPassword.UseSystemPasswordChar = true;

            chkShowPassword.Text = "Show Password";
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.Location = new Point(43, 228);
            chkShowPassword.AutoSize = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
          
            btnLogin.Text = "Sign In";
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.BackColor = Color.DarkRed;
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(43, 265);
            btnLogin.Size = new Size(310, 38);
            btnLogin.Click += btnLogin_Click;

            btnGoToRegister.Text = "Create New Student Account";
            btnGoToRegister.Font = new Font("Segoe UI", 9.5F);
            btnGoToRegister.FlatStyle = FlatStyle.Flat;
            btnGoToRegister.Location = new Point(43, 313);
            btnGoToRegister.Size = new Size(310, 35);
            btnGoToRegister.Click += btnGoToRegister_Click;

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(lblStudentNumber);
            Controls.Add(txtStudentNumber);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(chkShowPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnGoToRegister);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}