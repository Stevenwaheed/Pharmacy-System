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
    public partial class LogIn : Form
    {
        string str = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PharmacyDatabase.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection Conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PharmacyDatabase.mdf;Integrated Security = True; Connect Timeout = 30");
        public static LogIn LogIninstance = new LogIn();
        public TextBox LogInUsername = new TextBox();
        public TextBox LogInPassword = new TextBox();
        public Button LogInAddNewUser = new Button();

        public LogIn()
        {
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = false;

            InitializeComponent();

            LogIninstance = this;
            LogInUsername = UserNametextBox;
            LogInPassword = PasswordtextBox;
            LogInAddNewUser = AddNewUser;

            WrongUsernamelabel.Visible = false;
            WrongPasswordlabel.Visible = false;
            NewUserpanel.Visible = false;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void LogInbutton_Click(object sender, EventArgs e)
        {
            Conn.Open();
            string UserName = "", Password = "";

            SqlCommand CMD = new SqlCommand("SELECT * FROM LogIn WHERE Username='" + UserNametextBox.Text + "' AND Password='"+ PasswordtextBox.Text + "'", Conn);

            SqlDataReader Read = CMD.ExecuteReader();
            while (Read.Read())
            {
                UserName = Read.GetValue(0).ToString();
                Password = Read.GetValue(1).ToString();
            }
            Conn.Close();

            if (UserNametextBox.Text == "" || PasswordtextBox.Text == "")
            {
                if (UserNametextBox.Text == "" || UserNametextBox.Text != "s" || UserName != UserNametextBox.Text)
                    WrongUsernamelabel.Visible = true;
                else
                    WrongUsernamelabel.Visible = false;


                if (PasswordtextBox.Text == "" || PasswordtextBox.Text != "123" || Password != PasswordtextBox.Text)
                    WrongPasswordlabel.Visible = true;
                else
                    WrongPasswordlabel.Visible = false;
            }
            else if ((PasswordtextBox.Text == "123" && UserNametextBox.Text == "s") || (UserName == UserNametextBox.Text && Password == PasswordtextBox.Text))
            {
                    Main_page form = new Main_page();
                    form.Show();
                    this.Hide();
            }
        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            NewUserpanel.Visible = true;
            LogInpanel.Visible = false;
            AddNewUser.Visible = false;
            LogInbutton.Visible = false;
            Createbutton.Visible = true;
            Backbutton.Visible = true;
        }

        private void Createbutton_Click(object sender, EventArgs e)
        {
            if (AddNewUsertextBox.Text == "")
                AddWrongUserlabel.Visible = true;
            else
                AddWrongUserlabel.Visible = false;

            if (NewPasstextBox.Text == "")
                AddWrongPasslabel.Visible = true;
            else
                AddWrongPasslabel.Visible = false;

            if (ConfirmtextBox.Text == "")
                Confirmlabel.Visible = true;
            else
                Confirmlabel.Visible = false;

            if (ConfirmtextBox.Text != NewPasstextBox.Text)
                NotMatchlabel.Visible = true;
            else
                NotMatchlabel.Visible = false;

            if (AddNewUsertextBox.Text != "" && NewPasstextBox.Text != "" && ConfirmtextBox.Text != "" && ConfirmtextBox.Text == NewPasstextBox.Text)
            {
                try 
                { 
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO LogIn(Username, Password) VALUES(@Username, @Password)", conn);
                        cmd.Parameters.AddWithValue("@Username", AddNewUsertextBox.Text);
                        cmd.Parameters.AddWithValue("@Password", NewPasstextBox.Text);
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        MessageBox.Show("Created Successfully");

                        AddNewUsertextBox.Clear();
                        NewPasstextBox.Clear();
                        ConfirmtextBox.Clear();
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                    Conn.Close();
                }
            }
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            NewUserpanel.Visible = false;
            LogInpanel.Visible = true;
            AddNewUser.Visible = true;
            LogInbutton.Visible = true;
            Createbutton.Visible = false;
            Backbutton.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
