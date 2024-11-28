using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace kursovaia
{
    public partial class Login : Form
    {
        public static string s = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kursovayaBiblioteka1.mdb;";
        private readonly OleDbConnection connect = new OleDbConnection(s);



        public Login()
        {
            InitializeComponent();
        }




        public class User
        {
            public static int UserId { get; set; }
            public static string LastName { get; set; }
            public static string FirstName { get; set; }
            public static string MiddleName { get; set; }
            public static string Phone { get; set; }
            public static string Mail { get; set; }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string mail = TextLogin.Text;
            string password = TextPassword.Text;


            string role = ValidateUser(mail, password);

            // Перенаправление в зависимости от роли
            if (!string.IsNullOrEmpty(role))
            {
                GetUserInfo(mail);
                MessageBox.Show($"Добро пожаловать, {User.FirstName}!\nВаша роль: {role}");
                OpenFormByRole(role);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void GetUserInfo(string mail)
        {
            string query = "SELECT [user_id], [first_name], [middle_name], [last_name], [phone] FROM users WHERE mail = @mail";

            using (OleDbConnection connect = new OleDbConnection(s))
            {
                using (OleDbCommand command = new OleDbCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@mail", mail);
                    try
                    {
                        connect.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User.UserId = (int)reader["user_id"];
                                User.FirstName = reader["first_name"].ToString();
                                User.MiddleName = reader["middle_name"].ToString();
                                User.LastName = reader["last_name"].ToString();
                                User.Phone = reader["phone"].ToString();
                                User.Mail = mail;
                            }
                        }
                        connect.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}");
                    }
                }
            }
        }





        private string ValidateUser(string mail, string password)
        {
            string role = null;

            string hashedPassword = HashHelper.ComputeHash(password);

            string query = "SELECT [role] FROM users WHERE mail = @mail AND password = @password";

            {
                using (OleDbCommand command = new OleDbCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    try
                    {
                        connect.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            role = result.ToString();
                            
                        }
                        connect.Close() ;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}");
                    }
                }
            }

            return role;
        }



        private void OpenFormByRole(string role)
        {
            Form nextForm;

            switch (role)
            {
                case "Администратор":
                    nextForm = new AdminForm(this);
                    break;
                case "Читатель":
                    nextForm = new ClientForm(this);
                    break;
                default:
                    nextForm = new MainForm();
                    break;
            }

            this.Hide();
            nextForm.Show();
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();

            registrationForm.ShowDialog(); 
        }


        public static class HashHelper
        {
            public static string ComputeHash(string input)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
