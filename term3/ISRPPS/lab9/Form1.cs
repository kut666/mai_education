using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISRPPS_lab9
{
    public partial class Form1 : Form
    {
        public static Form1 instance { get; } = new Form1();
        private Form1()
        {
            InitializeComponent();
        }
        
       public string textBox_1
        {
            set
            {
                textBox1.Text = value;
            }
        }

        public int a = 0;
        public int b = 0;
        User user = new User();
        

        

        private void Button3_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out b);
            user.Compute(Convert.ToChar(((Button)sender).Text), b);
        }

      
      
        private void Button7_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out a);
            user._calculator.curr = a;
        }


        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

            user.Undo(0);
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            user.Redo(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
