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

namespace TMDB_FilmUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-7EA7R1P;Database=TMDB_FilmTavsiyesi;Trusted_Connection=True;");
        SqlDataAdapter dap;
        private void Form1_Load(object sender, EventArgs e)
        {
            dap = new SqlDataAdapter("select M.TITLE,G.GENRE,M.ADULT,M.FILMID from MOVIE M\r\nINNER JOIN MOVIE_GENRE MG ON MG.FILMID = M.FILMID\r\nINNER JOIN  GENRE G ON G.GENREID = MG.GENREID", conn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = string.Format("CONVERT({0},System.String) LIKE '%{1}%' ", dataGridView1.Columns[3].DataPropertyName, textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }
    }
}
