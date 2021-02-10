using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoAppDem
{
    public partial class FormTicket : Form
    {
        Label lblM, lblP;
        TextBox txtM, txtP;
        Button btn;
        public FormTicket()
        {
            Height = 140;
            Width = 300;
            Text = "Покупка";

            lblM = new Label();
            lblM.Text = "Почта:";
            lblM.Size = new Size(50, 20);
            lblM.Location = new Point(10, 20);
            Controls.Add(lblM);

            lblP = new Label();
            lblP.Text = "Пароль:";
            lblP.Size = new Size(50, 20);
            lblP.Location = new Point(10, 60);
            Controls.Add(lblP);

            txtM = new TextBox();
            txtM.Size = new Size(120, 20);
            txtM.Location = new Point(60, 20);
            Controls.Add(txtM);

            txtP = new TextBox();
            txtP.Size = new Size(120, 20);
            txtP.Location = new Point(60, 60);
            Controls.Add(txtP);

            btn = new Button();
            btn.Text = "Купить";
            btn.Size = new Size(70, 80);
            btn.Location = new Point(200, 10);
            btn.Click += Btn_Click;
            Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
