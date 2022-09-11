using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Немодальные окна работают одновременно с главным окном приложения,
// отображаются с помощью метода Show, при этом, если пользователь минимизирует или закрывает
// родительское окно, дочерние немодальные окна также минимизируются или закрываются.
// Они, как и модальные, создаются на базе классов, производных от  System.Windows.Form
// Свойства формы настраиваются иначе, чем свойства формы модального окна
//

namespace Немодальные_окна
{
    // Немодальное окно
    public partial class PropertyForm : Form
    {
        public PropertyForm()
        {
            InitializeComponent();
        }

        // Определение свойств формы немодального окна с именами SMTP, POP3

        public string SMTP
        {
            get
            {
                return textBoxSMTP.Text;
            }
            set
            {
                textBoxSMTP.Text = value;
            }
        }

        public string POP3
        {
            get
            {
                return textBoxPOP3.Text;
            }
            set
            {
                textBoxPOP3.Text = value;
            }
        }


        // Объявление события event событийный_делегат объект
        public event EventHandler ApplyHandler;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Если определен обработчик события, то он вызывается
            // Ему передается ссылка на дочернее окно и параметры события
            if (ApplyHandler != null)
                // Генерируем событие, обработчик для которого зарегистрирован в главном окне
                ApplyHandler(this, new EventArgs());
        }

       
    }
}
