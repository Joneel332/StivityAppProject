#nullable enable
using System.Drawing;
using System.Windows.Forms;

namespace Stivity
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblTitle = null!;
        private Label lblStudentNumber = null!;
        private TextBox txtStudentNumber = null!;
        private Label lblFullName = null!;
        private TextBox txtFullName = null!;
        private Label lblPassword = null!;
        private TextBox txtPassword = null!;
        private Label lblConfirm = null!;
        private TextBox txtConfirmPassword = null!;
        private Button btnRegister = null!;
        private Button btnBack = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblStudentNumber = new Label();
            txtStudentNumber = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirm = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            btnBack = new Button();
            SuspendLayout();

            ClientSize = new Size(400, 450);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.White;
            Text = "Stivity - Register Student";

            lblTitle.Text = "Create Student Account";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(40, 22);
            lblTitle.AutoSize = true;

            lblStudentNumber.Text = "Student Number";
            lblStudentNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStudentNumber.Location = new Point(43, 70);
            lblStudentNumber.AutoSize = true;

            txtStudentNumber.Font = new Font("Segoe UI", 10.5F);
            txtStudentNumber.Location = new Point(43, 92);
            txtStudentNumber.Size = new Size(310, 26);

            lblFullName.Text = "Full Name";
            lblFullName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFullName.Location = new Point(43, 132);
            lblFullName.AutoSize = true;

            txtFullName.Font = new Font("Segoe UI", 10.5F);
            txtFullName.Location = new Point(43, 154);
            txtFullName.Size = new Size(310, 26);

            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.Location = new Point(43, 194);
            lblPassword.AutoSize = true;

            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.Location = new Point(43, 216);
            txtPassword.Size = new Size(310, 26);
            txtPassword.UseSystemPasswordChar = true;

            lblConfirm.Text = "Confirm Password";
            lblConfirm.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblConfirm.Location = new Point(43, 256);
            lblConfirm.AutoSize = true;

            txtConfirmPassword.Font = new Font("Segoe UI", 10.5F);
            txtConfirmPassword.Location = new Point(43, 278);
            txtConfirmPassword.Size = new Size(310, 26);
            txtConfirmPassword.UseSystemPasswordChar = true;

            btnRegister.Text = "Register Account";
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.BackColor = Color.DarkRed;
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(43, 328);
            btnRegister.Size = new Size(310, 38);
            btnRegister.Click += btnRegister_Click;

            btnBack.Text = "Back to Login";
            btnBack.Font = new Font("Segoe UI", 9.5F);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Location = new Point(43, 376);
            btnBack.Size = new Size(310, 35);
            btnBack.Click += btnBack_Click;

            Controls.Add(lblTitle);
            Controls.Add(lblStudentNumber);
            Controls.Add(txtStudentNumber);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblConfirm);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnBack);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}