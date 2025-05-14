using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Projekt -> NuGet-Paket Verwalten
// -> "MySql.Data" von MySQL suchen (111MB) suchen und installieren
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;


namespace SimpleDBAccess
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            ///Um diese Klassen benutzen zu können, müssen Sie den Namespace MySql.Data in den
            ///using-Direktiven (siehe oben) hinzufügen. 
            ///
            ///Jetzt können wir als Erstes eine Verbindung zur Datenbank herstellen. In einem sog.
            ///Connection-String geben wir die nötigen Verbindungsinformationen an:
            ///- Server-Adresse/IP
            ///- Name der Datenbank
            ///- User, der auf die Datenbank zugreifen darf und (zu Lehrzwecken "root")
            ///- Passwort (leer - nur zu Lehrzwecken!)
            ///Natürlich müssen Datenbank und User auf der Datenbank existieren.
            MySqlConnection con = new MySqlConnection(@"SERVER = localhost;DATABASE=simpledbaccess;UID=root;PASSWORD=;");

            //Nachdem die Zugangsdaten gesetzt wurden, können wir den "Kanal" zur Datenbank öffnen.
            con.Open();  //Jetzt greift unser Programm über das Netzwerk/lokal auf die Datenbank zu.

            ///Nun können wir einen SQL-Befehl an die DB senden, der Daten in eine Tabelle einfügt. 
            ///Dies geht im einfachsten Fall über SQL-Befehle als String.
            ///Damit man auch eine Veränderung auf der Datenbank sieht und erkennen kann, ob die Daten
            ///aktuell sind, hängen wir noch das aktuelle Datum und die Uhrzeit dran.
            string insert = $"INSERT INTO tbldata (message) VALUES ('Das ist ein Eintrag vom {DateTime.Now}');";

            //Damit der MySQL-Server das SQL-Statement verarbeiten kann, müssen wir es in einen MySqlCommand-Objekt umwandeln.
            //Dafür erstellen wir ein MySqlCommand-Objekt mit new...
            MySqlCommand cmd = new MySqlCommand();
            //..und fügen die nötigen Informationen hinzu:
            cmd.CommandText = insert;
            cmd.Connection = con; //Damit weiß der Command, welche Verbindung er zum DB-Server verwenden soll.

            //Mit ExecuteNonQuery() führen wir den Command auf der DB aus.
            cmd.ExecuteNonQuery();

            //So, wenn alles funktioniert hat, solle nun in der Datenbank ein Eintrag in der Tabelle tbldemo vorhanden sein.
            //Überprüfen Sie dies....
            con.Close();

            MessageBox.Show($"Daten wurden erfolgreich eingefügt. Überprüfe in der DB, ob es geklappt hat.");
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            ///Diese Methode ist auch wieder "stand alone", d. h. sie enthält den gesamten nötigen 
            ///Quellcode. In einem professionellerem Projekt, würde man die Connection an einer 
            ///anderen Stelle (z. B. Konstruktor) aufbauen.
            MySql.Data.MySqlClient.MySqlConnection myConnection;
            string myConnectionString;
            //Siehe oben. Die Reihenfolge der Parameter ist beliebig.
            myConnectionString = "server=localhost;uid=root;pwd=;database=simpledbaccess";


            myConnection = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            //open a connection
            myConnection.Open();

            // create a MySQL command and set the SQL statement with parameters
            ///Wir erstellen eine Abfrage, welche den Datensatz mit der id 8 aus der
            ///Datenbank holt. Dieser Datensatz sollte beim Einspielen der DB immer dabei sein.
            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;

            myCommand.CommandText = @"SELECT * FROM tbldata WHERE iddata = @iddata;";
            myCommand.Parameters.AddWithValue("@iddata", 8);

            // execute the command and read the results
            var myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                var id = myReader.GetInt32("iddata");
                var msg = myReader.GetString("message");
                MessageBox.Show($"iddata: {id}, message: {msg}");
            }

            myConnection.Close();

        }
    }
}
