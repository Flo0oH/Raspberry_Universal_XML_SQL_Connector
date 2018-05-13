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

namespace Raspberry_Universal_XML_SQL_Connector
{
    public partial class Connect : Form
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;
        public string connectionString;
        private Random Rnd = new Random();
        private string Datum = (System.DateTime.Now.ToShortDateString());
        private string Datum_mysql = (System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day);
        private string Zeit = System.DateTime.Now.ToShortTimeString();


        public Connect()
        {
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = textBox1.Text;
            database = textBox2.Text;
            uid = textBox3.Text;
            password = textBox4.Text;
            port = textBox5.Text;
            int b = Rnd.Next(0, 1000);

            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";


            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command;
            connection.Open();
            MessageBox.Show("Verbindung wurde erfolgreich hergestellt", "MySQL Information",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE Login2 VALUES (";
            command.CommandText = "INSERT INTO Login VALUES(" + b + ",'MySQL Database','" + Datum_mysql + "','" + Zeit + "','Heimstetten');";// SQL Befehle erstellen
            command.ExecuteNonQuery();
            command.CommandText = "select * from Login order by Uhrzeit desc;"; //Alle Datensätze aus der Spalte Person hinzufügen
            SqlDataReader reader = command.ExecuteReader(); //Daten aus der Tabelle auslesen
                                                              //Daten in einer Tabelle/GridView löschen
            for (int i = 0; i < reader.FieldCount; i++)
                dataGridView1.Columns.Add(
                    reader.GetName(i),
                    reader.GetName(i));


            while (reader.Read()) // Solange durch die Datentabelle springen bis kein Inhalt mehr in der Tabelle ist und in der Textbox anzeigen
            {
                object[] row = new object[reader.FieldCount]; //ein Array erstellen die unsere Zeilen& Spaltennamen beinhaltet
                for (int i = 0; i < reader.FieldCount; i++)
                    row[i] = reader[i];
                dataGridView1.Rows.Add(row);
            }
            reader.Close(); // Den Reader wieder been
                            // Ausführen einer nichtSelect Anfrage
            connection.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

/*
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using MySql.Data.Types;
using System.Threading;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
namespace MySQLConnector
{
    


    public partial class Form1 : Form
    {
        
        private string server;
        private string database;
        private string uid;
        private string password;
        private string connectionString;
        private Random Rnd = new Random();
        private string Datum = (System.DateTime.Now.ToShortDateString());
        private string Datum_mysql = (System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day);
        private string Zeit = System.DateTime.Now.ToShortTimeString();
       

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = textBox1.Text;
            database = textBox2.Text;        
            uid = textBox3.Text;
            password = textBox4.Text;
            int b = Rnd.Next(0, 1000);
            
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command;
            connection.Open();
            MessageBox.Show("Verbindung wurde erfolgreich hergestellt", "MySQL Information",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE Login2 VALUES (";
            command.CommandText = "INSERT INTO Login VALUES(" + b + ",'MySQL Database','" + Datum_mysql + "','" + Zeit + "','Heimstetten');";// SQL Befehle erstellen
            command.ExecuteNonQuery();
            command.CommandText = "select * from Login order by Uhrzeit desc;"; //Alle Datensätze aus der Spalte Person hinzufügen
            MySqlDataReader reader = command.ExecuteReader(); //Daten aus der Tabelle auslesen
                     //Daten in einer Tabelle/GridView löschen
            for (int i = 0; i < reader.FieldCount; i++)
                        dataGridView1.Columns.Add(
                            reader.GetName(i),
                            reader.GetName(i));


             while (reader.Read()) // Solange durch die Datentabelle springen bis kein Inhalt mehr in der Tabelle ist und in der Textbox anzeigen
                    {
                        object[] row = new object[reader.FieldCount]; //ein Array erstellen die unsere Zeilen& Spaltennamen beinhaltet
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[i] = reader[i];
                        dataGridView1.Rows.Add(row);
                    }
                    reader.Close(); // Den Reader wieder been
                     // Ausführen einer nichtSelect Anfrage
                    connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command;
            connection.Open();
            MessageBox.Show("Möchten Sie die Tabelleninhalt wirklich löschen", "Tabelle löschen",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            command = connection.CreateCommand();
            command.CommandText = "TRUNCATE TABLE Login;";// SQL Befehle erstellen
            command.ExecuteNonQuery();
            
            MessageBox.Show("Tabelleninhalt wurde erfolgreich gelöscht!");
            connection.Close();
        }
    }
}* 
 * */

