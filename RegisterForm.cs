using System;
using System.Windows.Forms;
using Stivity.Data;

namespace Stivity
{
    public partial class RegisterForm : Form
    {
        private readonly StivityRepository _repo = new StivityRepository();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentNumber.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Password Mismatch",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool created = _repo.RegisterStudent(
                    txtStudentNumber.Text,
                    txtFullName.Text,
                    txtPassword.Text);

                if (created)
                {
                    MessageBox.Show("Account created successfully! You can now sign in.", "Registered",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("That student number is already registered.", "Duplicate Account",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error:\n{ex.Message}", "SQL Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}