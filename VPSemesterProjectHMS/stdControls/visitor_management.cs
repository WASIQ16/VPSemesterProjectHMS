using DGVPrinterHelper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VPSemesterProjectHMS.stdControls
{
    public partial class visitor_management : Form
    {
        public visitor_management()
        {
            InitializeComponent();
        }

        string con = @"Data Source=WASIQ_ZAFAR\SQLEXPRESS;Initial Catalog=HostelManagementSystem;Integrated Security=True";
        string isincoming;

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            string stu_id = gunaTextBox1.Text;
            string v_Name = gunaTextBox2.Text;
            string v_purpose = gunaTextBox3.Text;

            if (checkBox1.Checked == true)
            {
                isincoming = "Yes";
            }
            else
            {
                isincoming = "No";
            }
            string date = gunaDateTimePicker1.Value.ToShortDateString();

            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                string query = "INSERT INTO Visitor_Management(StudentId,VisitorName,Purpose,Isincoming,[Date/Time]) VALUES(@stu_id, @v_Name, @v_purpose, @isincoming, @date)";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@stu_id", stu_id);
                    cmd.Parameters.AddWithValue("@v_Name", v_Name);
                    cmd.Parameters.AddWithValue("@v_purpose", v_purpose);
                    cmd.Parameters.AddWithValue("@isincoming", isincoming);
                    cmd.Parameters.AddWithValue("@date", date);

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record saved successfully!");
                }
            }
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {

            string stu_id = gunaTextBox1.Text;
            string v_Name = gunaTextBox2.Text;
            string v_purpose = gunaTextBox3.Text;

            if (checkBox1.Checked == true)
            {
                isincoming = "Yes";
            }
            else
            {
                isincoming = "No";
            }
            string date = gunaDateTimePicker1.Value.ToShortDateString();

            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                sqlConnection.Open();

                // Check if the record with the given student ID exists
                string checkQuery = "SELECT COUNT(*) FROM Visitor_Management WHERE StudentId = @stu_id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlConnection))
                {
                    checkCmd.Parameters.AddWithValue("@stu_id", stu_id);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        // Record exists, perform update
                        string updateQuery = "UPDATE Visitor_Management SET VisitorName = @v_Name, Purpose = @v_purpose, Isincoming = @isincoming, [Date/Time] = @date WHERE StudentId = @stu_id";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, sqlConnection))
                        {
                            updateCmd.Parameters.AddWithValue("@stu_id", stu_id);
                            updateCmd.Parameters.AddWithValue("@v_Name", v_Name);
                            updateCmd.Parameters.AddWithValue("@v_purpose", v_purpose);
                            updateCmd.Parameters.AddWithValue("@isincoming", isincoming);
                            updateCmd.Parameters.AddWithValue("@date", date);

                            updateCmd.ExecuteNonQuery();
                            MessageBox.Show("Record updated successfully!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record with the given Student ID does not exist!");
                    }
                }
            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            string stu_id = gunaTextBox1.Text;

            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                sqlConnection.Open();

                // Check if the record with the given student ID exists
                string checkQuery = "SELECT COUNT(*) FROM Visitor_Management WHERE StudentId = @stu_id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlConnection))
                {
                    checkCmd.Parameters.AddWithValue("@stu_id", stu_id);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        // Record exists, perform delete
                        string deleteQuery = "DELETE FROM Visitor_Management WHERE StudentId = @stu_id";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, sqlConnection))
                        {
                            deleteCmd.Parameters.AddWithValue("@stu_id", stu_id);

                            deleteCmd.ExecuteNonQuery();
                            MessageBox.Show("Record deleted successfully!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record with the given Student ID does not exist!");
                    }
                }
            }
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Visitor_Management";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Assuming dataGridView1 is the name of your DataGridView control
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want to Exit", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            DashBoard d = new DashBoard();
            d.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want to Print?", "Fee Defaulter", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Fee Defaulters";
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.PrintDataGridView(dataGridView1);
            }
            else
            {
                MessageBox.Show("Not Printed Try Again");
            }
        }
    }
    
}
