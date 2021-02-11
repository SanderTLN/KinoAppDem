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
    public partial class Form1 : Form
    {
        int i, j;
        Button btnC, btnB;
        ComboBox cBox;
        ListBox lBox;
        SqlCommand cmd;
        SqlDataAdapter Hall_adapter;
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\AppData\DataKino.mdf; Integrated Security = True");
        public Form1()
        {
            Height = 500;
            Width = 350;
            Text = "Выбор зала";
            connection.Open();
            Hall_adapter = new SqlDataAdapter("SELECT HallName FROM Halls", connection);
            DataTable halls_table = new DataTable();
            Hall_adapter.Fill(halls_table);
            

            cBox = new ComboBox();
            cBox.Size = new Size(180, 20);
            cBox.Location = new Point(80, 60);
            foreach(DataRow row in halls_table.Rows)
            {
                cBox.Items.Add(row["HallName"]);
            }
            connection.Close();
            //cBox.Items.Add("Выберите зал...");
            //cBox.Items.Add("Маленький зал");
            //cBox.Items.Add("Средний зал");
            //cBox.Items.Add("Большой зал");
            cBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cBox.SelectedIndex = 0;
            Controls.Add(cBox);

            lBox = new ListBox();
            lBox.Size = new Size(180, 100);
            lBox.Location = new Point(80, 100);
            Controls.Add(lBox);

            btnC = new Button();
            btnC.Text = "Продолжить";
            btnC.Size = new Size(120, 40);
            btnC.Location = new Point(110, 400);
            btnC.Click += BtnC_Click;
            Controls.Add(btnC);

            btnB = new Button();
            btnB.Text = "Назад";
            btnB.Size = new Size(80, 30);
            btnB.Location = new Point(10, 10);
            btnB.Click += BtnB_Click;
            Controls.Add(btnB);
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            FormFilm films = new FormFilm();
            films.Show();
            Hide();
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            if(cBox.SelectedIndex == 1)
            {
                i = 5; j = 5;
                FormKino hall = new FormKino(i, j);
                hall.Show();
                Hide();
            }
            else if(cBox.SelectedIndex == 2)
            {
                i = 10; j = 10;
                FormKino hall = new FormKino(i, j);
                hall.Show();
                Hide();
            }
            else if (cBox.SelectedIndex == 3)
            {
                i = 15; j = 15;
                FormKino hall = new FormKino(i, j);
                hall.Show();
                Hide();
            }
        }
    }
}
