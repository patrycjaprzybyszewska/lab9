using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace lab9
{
    public partial class Form1 : Form
    {
        public int nralbm = 11;
        private string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\patpr\source\repos\lab9\lab9\Database1.mdf;Integrated Security = True";
        public Form1()
        {
            InitializeComponent();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            nralbm = int.Parse(textBox1.Text);

        }

        public void WriteData(int nralbm)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int i = 5;
                string query = "INSERT INTO [Table] (Id, Numer_Albumu) VALUES (@i, @Id)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", nralbm);
                command.Parameters.AddWithValue("@i", i);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                i++;


                try
                {

                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteData(nralbm);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}