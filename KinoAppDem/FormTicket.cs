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
            Text = "Purchase";
            BackColor = Color.Wheat;

            lblM = new Label();
            lblM.Text = "Name:";
            lblM.Size = new Size(40, 20);
            lblM.Location = new Point(10, 20);
            Controls.Add(lblM);

            lblP = new Label();
            lblP.Text = "Email:";
            lblP.Size = new Size(40, 20);
            lblP.Location = new Point(10, 63);
            Controls.Add(lblP);

            txtM = new TextBox();
            txtM.Size = new Size(140, 20);
            txtM.Location = new Point(50, 17);
            Controls.Add(txtM);

            txtP = new TextBox();
            txtP.Size = new Size(140, 20);
            txtP.Location = new Point(50, 60);
            Controls.Add(txtP);

            btn = new Button();
            btn.Text = "Buy";
            btn.Size = new Size(70, 80);
            btn.Location = new Point(200, 10);
            btn.BackColor = Color.LightGray;
            btn.Click += Btn_Click;
            Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
