using DesktopContactsApp.Classes;
using SQLite;
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
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //Define the contact to be saved
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            //Set the database name
            string databaseName = "Contacts.db";
            //Set the folder path equals to "My Documents" path
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Define the database path as a path combine of folder path + database name
            string databasePath = System.IO.Path.Combine(folderPath, databaseName);

            //Connect to the database
            SQLiteConnection connection = new SQLiteConnection(databasePath);

            //Create the Contact table, based on the Contact class, only if not exists
            connection.CreateTable<Contact>();

            //Insert the contact defined in the related Contact table (is automatic, use the class type)
            connection.Insert(contact);

            this.Close();
        }
    }
}
