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
    public partial class FormFilm : Form
    {
        Button btn1, btn2, btn3;
        Label lbl1, lbl2, lbl3;
        ComboBox cBox;
        SqlDataAdapter Film_adapter;
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\AppData\DataKino.mdf; Integrated Security = True");
        public FormFilm()
        {
            Height = 350;
            Width = 800;
            Text = "Film select";
            BackColor = Color.Wheat;
            connection.Open();
            Film_adapter = new SqlDataAdapter("SELECT Genre FROM Film", connection);
            DataTable films_table = new DataTable();
            Film_adapter.Fill(films_table);

            btn1 = new Button();
            btn1.Size = new Size(200, 200);
            btn1.Location = new Point(30, 50);
            btn1.BackgroundImage = Image.FromFile(@"C:\Users\opilane\source\repos\Demihhovski\KinoAppDem\KinoAppDem\Images\Terminator.png");
            btn1.BackgroundImageLayout = ImageLayout.Stretch;
            btn1.Click += Btn1_Click;
            Controls.Add(btn1);

            btn2 = new Button();
            btn2.Size = new Size(200, 200);
            btn2.Location = new Point(290, 50);
            btn2.BackgroundImage = Image.FromFile(@"C:\Users\opilane\source\repos\Demihhovski\KinoAppDem\KinoAppDem\Images\FastFurious.png");
            btn2.BackgroundImageLayout = ImageLayout.Stretch;
            btn2.Click += Btn2_Click;
            Controls.Add(btn2);

            btn3 = new Button();
            btn3.Size = new Size(200, 200);
            btn3.Location = new Point(550, 50);
            btn3.BackgroundImage = Image.FromFile(@"C:\Users\opilane\source\repos\Demihhovski\KinoAppDem\KinoAppDem\Images\Transformers.png");
            btn3.BackgroundImageLayout = ImageLayout.Stretch;
            btn3.Click += Btn3_Click;
            Controls.Add(btn3);

            lbl1 = new Label();
            lbl1.Text = "Terminator";
            lbl1.Size = new Size(70, 20);
            lbl1.Location = new Point(100, 270);
            Controls.Add(lbl1);

            lbl2 = new Label();
            lbl2.Text = "Fast and Furious";
            lbl2.Size = new Size(90, 20);
            lbl2.Location = new Point(350, 270);
            Controls.Add(lbl2);

            lbl3 = new Label();
            lbl3.Text = "Transformers";
            lbl3.Size = new Size(70, 20);
            lbl3.Location = new Point(620, 270);
            Controls.Add(lbl3);

            cBox = new ComboBox();
            cBox.Size = new Size(180, 20);
            cBox.Location = new Point(350, 20);
            foreach (DataRow row in films_table.Rows)
            {
                cBox.Items.Add(row["Genre"]);
            }
            connection.Close();
            cBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cBox.SelectedIndex = 0;
            Controls.Add(cBox);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Form1 kino = new Form1();
            kino.Show();
            kino.Text = "Transformers";
            Hide();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Form1 kino = new Form1();
            kino.Show();
            kino.Text = "Fast and Furious";
            Hide();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Form1 kino = new Form1();
            kino.Show();
            kino.Text = "Terminator";
            Hide();
        }
    }
}
