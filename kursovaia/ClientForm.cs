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
using System.Data.SqlClient;

namespace kursovaia
{
    public partial class ClientForm : Form
    {
        private Login mainForm;
        public ClientForm(Login form)
        {
            InitializeComponent();
            mainForm = form;
        }


        private readonly OleDbConnection connect = new OleDbConnection(Login.s);
        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadingForm();
            LoadGenres();
            LoadAuthors();
            searchTextBox.KeyPress += new KeyPressEventHandler(searchTextBox_KeyPress);
        }

        private void LoadingForm()
        {
            flowLayoutPanel1.Controls.Clear();

            string query = @"
                    SELECT b.title,
                        b.book_id,
                        b.description, 
                        G.[genre_name],
                        A.[first_name] & "" "" & A.[middle_name] & "" "" & A.[last_name] AS authors
                    FROM (books B
                    INNER JOIN authors A ON B.author_id = A.author_id)
                    INNER JOIN genre G ON B.genre_id = G.genre_id
                    ORDER BY b.title;";

            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CreateBookCard(reader);
            }
            reader.Close();
            connect.Close();
        }

        private void CreateBookCard(OleDbDataReader reader)
        {
            
            Panel bookCard = new Panel
            {
                Width = flowLayoutPanel1.ClientSize.Width - 40,
                
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Заголовок книги
            Label titleLabel = new Label
            {
                Text = $"{reader["Title"].ToString()}, {reader["genre_name"].ToString()} ",
                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Автор книги
            Label authorLabel = new Label
            {
                Text = "Автор: " + reader["Authors"].ToString(),
                Location = new Point(10, 40),
                AutoSize = true,
                Font = new Font("Century Gothic", 10)
            };

            // Описание книги
            Label descriptionLabel = new Label
            {
                Text = reader["Description"].ToString(),
                Location = new Point(10, 70),
                AutoSize = false,
                Width = bookCard.Width - 20,
                Font = new Font("Century Gothic", 10),
                MaximumSize = new Size(bookCard.Width - 20, 0), 
            };

            using (Graphics graphics = bookCard.CreateGraphics())
            {
                SizeF descriptionSize = graphics.MeasureString(descriptionLabel.Text, descriptionLabel.Font, descriptionLabel.Width);
                descriptionLabel.Height = (int)descriptionSize.Height + 10; 
            }

            bookCard.Height = 100 + descriptionLabel.Height + 10;

            // Кнопка "Зарезервировать"
            Button reserveButton = new Button
            {
                Text = "Забронировать",
                Size = new Size(180, 30),
                Tag = reader["book_id"], // Сохраняем book_id в тег кнопки
                Cursor = Cursors.Hand,
                Font = new Font("Century Gothic", 10)
            };
            reserveButton.Click += ReserveButton_Click;

            reserveButton.Location = new Point(bookCard.Width - reserveButton.Width - 10, bookCard.Height - reserveButton.Height - 10);

            bookCard.Controls.Add(titleLabel);
            bookCard.Controls.Add(authorLabel);
            bookCard.Controls.Add(descriptionLabel);
            bookCard.Controls.Add(reserveButton);
            
            flowLayoutPanel1.Controls.Add(bookCard);
        }


        private bool IsBookReserved(int bookId)
        {
            string query = "SELECT COUNT(*) FROM reservation WHERE book_id = @bookId";
            using (OleDbConnection connection = new OleDbConnection(Login.s))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bookId", bookId);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        //Загрузка жанров
        public void LoadGenres()
        {
            using (OleDbConnection connect = new OleDbConnection(Login.s))
            {
                connect.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT genre_name FROM genre", connect))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        genreComboBox.Items.Clear();
                        while (reader.Read())
                        {
                            genreComboBox.Items.Add(reader["genre_name"].ToString());
                        }
                        genreComboBox.Items.Add("");
                    }
                }
            }
        }

        //Загрузка авторов
        public void LoadAuthors()
        {
            using (OleDbConnection connect = new OleDbConnection(Login.s))
            {
                connect.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT first_name, last_name FROM authors", connect))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        authorComboBox.Items.Clear();
                        while (reader.Read())
                        {
                            string fullName = $"{reader["first_name"]} {reader["last_name"]}";
                            authorComboBox.Items.Add(fullName);
                        }
                        authorComboBox.Items.Add("");
                    }
                }
            }
        }

        //Фильтрация
        public void FilterBooks()
        {
            flowLayoutPanel1.Controls.Clear();
            var genre = genreComboBox.SelectedItem?.ToString();
            var author = authorComboBox.SelectedItem?.ToString();
            var searchQuery = searchTextBox.Text;

            string sql = @"
                    SELECT b.title,
                        b.book_id,
                        b.description, 
                        G.[genre_name],
                        A.[first_name] & "" "" & A.[middle_name] & "" "" & A.[last_name] AS authors
                    FROM (books B
                    INNER JOIN authors A ON B.author_id = A.author_id)
                    INNER JOIN genre G ON B.genre_id = G.genre_id
                    WHERE 1=1";

            //string sql = "SELECT * FROM books";

            if (!string.IsNullOrEmpty(genre))
            {
                sql += " AND [genre_name] = @genre";
            }
            if (!string.IsNullOrEmpty(author))
            {
                sql += @" AND A.[first_name] & "" "" & A.[last_name] = @fullName";
            }
            if (!string.IsNullOrEmpty(searchQuery))
            {
                sql += " AND title LIKE @search";
            }
            sql += " ORDER BY b.title";

            using (OleDbConnection connection = new OleDbConnection(Login.s))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                if (!string.IsNullOrEmpty(genre))
                {
                    command.Parameters.AddWithValue("@genre", genre);
                }
                if (!string.IsNullOrEmpty(author))
                {
                    command.Parameters.AddWithValue("@fullName", author);
                }
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    command.Parameters.AddWithValue("@search", $"{searchQuery}%");
                }

                // Здесь выполните команду и отображение результатов
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CreateBookCard(reader);
                }
            }
        }

        private void ReserveButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int bookId = Convert.ToInt32(button.Tag);

                
                if (IsBookReserved(bookId))
                {
                    string userName = GetUserNameByBookId(bookId);
                    MessageBox.Show($"Эта книга уже забронирована пользователем: {userName}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                AddReservation(bookId);
            }
        }


        public string GetUserNameByBookId(int bookId)
        {
            string userName = string.Empty;

            string query = @"
        SELECT u.first_name, u.last_name 
        FROM reservation r
        INNER JOIN users u ON r.user_id = u.user_id 
        WHERE r.book_id = @bookId";

            using (OleDbConnection connection = new OleDbConnection(Login.s))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bookId", bookId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userName = $"{reader["first_name"]} {reader["last_name"]}";
                        }
                    }
                    connect.Close();
                }
            }
            return userName;
        }


        public void AddReservation(int bookId)
        {
            int userId = Login.User.UserId;
           // DateTime dateOfReservation = DateTime.Now;
            string query = "INSERT INTO reservation (book_id, user_id, status) " +
                   "VALUES (@bookId, @userId, @status)";
            using (OleDbConnection connection = new OleDbConnection(Login.s))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@bookId", bookId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@status", "Reserved"); 

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Книга успешно зарезервирована!");
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при резервировании книги: " + ex.Message);
                    }
                }
            }
        }

        
        private void pictureAccount_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            this.Hide();
            accountForm.ShowDialog();
            this.Show();
        }

        private void buttonCloseCF_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterBooks();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            genreComboBox.SelectedItem = null;
            authorComboBox.SelectedItem = null;
            LoadingForm();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterBooks();
        }

        // Запрет на ввод английских символов в поисковую строку
        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
            {
                e.Handled = true;
            }
        }
    }
}
