using System;
using System.Windows.Forms;
using Stivity.Data;
using Stivity.Models;

namespace Stivity
{
    public partial class LoginForm : Form
    {
        private readonly StivityRepository _repo = new StivityRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentNumber.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both your student number and password.", "Missing Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Student? student = _repo.Login(txtStudentNumber.Text, txtPassword.Text);
                if (student != null)
                {
                    MessageBox.Show(
                        $"Login Successful!\n\nWelcome, {student.FullName}!\nStudent Number: {student.StudentNumber}",
                        "Stivity - Authenticated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid student number or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error:\n{ex.Message}", "SQL Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoToRegister_Click(object? sender, EventArgs e)
        {
            Hide();
            using var regForm = new RegisterForm();
            regForm.ShowDialog();
            Show();
        }
    }
}