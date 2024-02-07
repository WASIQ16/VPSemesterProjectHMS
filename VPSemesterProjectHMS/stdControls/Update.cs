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

namespace VPSemesterProjectHMS.stdControls
{
    public partial class Update : UserControl
    {
        string con = @"Data Source=WASIQ_ZAFAR\SQLEXPRESS;Initial Catalog=HostelManagementSystem;Integrated Security=True";
        public Update()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            string RegNo = gunaTextBox1.Text;
            SqlConnection sqlConnection = new SqlConnection(con);
            string query = "Select *from StudentsRecord  WHERE RegNo=" + RegNo;
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView3.DataSource = dataTable;
            sqlConnection.Open();
            int omer = cmd.ExecuteNonQuery();
            dataGridView3.Visible = true;
            dataGridView3.AllowUserToAddRows = false;
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(con);

                for (int item = 0; item < dataGridView3.Rows.Count; item++)
                {
                    DataGridViewRow row = dataGridView3.Rows[item];

                    // Check if any cell in the row is dirty (modified)
                   

                    string query = "UPDATE StudentsRecord SET RegNo=@RegNo, Name=@Name, FatherName=@FatherName, " +
                                   "ContactNo=@ContactNo, GuardianNo=@GuardianNo, City=@City, Province=@Province, " +
                                   "Class=@Class, Department=@Department, RoomNo=@RoomNo, Floor=@Floor, " +
                                   "MessBill=@MessBill, FeeStatus=@FeeStatus, OnLeave=@OnLeave, Date=@Date, " +
                                   "CNIC=@CNIC, Attendence=@Attendence WHERE RegNo=@RegNo";

                    SqlCommand sql = new SqlCommand(query, sqlConnection);

                    sql.Parameters.AddWithValue("@RegNo", row.Cells[0].Value);
                    sql.Parameters.AddWithValue("@Name", row.Cells[1].Value);
                    sql.Parameters.AddWithValue("@FatherName", row.Cells[2].Value);
                    sql.Parameters.AddWithValue("@ContactNo", row.Cells[3].Value);
                    sql.Parameters.AddWithValue("@GuardianNo", row.Cells[4].Value);
                    sql.Parameters.AddWithValue("@City", row.Cells[5].Value);
                    sql.Parameters.AddWithValue("@Province", row.Cells[6].Value);
                    sql.Parameters.AddWithValue("@Class", row.Cells[7].Value);
                    sql.Parameters.AddWithValue("@Department", row.Cells[8].Value);
                    sql.Parameters.AddWithValue("@RoomNo", row.Cells[9].Value);
                    sql.Parameters.AddWithValue("@Floor", row.Cells[10].Value);
                    sql.Parameters.AddWithValue("@MessBill", row.Cells[11].Value);
                    sql.Parameters.AddWithValue("@FeeStatus", row.Cells[12].Value);
                    sql.Parameters.AddWithValue("@OnLeave", row.Cells[13].Value);
                    sql.Parameters.AddWithValue("@Date", row.Cells[14].Value);
                    sql.Parameters.AddWithValue("@CNIC", row.Cells[15].Value);
                    sql.Parameters.AddWithValue("@Attendence", row.Cells[16].Value);

                    sqlConnection.Open();
                    sql.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                dataGridView3.EndEdit();
                dataGridView3.Update();
                MessageBox.Show("Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(con);
            string query = "Select *from StudentsRecord ";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView3.DataSource = dataTable;
            sqlConnection.Open();
            int omer = cmd.ExecuteNonQuery();
            dataGridView3.Visible = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}