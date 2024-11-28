using kursovaia.UsersControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace kursovaia
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            UC_UserData uc = new UC_UserData();
            addUserConrol(uc);

        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
           
        }
        private void addUserConrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void UserDataButton_Click(object sender, EventArgs e)
        {
            UC_UserData uc_ud = new UC_UserData();

            addUserConrol(uc_ud);
          
        }

        private void ReaderCardButton_Click(object sender, EventArgs e)
        {
            UC_ReaderCard uc_rc = new UC_ReaderCard();
            uc_rc.LoadUserReservations();
            addUserConrol(uc_rc);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
