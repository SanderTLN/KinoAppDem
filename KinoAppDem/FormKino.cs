using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoAppDem
{
    public partial class FormKino : Form
    {
        int i, j;
        Label[,] _arr;
        Button btnB;
        public FormKino(int i_, int j_)
        {
            _arr = new Label[i_, j_];
            Size = new Size(i_ * 60 + 80, j_ * 55 + 80);
            Text = "Зал";
            for (i = 0; i < i_; i++)
            {
                for (j = 0; j < j_; j++)
                {
                    _arr[i, j] = new Label();
                    _arr[i, j].BackColor = Color.DarkGreen;
                    _arr[i, j].Text = "Сиденье " + (j + 1);
                    _arr[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    _arr[i, j].Size = new Size(55, 55);
                    _arr[i, j].BorderStyle = BorderStyle.Fixed3D;
                    _arr[i, j].Location = new Point(j * 55 + 45, i * 55);
                    Controls.Add(_arr[i, j]);
                    _arr[i, j].Tag = new int[] { i, j };
                    _arr[i, j].Click += new System.EventHandler(FormKino_Click);
                }
            }

            btnB = new Button();
            btnB.Text = "Назад";
            btnB.Size = new Size(80, 30);
            btnB.Location = new Point(j * 55, i * 56);
            btnB.Click += BtnB_Click;
            Controls.Add(btnB);
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            back.Show();
            Hide();
        }

        private void FormKino_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var tag = (int[])label.Tag;
            if(_arr[tag[0], tag[1]].Text != "Выбрано" && _arr[tag[0], tag[1]].Text != "Забронировано")
            {
                _arr[tag[0], tag[1]].Text = "Выбрано";
                _arr[tag[0], tag[1]].BackColor = Color.DarkOrange;
            }
            else if(_arr[tag[0], tag[1]].Text == "Выбрано")
            {
                if(MessageBox.Show("Вы уверены что хотите забронировать данное место?", "Бронирование", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FormTicket ticket = new FormTicket();
                    ticket.Show();
                    //_arr[tag[0], tag[1]].Text = "Забронировано";
                    //_arr[tag[0], tag[1]].BackColor = Color.DarkRed;
                    //MessageBox.Show("Ряд: " + (tag[0] + 1) + ", Сиденье: " + (tag[1] + 1) + " - успешно забронировано!");
                }
                else
                {
                    _arr[tag[0], tag[1]].Text = "Сиденье " + (tag[1] + 1);
                    _arr[tag[0], tag[1]].BackColor = Color.DarkGreen;
                }
            }
            else if(_arr[tag[0], tag[1]].Text == "Забронировано")
            {
                MessageBox.Show("Ряд: " + (tag[0] + 1) + ", Сиденье: " + (tag[1] + 1) + " - уже занято!");
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
