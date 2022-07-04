using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pharmacy
{
    public partial class BackUp : Form
    {
        string str = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PharmacyDatabase.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection Conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PharmacyDatabase.mdf;Integrated Security = True; Connect Timeout = 30");


        public BackUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conn.Open();
            string database = Conn.Database.ToString();

            try
            {
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand command1 = new SqlCommand(str1, Conn);
                command1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK = '" + RestoreLocationtextBox.Text + "' WITH REPLACE;";
                SqlCommand command2 = new SqlCommand(str2, Conn);
                command2.ExecuteNonQuery();

                string str3 = "ALTER DATABASE [" + database + "] SET MULTI_USER";
                SqlCommand command3 = new SqlCommand(str3, Conn);
                command3.ExecuteNonQuery();

                
                MessageBox.Show("Database restore done successfully");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            Conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main_page form = new Main_page();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();

            if (dig.ShowDialog() == DialogResult.OK)
            {
                RestoreLocationtextBox.Text = dig.FileName;
            }
        }
    }
}
