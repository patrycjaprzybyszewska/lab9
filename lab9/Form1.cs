using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace lab9
{
    public partial class Form1 : Form
    {
        public int nralbm = 12;
        public string Imie;
        public int semestr;
        public int rok;
        public string kierunek;
        public string stopien;
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
                int i = 8;
                string query = "INSERT INTO [Table] (Id, Numer_Albumu, Imie_Nazwisko, Semestr, Rok, Kierunek, Stopieñ) VALUES (@i, @Id, @imie, @sem, @rok, @kier, @stop)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", nralbm);
                command.Parameters.AddWithValue("@i", i);
                command.Parameters.AddWithValue("@imie", Imie);
                command.Parameters.AddWithValue("@sem", semestr);
                command.Parameters.AddWithValue("@rok", rok);
                command.Parameters.AddWithValue("@kier", kierunek);
                command.Parameters.AddWithValue("@stop", stopien);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Imie = textBox2.Text;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            semestr = int.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            rok = int.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            kierunek = textBox5.Text;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            stopien = textBox6.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

