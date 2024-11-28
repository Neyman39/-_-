using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;

namespace kursovaia
{
    public partial class RegistrationForm : Form
    {
        private readonly OleDbConnection connect = new OleDbConnection(Login.s);

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click_1(object sender, EventArgs e)
        {
            string lastName = textLastName.Text;
            string firstName = textFirstName.Text;
            string middleName = textMiddleName.Text;
            string phone = textPhone.Text.Replace(" ", "").Replace("-", "");
            string mail = textMail.Text;
            string password = textPassword.Text;
            string confirmPassword = textConfirmPassword.Text;



            if (string.IsNullOrWhiteSpace(lastName) ||
                       string.IsNullOrWhiteSpace(firstName) ||
                       string.IsNullOrWhiteSpace(mail) ||
                       string.IsNullOrWhiteSpace(password) ||
                       string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают. Пожалуйста, попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RegisterUser(lastName, firstName, middleName, phone, mail, password))
            {
                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации. Возможно, такой пользователь уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }










        private bool RegisterUser(string lastName, string firstName, string middleName, string phone, string mail, string password)
        {

            if (UserExists(mail))
            {
                MessageBox.Show("Пользователь с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
               
            }

            string hashedPassword = HashPassword(password);
            string query = "INSERT INTO users ([role], [last_name], [first_name], [middle_name], [phone], [mail], [password]) VALUES(@role, @last_name, @first_name, @middle_name, @phone, @mail, @password)";

            using (OleDbCommand command = new OleDbCommand(query, connect))
            {
                command.Parameters.AddWithValue("@role", "Читатель");
                command.Parameters.AddWithValue("@last_name", lastName);
                command.Parameters.AddWithValue("@first_name", firstName);
                command.Parameters.AddWithValue("@middle_name", middleName);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@password", hashedPassword);

                try
                {
                    connect.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Если запись добавлена, возвращаем true
                }
                catch (Exception)
                {
                    return false; // Если произошла ошибка, возвращаем false 
                }
                finally
                {
                    connect.Close();
                }
            }
        }











        private bool UserExists(string mail)
        {
            string query = "SELECT COUNT(*) FROM users WHERE mail = @mail";

            using (OleDbCommand command = new OleDbCommand(query, connect))
            {
                command.Parameters.AddWithValue("@mail", mail);

                try
                {
                    connect.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
                finally
                {
                    connect.Close();
                }
            }
        }









        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Преобразуем строку в байты и вычисляем хэш
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Преобразуем байты в строку шестнадцатеричного формата
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }









        private void label1_Click(object sender, EventArgs e)
        {
            textPhone.Mask = "+7 (999) 000-0000";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
