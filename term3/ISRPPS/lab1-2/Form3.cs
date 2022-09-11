using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private string message = null;

        public string Message
        {
            get { return message; }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            message = textBox1.Text;
            Close();
        }
    }
}

