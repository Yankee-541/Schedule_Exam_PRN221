using Schedule_Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule_Exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbCourse.DisplayMember = "CourseDescription";
            cbCourse.ValueMember = "CourseId";
            AP2Context context = new AP2Context();
            var course = context.Courses.ToList();
            course.Insert(0, new Course { CourseId = 0, CourseDescription = "All course" });
            cbCourse.DataSource = course;
            cbCourse.SelectedIndex = 0;

            loadDataForDGV();

        }
        public void loadDataForDGV()
        {
            int courseId = Convert.ToInt32(cbCourse.SelectedValue);
            using (AP2Context context = new AP2Context())
            {
                if(courseId == 0)
                {
                    dataGridView1.DataSource = context.Courses.Select(x => new
                    {
                        CourseId = x.CourseId,
                        CourseDescription =x.CourseDescription,



                    }).ToList();
                }           
            }
        }
    }
}
