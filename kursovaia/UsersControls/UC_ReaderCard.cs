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

namespace kursovaia.UsersControls
{
    public partial class UC_ReaderCard : UserControl
    {
        public UC_ReaderCard()
        {
            InitializeComponent();
        }


        public void LoadUserReservations()
        {
            int userId = Login.User.UserId; // Получаем userId текущего пользователя
            DataTable reservations = GetReservationsByUserId(userId);

            // Создаем главный контейнер для панелей
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, // Занимает всю ширину и высоту UC_ReaderCard
                AutoScroll = true, // Включаем прокрутку
                FlowDirection = FlowDirection.TopDown, // Выстраиваем элементы сверху вниз
                WrapContents = true // Запрещаем перенос содержимого
            };

            // Перебираем каждую запись и создаем панель
            foreach (DataRow row in reservations.Rows)
            {
                // Создаем панель для каждой записи
                Panel reservationPanel = new Panel
                {
                    Width = 700,
                    Height = 80, // Увеличиваем высоту для удобства отображения
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                // Формируем строку с данными для показа пользователю
                var userFullName = $"{row["first_name"]} {row["last_name"]}";
                var bookTitle = row["title"].ToString();

                Label titleLabel = new Label
                {
                    Text = $"Книга: \"{bookTitle}\" забронирована пользователем: {userFullName}",
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Century Gothic", 10)

                };

                // Добавляем Label на панель
                reservationPanel.Controls.Add(titleLabel);

                // Создаем кнопку "Отменить бронирование"
                Button cancelButton = new Button
                {
                    Text = "Отменить бронирование",
                    
                    Width = 200,
                    Height = 40,
                    Font = new Font("Century Gothic", 10)
                };
                cancelButton.Location = new Point(reservationPanel.Width - cancelButton.Width - 10, reservationPanel.Height - cancelButton.Height - 10);

                // Добавляем обработчик события для кнопки
                cancelButton.Click += (sender, e) =>
                {
                    int reservationId = Convert.ToInt32(row["reservation_id"]);
                    CancelReservation(reservationId);
                    LoadUserReservations(); // Обновляем отображение
                };

                // Добавляем кнопку на панель
                reservationPanel.Controls.Add(cancelButton);

                // Добавляем панель с записью в FlowLayoutPanel
                flowLayoutPanel.Controls.Add(reservationPanel);
            }

            // Очищаем текущие панели и добавляем новую
            this.Controls.Clear();
            this.Controls.Add(flowLayoutPanel);
        }

        private void CancelReservation(int reservationId)
        {
            // SQL-запрос для удаления записи
            string query = "DELETE FROM reservation WHERE reservation_id = @reservationId";

            using (OleDbConnection connection = new OleDbConnection(Login.s))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reservationId", reservationId);
                    connection.Open(); // Открыть соединение
                    command.ExecuteNonQuery(); // Выполнить команду
                    connection.Close(); // Закрыть соединение
                }
            }
        }



        public DataTable GetReservationsByUserId(int userId)
        {
            DataTable reservationsTable = new DataTable();

            // SQL-запрос для извлечения записей
            string query = @"
        SELECT r.reservation_id, b.title, u.first_name, u.last_name 
        FROM (reservation r 
        INNER JOIN books b ON r.book_id = b.book_id) 
        INNER JOIN users u ON r.user_id = u.user_id 
        WHERE r.user_id = @userId";

            using (OleDbConnection connection = new OleDbConnection(Login.s))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(reservationsTable);
                    }
                }
            }

            return reservationsTable;
        }
    }
}
