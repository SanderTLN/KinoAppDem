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
        Label lblH, lblD, lblDT, lblS, lblST;
        Button btnC, btnB;
        ComboBox cBox;
        SqlCommand cmd, cmdh;
        SqlDataAdapter Hall_adapter, Film_adapter;
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\AppData\DataKino.mdf; Integrated Security = True");
        int[] row_list;
        int[] places_list;
        string cmdf;

        public Form1(string _cmd, string dis, string tim)
        {
            cmdf = _cmd;
            Height = 500;
            Width = 350;
            BackColor = Color.Wheat;
            connection.Open();
            Hall_adapter = new SqlDataAdapter("SELECT * FROM Halls", connection);
            DataTable halls_table = new DataTable();
            Hall_adapter.Fill(halls_table);

            lblH = new Label();
            lblH.Text = "Select a hall:";
            lblH.Size = new Size(70, 20);
            lblH.Location = new Point(35, 64);
            Controls.Add(lblH);

            cBox = new ComboBox();
            cBox.Size = new Size(180, 20);
            cBox.Location = new Point(105, 60);
            foreach(DataRow row in halls_table.Rows)
            {
                cBox.Items.Add(row["HallName"]);
            }

            row_list = new int[halls_table.Rows.Count];
            places_list = new int[halls_table.Rows.Count];
            int a = 0;
            foreach(DataRow row in halls_table.Rows)
            {
                row_list[a] = (int)row["Row"];
                places_list[a] = (int)row["Places"];
                a = a + 1;
            }
            connection.Close();
            cBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cBox.SelectedIndex = 0;
            Controls.Add(cBox);

            lblD = new Label();
            lblD.Text = "Description:";
            lblD.Size = new Size(70, 20);
            lblD.Location = new Point(35, 100);
            Controls.Add(lblD);

            lblDT = new Label();
            connection.Open();
            Film_adapter = new SqlDataAdapter("SELECT * FROM Film", connection);
            DataTable films_table = new DataTable();
            Film_adapter.Fill(films_table);
            cmd = new SqlCommand("SELECT Description FROM Film WHERE Name=" + _cmd, connection);
            lblDT.Text = dis;
            lblDT.Size = new Size(180, 150);
            lblDT.Location = new Point(105, 100);
            Controls.Add(lblDT);

            lblS = new Label();
            lblS.Text = "Session time:";
            lblS.Size = new Size(70, 20);
            lblS.Location = new Point(35, 250);
            Controls.Add(lblS);

            lblST = new Label();
            cmd = new SqlCommand("SELECT Session FROM Film WHERE Name=" + _cmd, connection);
            lblST.Text = tim;
            connection.Close();
            lblST.Size = new Size(70, 20);
            lblST.Location = new Point(105, 250);
            Controls.Add(lblST);

            btnC = new Button();
            btnC.Text = "Continue";
            btnC.Size = new Size(120, 40);
            btnC.Location = new Point(110, 400);
            btnC.BackColor = Color.LightGray;
            btnC.Click += BtnC_Click;
            Controls.Add(btnC);

            btnB = new Button();
            btnB.Text = "Back";
            btnB.Size = new Size(80, 30);
            btnB.Location = new Point(10, 10);
            btnB.BackColor = Color.LightGray;
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
            i = row_list[cBox.SelectedIndex];
            j = places_list[cBox.SelectedIndex];
            connection.Open();
            cmd = new SqlCommand("SELECT Id FROM Film WHERE Name=" + cmdf, connection);
            cmdh = new SqlCommand("SELECT Id FROM Halls WHERE HallName=" + cBox.SelectedItem.ToString(), connection);
            FormKino hall = new FormKino(i, j, cmd.ExecuteScalar().ToString(), cmdh.ExecuteScalar().ToString());
            hall.Show();
            hall.Text = cmdf + " " + cBox.SelectedItem.ToString() + " Hall";
            connection.Close();
            Hide();
        }
    }
}
