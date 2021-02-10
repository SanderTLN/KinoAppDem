﻿using System;
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
    public partial class FormFilm : Form
    {
        Button btn1, btn2, btn3;
        public FormFilm()
        {
            Height = 400;
            Width = 800;
            Text = "Выбор фильма";

            btn1 = new Button();
            btn1.Size = new Size(200, 200);
            btn1.Location = new Point(30, 40);
            btn1.Click += Btn1_Click;
            Controls.Add(btn1);

            btn2 = new Button();
            btn2.Size = new Size(200, 200);
            btn2.Location = new Point(290, 40);
            btn2.Click += Btn2_Click;
            Controls.Add(btn2);

            btn3 = new Button();
            btn3.Size = new Size(200, 200);
            btn3.Location = new Point(550, 40);
            btn3.Click += Btn3_Click;
            Controls.Add(btn3);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Form1 kino = new Form1();
            kino.Show();
            Hide();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Form1 kino = new Form1();
            kino.Show();
            Hide();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Form1 kino = new Form1();
            kino.Show();
            Hide();
        }
    }
}
