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
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;

            //Initialize the values of text boxs using the contact properties
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //Update contact values before update in the database
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;

            //Connect to the database (close after the code because end the using)
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Create the Contact table, based on the Contact class, only if not exists
                connection.CreateTable<Contact>();

                //Update the contact opened in this window
                connection.Update(contact);
            }

            //Close the window
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Connect to the database (close after the code because end the using)
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Create the Contact table, based on the Contact class, only if not exists
                connection.CreateTable<Contact>();

                //Delete the contact opened in this window
                connection.Delete(contact);
            }

            //Close the window
            this.Close();
        }
    }
}
