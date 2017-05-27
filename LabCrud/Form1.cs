using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            Student student = new LabCrud.Student(Convert.ToInt32(id.Text),name.Text, surname.Text, birthDate.Value, email.Text, graduate.Checked);
            student.Insert();
        }

     


    }
}
