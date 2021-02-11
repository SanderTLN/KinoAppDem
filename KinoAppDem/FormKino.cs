using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            Text = "Hall";
            for (i = 0; i < i_; i++)
            {
                for (j = 0; j < j_; j++)
                {
                    _arr[i, j] = new Label();
                    _arr[i, j].BackColor = Color.DarkGreen;
                    _arr[i, j].Text = "Place " + (j + 1);
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
            btnB.Text = "Back";
            btnB.Size = new Size(80, 30);
            btnB.Location = new Point(j * 55, i * 56);
            btnB.Click += BtnB_Click;
            Controls.Add(btnB);
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            FormFilm films = new FormFilm();
            films.Show();
            Hide();
        }

        private void FormKino_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var tag = (int[])label.Tag;
            if(_arr[tag[0], tag[1]].Text != "Selected" && _arr[tag[0], tag[1]].Text != "Booked")
            {
                _arr[tag[0], tag[1]].Text = "Selected";
                _arr[tag[0], tag[1]].BackColor = Color.DarkOrange;
            }
            else if(_arr[tag[0], tag[1]].Text == "Selected")
            {
                if(MessageBox.Show("Are you sure you want to book this place?", "Booking", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FormTicket ticket = new FormTicket();
                    ticket.Show();
                    //_arr[tag[0], tag[1]].Text = "Booked";
                    //_arr[tag[0], tag[1]].BackColor = Color.DarkRed;
                    //MessageBox.Show("Row: " + (tag[0] + 1) + ", place: " + (tag[1] + 1) + " - successfully booked!");
                }
                else
                {
                    _arr[tag[0], tag[1]].Text = "Place " + (tag[1] + 1);
                    _arr[tag[0], tag[1]].BackColor = Color.DarkGreen;
                }
            }
            else if(_arr[tag[0], tag[1]].Text == "Booked")
            {
                MessageBox.Show("Row: " + (tag[0] + 1) + ", Place: " + (tag[1] + 1) + " - is already booked!");
            }
            else
            {
                MessageBox.Show("Error 404");
            }
        }
    }
}
