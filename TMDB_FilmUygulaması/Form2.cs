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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TMDB_FilmUygulaması
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-7EA7R1P;Database=TMDB_FilmTavsiyesi;Trusted_Connection=True;");
        SqlDataAdapter dap;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert RECOMMENDATION( FilmAdi,Yorum,Puan ) VALUES (@filmadi,@yorum,@puan)\r\n";
            
            SqlCommand cmd2 = new SqlCommand(sorgu2, conn);

            cmd2.Parameters.AddWithValue("@filmadi", textBox1.Text);
            cmd2.Parameters.AddWithValue("@yorum", textBox3.Text);
            cmd2.Parameters.AddWithValue("@puan", textBox2.Text);


            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("İşlemBaşarılı");
            }
            else
            {
                conn.Close();
            }
        }
    }
}
