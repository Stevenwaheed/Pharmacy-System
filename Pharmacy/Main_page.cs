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
    public partial class Main_page : Form
    {
        string str = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PharmacyDatabase.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection Conn = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PharmacyDatabase.mdf;Integrated Security = True; Connect Timeout = 30");
        double Total = 0;
        public static DataGridView data = new DataGridView();
        public static DateTimePicker Current_Date = new DateTimePicker();

        public Main_page()
        {
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = false;

            InitializeComponent();
            data = NewTermdataGridView;
            Current_Date = GetdateTimePicker;

            Getpanel.Visible = true;
            returnpanel.Visible = false;
            NewTermpanel.Visible = false;
            Bankpanel.Visible = false;
            Getpanel.BringToFront();

            if (LogIn.LogIninstance.LogInUsername.Text == "s" && LogIn.LogIninstance.LogInPassword.Text == "123")
            {
                AddNewbutton.Enabled = true;
            }
            else
            {
                AddNewbutton.Enabled = false;
            }
            
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Terms", Conn);    //select all data from table Notes to be shown in the datagridview
            DataTable Data = new DataTable();        // Display data in a tabluler form
            sqlDa.Fill(Data);
            NewTermdataGridView.DataSource = Data;

            sqlDa = new SqlDataAdapter("SELECT ID, Name, Price, Quantity, Date FROM Bank", Conn);    //select all data from table Notes to be shown in the datagridview
            Data = new DataTable();        // Display data in a tabluler form
            sqlDa.Fill(Data);
            BankdataGridView.DataSource = Data;

            Conn.Open();
            string query = "SELECT Name FROM Terms";      // select specific item from the database to be shown in the datagridview
            SqlCommand cmd = new SqlCommand(query, Conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GetTermNamecomboBox.Items.Insert(0, reader["Name"].ToString());
            }
            reader.Close();

            Conn.Close();

            AddBarcodetextBox.Focus();
            GetBarcodetextBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void NewTermbutton_Click(object sender, EventArgs e)
        {
            Getpanel.Visible = true;
            returnpanel.Visible = false;
            NewTermpanel.Visible = false;
            Bankpanel.Visible = false;
            Getpanel.BringToFront();
        }

        private void getbutton_Click(object sender, EventArgs e)
        {
            Getpanel.Visible = false;
            returnpanel.Visible = false;
            NewTermpanel.Visible = true;
            Bankpanel.Visible = false;
            NewTermpanel.BringToFront();
        }

        private void Bankbutton_Click(object sender, EventArgs e)
        {
            Getpanel.Visible = false;
            returnpanel.Visible = false;
            NewTermpanel.Visible = false;
            Bankpanel.Visible = true;
            Bankpanel.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Getpanel.Visible = false;
            returnpanel.Visible = true;
            NewTermpanel.Visible = false;
            Bankpanel.Visible = false;
            returnpanel.BringToFront();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LogIn form = new LogIn();
            LogIn.LogIninstance.LogInAddNewUser.Visible = true;
            form.Show();
            this.Hide();
        }

        private void AddNewTermbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Close();

                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Terms(Barcode, Name, Price, Quantity, Date) VALUES(@Barcode, @Name, @Price, @Quantity, @Date)", conn);  // insert notes in the database
                    cmd.Parameters.AddWithValue("@Barcode", AddBarcodetextBox.Text);
                    cmd.Parameters.AddWithValue("@Name", TermNametextBox.Text);
                    cmd.Parameters.AddWithValue("@Price", PricetextBox.Text);
                    cmd.Parameters.AddWithValue("@Quantity", QuantitytextBox.Text);
                    cmd.Parameters.AddWithValue("@Date", TermdateTimePicker.Text);
                    cmd.ExecuteNonQuery();

                    // GetTermNamecomboBox.Items.Insert(0, TermNametextBox.Text);


                    string query = "SELECT Name FROM Terms";      // select specific item from the database to be shown in the datagridview
                    cmd = new SqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();
                    GetTermNamecomboBox.Items.Clear();

                    while (reader.Read())
                    {
                        GetTermNamecomboBox.Items.Insert(0, reader["Name"].ToString());
                    }
                    reader.Close();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Terms", conn);    //select all data from table Notes to be shown in the datagridview
                    DataTable Data = new DataTable();         // Display data in a tabluler form
                    sqlDa.Fill(Data);
                    NewTermdataGridView.DataSource = Data;


                    if (NewTermdataGridView.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in NewTermdataGridView.Rows)
                        {
                            if (row.Cells[4].Value != null)
                            {
                                int Finish_Year = DateTime.Parse(row.Cells[5].Value.ToString()).Year;
                                int Finish_Month = DateTime.Parse(row.Cells[5].Value.ToString()).Month;

                                int Start_Year = GetdateTimePicker.Value.Year;
                                int Start_Month = GetdateTimePicker.Value.Month;

                                if (Finish_Month < Start_Month)
                                    Finish_Month += 12;

                                int diff = Finish_Month - Start_Month;

                                if (Finish_Year == Start_Year || Finish_Year - 1 == Start_Year)
                                {
                                    if (diff <= 3 && Finish_Year == Start_Year)
                                        row.DefaultCellStyle.BackColor = Color.Salmon;
                                    else if (Finish_Year > Start_Year)
                                    {
                                        if (diff <= 3 && Finish_Month - 12 > 0)
                                            row.DefaultCellStyle.BackColor = Color.Salmon;
                                        else
                                        {
                                            row.DefaultCellStyle.BackColor = SystemColors.Control;
                                        }
                                    }
                                    else
                                    {
                                        row.DefaultCellStyle.BackColor = SystemColors.Control;
                                    }
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = SystemColors.Control;
                                }
                            }
                        }
                    }
                    conn.Close();
                }
                AddBarcodetextBox.Clear();
                TermNametextBox.Clear();   // clear NoterichTextBox after entering data
                PricetextBox.Clear();
                QuantitytextBox.Clear();
                AddBarcodetextBox.Clear();
                GetBarcodetextBox.Clear();

                AddBarcodetextBox.Focus();
                GetBarcodetextBox.Focus();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void EditTermbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();

                int i = NewTermdataGridView.SelectedRows[0].Index;    //  Select the row from the datagridview
                string ID = NewTermdataGridView.Rows[i].Cells[0].Value.ToString();    //  Select the column from the datagridview

                string Query = "UPDATE Terms SET Name='" + this.TermNametextBox.Text + "', Price='" + this.PricetextBox.Text + "', Quantity=" + this.QuantitytextBox.Text + ", Date='" + this.TermdateTimePicker.Text + "' WHERE ID='" + ID + "'";  // update a specific row's Notes using the Serial_Number  
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                SqlCommand CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Terms", Conn);    //select all data from table Notes to be shown in the datagridview
                DataTable Data = new DataTable();        // Display data in a tabluler form
                sqlDa.Fill(Data);
                NewTermdataGridView.DataSource = Data;

                if (NewTermdataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in NewTermdataGridView.Rows)
                    {
                        if (row.Cells[4].Value != null)
                        {
                            int Finish_Year = DateTime.Parse(row.Cells[5].Value.ToString()).Year;
                            int Finish_Month = DateTime.Parse(row.Cells[5].Value.ToString()).Month;

                            int Start_Year = GetdateTimePicker.Value.Year;
                            int Start_Month = GetdateTimePicker.Value.Month;

                            if (Finish_Month < Start_Month)
                                Finish_Month += 12;

                            int diff = Finish_Month - Start_Month;

                            if (Finish_Year == Start_Year || Finish_Year - 1 == Start_Year)
                            {
                                if (diff <= 3 && Finish_Year == Start_Year)
                                    row.DefaultCellStyle.BackColor = Color.Salmon;
                                else if (Finish_Year > Start_Year)
                                {
                                    if (diff <= 3 && Finish_Month - 12 > 0)
                                        row.DefaultCellStyle.BackColor = Color.Salmon;
                                    else
                                    {
                                        row.DefaultCellStyle.BackColor = SystemColors.Control;
                                    }
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = SystemColors.Control;
                                }
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = SystemColors.Control;
                            }
                        }
                    }

                    TermNametextBox.Clear();   // clear NoterichTextBox after entering data
                    PricetextBox.Clear();
                    QuantitytextBox.Clear();
                    AddBarcodetextBox.Clear();
                    GetBarcodetextBox.Clear();

                    AddBarcodetextBox.Focus();
                    GetBarcodetextBox.Focus();

                    ConDataDase.Close();
                    Conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void DeleteTermbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();

                int i = NewTermdataGridView.SelectedRows[0].Index;           //  Select the row from the datagridview
                string ID = NewTermdataGridView.Rows[i].Cells[0].Value.ToString();       //  Select the column from the datagridview

                string Query = "DELETE FROM Terms WHERE ID='" + ID + "'";   //delete specific data from the datsbase 
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                SqlCommand CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Terms", Conn);
                DataTable Data = new DataTable();            // Display data in a tabluler form
                sqlDa.Fill(Data);
                NewTermdataGridView.DataSource = Data;


                if (NewTermdataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in NewTermdataGridView.Rows)
                    {
                        if (row.Cells[4].Value != null)
                        {
                            int Finish_Year = DateTime.Parse(row.Cells[5].Value.ToString()).Year;
                            int Finish_Month = DateTime.Parse(row.Cells[5].Value.ToString()).Month;

                            int Start_Year = GetdateTimePicker.Value.Year;
                            int Start_Month = GetdateTimePicker.Value.Month;

                            if (Finish_Month < Start_Month)
                                Finish_Month += 12;

                            int diff = Finish_Month - Start_Month;

                            if (Finish_Year == Start_Year || Finish_Year - 1 == Start_Year)
                            {
                                //if (Finish_Month - 2 <= Start_Month && (Finish_Year == Start_Year))
                                if (diff <= 3 && Finish_Year == Start_Year)
                                    row.DefaultCellStyle.BackColor = Color.Salmon;
                                else if (Finish_Year > Start_Year)
                                {
                                    if (diff <= 3 && Finish_Month - 12 > 0)
                                        row.DefaultCellStyle.BackColor = Color.Salmon;
                                    else
                                    {
                                        row.DefaultCellStyle.BackColor = SystemColors.Control;
                                    }
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = SystemColors.Control;
                                }
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = SystemColors.Control;
                            }
                        }
                    }


                    TermNametextBox.Clear();   // clear NoterichTextBox after entering data
                    PricetextBox.Clear();
                    QuantitytextBox.Clear();
                    AddBarcodetextBox.Clear();
                    GetBarcodetextBox.Clear();

                    AddBarcodetextBox.Focus();
                    GetBarcodetextBox.Focus();

                    ConDataDase.Close();
                    Conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void NewTermdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (NewTermdataGridView.SelectedRows.Count >= 0)    // make sure that the number of row greater or equal to zero  (if there are any data)
                {
                    Conn.Open();

                    int i = NewTermdataGridView.SelectedRows[0].Index;     //  Select the row from the datagridview
                    string ID = NewTermdataGridView.Rows[i].Cells[0].Value.ToString();   //  Select the column from the datagridview

                    SqlCommand CMD = new SqlCommand("SELECT * FROM Terms WHERE ID='" + ID + "'", Conn);     // select Specific data from table Books to be shown in the datagridview
                    // CMD.Parameters.AddWithValue(ID, Convert.ToString(TermNametextBox.Text));

                    SqlDataReader Read = CMD.ExecuteReader();
                    while (Read.Read())
                    {
                        AddBarcodetextBox.Text = Read.GetValue(1).ToString();
                        TermNametextBox.Text = Read.GetValue(2).ToString();
                        PricetextBox.Text = Read.GetValue(3).ToString();
                        QuantitytextBox.Text = Read.GetValue(4).ToString();
                        TermdateTimePicker.Text = Read.GetValue(5).ToString();
                    }
                    Read.Close();
                    Conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void GetTermNamecomboBox_Click(object sender, EventArgs e)
        {
        }

        private void GetDeletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();

                int i = getdataGridView2.SelectedRows[0].Index;
                string ID = getdataGridView2.Rows[i].Cells[0].Value.ToString();

                SqlCommand CMD = new SqlCommand("SELECT Price, Quantity FROM Receipt WHERE ID='" + ID + "'", Conn);
                SqlDataReader Read = CMD.ExecuteReader();

                double Price = 0;
                int Quantity = 0;
                int Return_Quantity = 0;
                double Update_price;
                while (Read.Read())
                {
                    Price = double.Parse(Read.GetValue(0).ToString());
                    Quantity = int.Parse(Read.GetValue(1).ToString());
                }
                Read.Close();

                Update_price = double.Parse(GetTotaltextBox.Text);
                GetTotaltextBox.Text = Convert.ToString(Update_price - Quantity * Price);

                CMD = new SqlCommand("SELECT Quantity FROM Terms WHERE ID='" + ID + "'", Conn);
                Read = CMD.ExecuteReader();
                while (Read.Read())
                {
                    Return_Quantity = int.Parse(Read.GetValue(0).ToString());
                }
                Read.Close();
                
                if (Quantity > 0)
                    Return_Quantity += Quantity;


                string Query = "UPDATE Terms SET Quantity='" + Return_Quantity + "' WHERE Name='" + GetTermNamecomboBox.Text + "'";  // update a specific row's Notes using the Serial_Number  
                CMD = new SqlCommand(Query, Conn);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Terms", Conn);    //select all data from table Notes to be shown in the datagridview
                DataTable Data = new DataTable();        // Display data in a tabluler form
                sqlDa.Fill(Data);
                NewTermdataGridView.DataSource = Data;


                Query = "DELETE FROM Bank WHERE ID='" + ID + "'";   //delete specific data from the datsbase 
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                Query = "DELETE FROM Receipt WHERE ID='" + ID + "'";   //delete specific data from the datsbase 
                ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                sqlDa = new SqlDataAdapter("SELECT ID, Name, Price, Quantity, Box FROM Receipt", Conn);
                Data = new DataTable();            // Display data in a tabluler form
                sqlDa.Fill(Data);
                getdataGridView2.DataSource = Data;

                sqlDa = new SqlDataAdapter("SELECT ID, Name, Price, Quantity, Date FROM Bank", Conn);    //select all data from table Notes to be shown in the datagridview
                Data = new DataTable();        // Display data in a tabluler form
                sqlDa.Fill(Data);
                BankdataGridView.DataSource = Data;

                GetPricetextBox.Clear();   // clear NoterichTextBox after entering data
                GetQuantitytextBox.Clear();
                AddBarcodetextBox.Clear();
                GetBarcodetextBox.Clear();

                AddBarcodetextBox.Focus();
                GetBarcodetextBox.Focus();

                ConDataDase.Close();
                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();

                string query = "SELECT Price, Quantity FROM Bank";
                SqlCommand cmd = new SqlCommand(query, Conn);
                var reader = cmd.ExecuteReader();
                double Bank_Total = 0;

                while (reader.Read())
                {
                    Bank_Total += double.Parse(reader.GetValue(0).ToString()) * int.Parse(reader.GetValue(1).ToString());
                }
                reader.Close();

                TotaltextBox.Text = Bank_Total.ToString();

                string Query = "UPDATE Bank SET Total=" + Bank_Total + "";  // update a specific row's Notes using the Serial_Number  
                SqlCommand CMD = new SqlCommand(Query, Conn);
                CMD.ExecuteNonQuery();

                Query = "DELETE FROM Receipt";   //delete specific data from the datsbase 
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ID, Name, Price, Quantity, Box FROM Receipt", Conn);    //select all data from table Notes to be shown in the datagridview
                DataTable Data = new DataTable();         // Display data in a tabluler form
                sqlDa.Fill(Data);
                getdataGridView2.DataSource = Data;


                GetPricetextBox.Clear();
                GetQuantitytextBox.Clear();
                GetTotaltextBox.Clear();
                AddBarcodetextBox.Clear();
                GetBarcodetextBox.Clear();

                AddBarcodetextBox.Focus();
                GetBarcodetextBox.Focus();

                Total = 0;

                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void GetAddNewbutton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    Conn.Open();

                    double Price = Convert.ToDouble(GetPricetextBox.Text);
                    double Real_Price = 0;
                    int Quantity = 1;

                    if (GetAllcomboBox.Text == "علبة")
                    {
                        if (GetQuantitytextBox.Text != "")
                            Quantity = Convert.ToInt32(GetQuantitytextBox.Text);
                    }
                    int Return_Quantity = 0;

                    SqlCommand CMD = new SqlCommand("SELECT Quantity FROM Terms WHERE Name='" + GetTermNamecomboBox.Text + "'", Conn);
                    SqlDataReader Read = CMD.ExecuteReader();

                    while (Read.Read())
                    {
                        Return_Quantity = int.Parse(Read.GetValue(0).ToString());
                    }
                    Read.Close();

                    if (GetQuantitytextBox.Text == "")
                    {
                        if (GetAllcomboBox.Text == "شريط")
                        {
                            Real_Price = Price * 1 / 3;
                            Total += Price * 1 / 3;
                        }
                        else if (GetAllcomboBox.Text == "شريطين")
                        {
                            Real_Price = Price * 2 / 3;
                            Total += Price * 2 / 3;
                        }
                    }
                    else
                    {
                        Real_Price = Quantity * Price;
                        Total += Quantity * Price;
                    }

                    if (Quantity < Return_Quantity && GetAllcomboBox.Text == "علبة")
                        Return_Quantity -= Quantity;


                    if (Return_Quantity < 3)
                    {
                        MessageBox.Show(".باقي اقل من 3 علب لديك");
                    }

                    string Query = "UPDATE Terms SET Quantity='" + Return_Quantity + "' WHERE Name='" + GetTermNamecomboBox.Text + "'";  // update a specific row's Notes using the Serial_Number  
                    CMD = new SqlCommand(Query, Conn);
                    CMD.ExecuteNonQuery();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Terms", Conn);    //select all data from table Notes to be shown in the datagridview
                    DataTable Data = new DataTable();        // Display data in a tabluler form
                    sqlDa.Fill(Data);
                    NewTermdataGridView.DataSource = Data;


                    SqlCommand cmd = new SqlCommand("INSERT INTO Bank(Name, Price, Quantity, Total, Date) VALUES(@Name, @Price, @Quantity, @Total, @Date)", Conn);  // insert notes in the database
                    cmd.Parameters.AddWithValue("@Name", GetTermNamecomboBox.Text);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    cmd.Parameters.AddWithValue("@Total", 0);
                    cmd.Parameters.AddWithValue("@Date", GetdateTimePicker.Text);
                    cmd.ExecuteNonQuery();

                    sqlDa = new SqlDataAdapter("SELECT ID, Name, Price, Quantity, Date FROM Bank", Conn);    //select all data from table Notes to be shown in the datagridview
                    Data = new DataTable();        // Display data in a tabluler form
                    sqlDa.Fill(Data);
                    BankdataGridView.DataSource = Data;

                    cmd = new SqlCommand("INSERT INTO Receipt(Name, Price, Quantity, Box) VALUES(@Name, @Price, @Quantity, @Box)", Conn);  // insert notes in the database
                    cmd.Parameters.AddWithValue("@Name", GetTermNamecomboBox.Text);
                    cmd.Parameters.AddWithValue("@Price", Real_Price);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    cmd.Parameters.AddWithValue("@Box", GetAllcomboBox.Text);
                    cmd.ExecuteNonQuery();

                    GetTotaltextBox.Text = Total.ToString();

                    sqlDa = new SqlDataAdapter("SELECT ID, Name, Price, Quantity, Box FROM Receipt", Conn);    //select all data from table Notes to be shown in the datagridview
                    Data = new DataTable();         // Display data in a tabluler form
                    sqlDa.Fill(Data);
                    getdataGridView2.DataSource = Data;

                    GetQuantitytextBox.Clear();   // clear NoterichTextBox after entering data
                    GetPricetextBox.Clear();
                    AddBarcodetextBox.Clear();
                    GetBarcodetextBox.Clear();

                    AddBarcodetextBox.Focus();
                    GetBarcodetextBox.Focus();

                    Conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void GetTermNamecomboBox_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                double Bank_Total = 0;
                Conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT  ID, Name, Price, Quantity, Date  FROM Bank", Conn);    //select all data from table Notes to be shown in the datagridview
                DataTable Data = new DataTable();        // Display data in a tabluler form
                sqlDa.Fill(Data);
                BankdataGridView.DataSource = Data;

                string query = "SELECT Price, Quantity FROM Bank";
                SqlCommand cmd = new SqlCommand(query, Conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bank_Total += double.Parse(reader.GetValue(0).ToString()) * int.Parse(reader.GetValue(1).ToString());
                }
                reader.Close();

                TotaltextBox.Text = Bank_Total.ToString();

                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double Bank_Total = 0;
                Conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT  ID, Name, Price, Quantity, Date  FROM Bank WHERE Date='" + BankdateTimePicker.Text + "'", Conn);    //select all data from table Notes to be shown in the datagridview
                DataTable Data = new DataTable();        // Display data in a tabluler form
                sqlDa.Fill(Data);
                BankdataGridView.DataSource = Data;

                string query = "SELECT Price, Quantity FROM Bank WHERE Date='" + BankdateTimePicker.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bank_Total += double.Parse(reader.GetValue(0).ToString()) * int.Parse(reader.GetValue(1).ToString());
                }
                reader.Close();

                TotaltextBox.Text = Bank_Total.ToString();

                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT  ID, Name, Price, Quantity, Date  FROM Bank WHERE Date='" + ReturndateTimePicker.Text + "'", Conn);    //select all data from table Notes to be shown in the datagridview
                DataTable Data = new DataTable();        // Display data in a tabluler form
                sqlDa.Fill(Data);
                ReturndataGridView3.DataSource = Data;
                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void DeleteReturnbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();

                int i = ReturndataGridView3.SelectedRows[0].Index;
                string ID = ReturndataGridView3.Rows[i].Cells[0].Value.ToString();

                SqlCommand CMD = new SqlCommand("SELECT Price, Quantity FROM Bank WHERE ID='" + ID + "'", Conn);
                SqlDataReader Read = CMD.ExecuteReader();

                double Price = 0;
                int Quantity = 1;
                int Return_Quantity = 0;
                double Update_Total = 0;

                while (Read.Read())
                {
                    Price = double.Parse(Read.GetValue(0).ToString());
                    Quantity = int.Parse(Read.GetValue(1).ToString());
                }
                Read.Close();

                CMD = new SqlCommand("SELECT Quantity FROM Terms WHERE ID='" + ID + "'", Conn);
                Read = CMD.ExecuteReader();
                while (Read.Read())
                {
                    Return_Quantity = int.Parse(Read.GetValue(0).ToString());
                }
                Read.Close();

                if (Quantity > 0)
                    Return_Quantity += Quantity;

                string Query = "UPDATE Terms SET Quantity='" + Return_Quantity + "' WHERE Name='" + GetTermNamecomboBox.Text + "'";  // update a specific row's Notes using the Serial_Number  
                CMD = new SqlCommand(Query, Conn);
                CMD.ExecuteNonQuery();

                CMD = new SqlCommand("SELECT Total FROM Bank", Conn);
                Read = CMD.ExecuteReader();
                while (Read.Read())
                {
                    Update_Total = double.Parse(Read.GetValue(0).ToString());
                }
                Read.Close();

                Update_Total -= Price * Quantity;
                TotaltextBox.Text = Update_Total.ToString();

                Query = "UPDATE Bank SET Total='" + Update_Total + "'";  // update a specific row's Notes using the Serial_Number  
                CMD = new SqlCommand(Query, Conn);
                CMD.ExecuteNonQuery();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Terms", Conn);    //select all data from table Notes to be shown in the datagridview
                DataTable Data = new DataTable();        // Display data in a tabluler form
                sqlDa.Fill(Data);
                NewTermdataGridView.DataSource = Data;

                Query = "DELETE FROM Bank WHERE ID='" + ID + "'";   //delete specific data from the datsbase 
                SqlConnection ConDataDase = new SqlConnection(str);
                ConDataDase.Open();
                CMD = new SqlCommand(Query, ConDataDase);
                CMD.ExecuteNonQuery();

                sqlDa = new SqlDataAdapter("SELECT ID, Name, Price, Quantity, Date FROM Bank", Conn);
                Data = new DataTable();            // Display data in a tabluler form
                sqlDa.Fill(Data);
                BankdataGridView.DataSource = Data;

                sqlDa = new SqlDataAdapter("SELECT  ID, Name, Price, Quantity, Date  FROM Bank WHERE Date='" + ReturndateTimePicker.Text + "'", Conn);
                Data = new DataTable();            // Display data in a tabluler form
                sqlDa.Fill(Data);
                ReturndataGridView3.DataSource = Data;
                ConDataDase.Close();
                Conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void GetTermNamecomboBox_SelectedValueChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    Conn.Open();
            //    string query = "SELECT Price FROM Terms WHERE Name='" + GetTermNamecomboBox.Text + "'";      // select specific item from the database to be shown in the datagridview
            //    SqlCommand cmd = new SqlCommand(query, Conn);
            //    var reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        GetPricetextBox.Text = reader.GetValue(0).ToString();
            //    }
            //    reader.Close();
            //    Conn.Close();
            //}
            //catch (Exception E)
            //{
            //    MessageBox.Show(E.Message);
            //    Conn.Close();
            //}
        }

        private void GetAllcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GetAllcomboBox.Text != "علبة")
            {
                GetQuantitytextBox.Enabled = false;
            }
            else
            {
                GetQuantitytextBox.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LogIn form = new LogIn();
            form.Show();
            this.Hide();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                string database = Conn.Database.ToString();

                string cmd = "BACKUP DATABASE [" + database + "] TO DISK = '" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BackUp\\database-" + DateTime.Now.ToString("yyyy-MM-dd---HH-mm-ss") + ".bak'";
                try
                {
                    SqlCommand command = new SqlCommand(cmd, Conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Database backup done successfully");
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
                Conn.Close();

                Application.Exit();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BackUp form = new BackUp();
            form.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (NewTermdataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in NewTermdataGridView.Rows)
                {
                    if (row.Cells[4].Value != null)
                    {
                        int Finish_Year = DateTime.Parse(row.Cells[5].Value.ToString()).Year;
                        int Finish_Month = DateTime.Parse(row.Cells[5].Value.ToString()).Month;

                        int Start_Year = GetdateTimePicker.Value.Year;
                        int Start_Month = GetdateTimePicker.Value.Month;

                        if (Finish_Month < Start_Month)
                            Finish_Month += 12;

                        int diff = Finish_Month - Start_Month;

                        if (Finish_Year == Start_Year || Finish_Year - 1 == Start_Year)
                        {
                            if (diff <= 3 && Finish_Year == Start_Year)
                                row.DefaultCellStyle.BackColor = Color.Salmon;
                            else if(Finish_Year > Start_Year)
                            {
                                if(diff <= 3 && Finish_Month-12 > 0)
                                    row.DefaultCellStyle.BackColor = Color.Salmon;
                                else
                                {
                                    row.DefaultCellStyle.BackColor = SystemColors.Control;
                                }
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = SystemColors.Control;
                            }
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = SystemColors.Control;
                        }
                    }
                }
            }
        }

        private void Main_page_Load(object sender, EventArgs e)
        {
            AddBarcodetextBox.Focus();
            GetBarcodetextBox.Focus();
        }

        private void AddBarcodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Name, Price, Quantity FROM Terms WHERE Barcode='" + GetBarcodetextBox.Text + "'", Conn);
                if (cmd != null)
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TermNametextBox.Text = reader.GetString(0).ToString();
                        PricetextBox.Text = reader.GetValue(1).ToString();
                        QuantitytextBox.Text = reader.GetValue(2).ToString();
                    }
                    reader.Close();
                }
                Conn.Close();
            }
        }

        private void GetBarcodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Conn.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT Name, Price FROM Terms WHERE Barcode='" + GetBarcodetextBox.Text + "'", Conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GetTermNamecomboBox.Text = reader.GetString(0).ToString();
                    GetPricetextBox.Text = reader.GetValue(1).ToString();
                }
                reader.Close();
                Conn.Close();
            }
        }

        private void getdataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (getdataGridView2.SelectedRows.Count >= 0)    // make sure that the number of row greater or equal to zero  (if there are any data)
                {
                    Conn.Open();

                    int i = getdataGridView2.SelectedRows[0].Index;     //  Select the row from the datagridview
                    string ID = getdataGridView2.Rows[i].Cells[0].Value.ToString();   //  Select the column from the datagridview

                    SqlCommand CMD = new SqlCommand("SELECT * FROM Receipt WHERE ID='" + ID + "'", Conn);     // select Specific data from table Books to be shown in the datagridview
                    // CMD.Parameters.AddWithValue(ID, Convert.ToString(TermNametextBox.Text));

                    SqlDataReader Read = CMD.ExecuteReader();
                    while (Read.Read())
                    {
                        GetTermNamecomboBox.Text = Read.GetValue(1).ToString();
                        GetQuantitytextBox.Text = Read.GetValue(3).ToString();
                        GetAllcomboBox.Text = Read.GetValue(4).ToString();
                    }
                    Read.Close();

                    CMD = new SqlCommand("SELECT Price FROM Terms WHERE ID='" + ID + "'", Conn);     // select Specific data from table Books to be shown in the datagridview
                    // CMD.Parameters.AddWithValue(ID, Convert.ToString(TermNametextBox.Text));

                    Read = CMD.ExecuteReader();
                    while (Read.Read())
                    {
                        GetPricetextBox.Text = Read.GetValue(0).ToString();
                    }
                    Read.Close();


                    Conn.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                Conn.Close();
            }
        }
    }
}