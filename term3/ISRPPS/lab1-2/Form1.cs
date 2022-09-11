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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double s1, s2, s3;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                s1 = Convert.ToDouble(textBox1.Text);
                s2 = Convert.ToDouble(textBox2.Text);
                s3 = Convert.ToDouble(textBox3.Text);

                Parallelepiped P = new Parallelepiped(s1, s2, s3);

                label3.Text = "Площадь поверхности = " + (P.SurfaceArea()).ToString("f");
                label4.Text = "Обьём = " + (P.Volume()).ToString("f");
            }
            catch
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    MessageBox.Show("Введены не все ребра параллелепипеда");
                else
                {
                    DialogResult result = MessageBox.Show("Ошибка ввода.\n" + "Неверный формат данных.\n" + "Повторить?",
                                "Ошибка", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            label3.Text = "Площадь поверхности = ";
                            label4.Text = "Обьём = ";
                            break;
                        case DialogResult.No:
                            this.Close();
                            break;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение (название) было разработано на языке C# в среде разработки Microsoft Visual Studio версии 2017 года \n\n" +
                            "Автор программы Махмудов Орхан, студент группы М8О-205Б-18 \n\n" +
                            "Версия приложения: 1.0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            newform.Show();
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
            {
                s1 = Convert.ToDouble(textBox1.Text);
                s2 = Convert.ToDouble(textBox2.Text);
                s3 = Convert.ToDouble(textBox3.Text);

                Parallelepiped P = new Parallelepiped(s1, s2, s3);

                if (s1 >= 0 || s2 >= 0 || s3 >= 0)
                {

                    newform.label1.Text = "Для вычисления площади поверхности параллелепипеда(прямоугольного) \n " +
                              "мы используем формулу: S = 2*(a*b + a*c + b*c), где a,b,c стороны \n" +
                              "параллелепипеда подставляя введенные вами значения получим: \n " +
                              "S = 2*(" + textBox1.Text + "*" + textBox2.Text + " + " + textBox2.Text + "*" + textBox3.Text + " + " +
                               textBox1.Text + "*" + textBox3.Text + ")" + " = " + (P.SurfaceArea()).ToString("f") + "\n \n \n" +
                              "Для вычисления объём параллелепипеда (прямоугольного) \n" +
                              "мы используем формулу V = a * b * c, где a,b,c стороны \n" +
                              "параллелепипеда подставляя введенные вами значения получим: \n" +
                              "V =" + textBox1.Text + " * " + textBox2.Text + " * " + textBox3.Text + " = " + (P.Volume()).ToString("f") + "\n";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 newform = new Form3();
            newform.ShowDialog();
            MessageBox.Show("Вы поставили " + newform.Message +"\n" +
                            "Спасибо за вашу оценку, мы были рады вам помочь! ");
        }

    }
}
