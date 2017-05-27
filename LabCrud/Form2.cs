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
    public partial class Form2 : Form
    {
        private int student_id;
        private int row;
        public Form2()
        {
            InitializeComponent();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            // Automatically generate the DataGridView columns.
            students_grid.AutoGenerateColumns = true;
            students_grid.DataSource = Student.GetAll();

            // Automatically resize the visible rows.
            students_grid.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            // Set the DataGridView control's border.
            students_grid.BorderStyle = BorderStyle.Fixed3D;

            //Put the cells in edit mode
            students_grid.EditMode = DataGridViewEditMode.EditOnEnter;

     
            students_grid.CellClick += new DataGridViewCellEventHandler(students_grid_CellClick);
        }

        public void students_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           student_id=Convert.ToInt32(students_grid[0, e.RowIndex].Value);
            row = e.RowIndex;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Student student = new Student(student_id);
            MessageBox.Show(student.ToString());
            student.Delete();

            //refresh grid
            students_grid.DataSource = Student.GetAll();
            students_grid.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Name, surname , emaili edir. qalanlarini ozunuz edersiz
            Student student = new LabCrud.Student(student_id);
            student.Name=students_grid.Rows[row].Cells["name"].Value.ToString();
            student.Surname = students_grid.Rows[row].Cells["surname"].Value.ToString();
            student.Email = students_grid.Rows[row].Cells["email"].Value.ToString();

            student.Update();

            //refresh grid
            students_grid.DataSource = Student.GetAll();
            students_grid.Refresh();

        }

        private void createnew_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
