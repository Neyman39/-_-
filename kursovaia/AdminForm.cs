using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaia
{
    public partial class AdminForm : Form
    {
        private Login mainForm;
        public AdminForm(Login form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
