using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Wird zuerst benötigt: Projekt -> NuGet-Paket Verwalten
// -> "MySqlConnector" suchen und installieren

using MySqlConnector;

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
            ///- User, der auf die Datenbank zugreifen darf und
            ///- Passwort (Sicherheitskriterien beachten!)
            ///Natürlich müssen Datenbank und User auf der Datenbank existieren.
            MySqlConnection con = new MySqlConnection(@"SERVER = localhost;DATABASE=demodb;UID=user1;PASSWORD=pwd1;");
            
            //Nachdem die Zugangsdaten gesetzt wurden, können wir den "Kanal" zur Datenbank öffnen.
            con.Open();  //Jetzt greift unser Programm über das Netzwerk/lokal auf die Datenbank zu.

            ///Nun können wir einen SQL-Befehl an die DB senden, der Daten in eine Tabelle einfügt. 
            ///Dies geht im einfachsten Fall über SQL-Befehle als String.
            string insert = "INSERT INTO tbldemo VALUES('das ist ein Eintrag')";
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
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
