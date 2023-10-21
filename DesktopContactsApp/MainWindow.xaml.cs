﻿using DesktopContactsApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();

            //Initialize the contacts list
            contacts = new List<Contact>();

            //Read the database at the opening of the main window
            ReadDatabase();
        }

        private void NewContactBtn_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            //Read the database also when return to this window (after close the new contact window)
            ReadDatabase();
        }

        private void ReadDatabase()
        {
            //Connect to the database (close after the code because end the using)
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Create the Contact table, based on the Contact class, only if not exists
                connection.CreateTable<Contact>();

                //Retrieve the Contact table as a list of objects
                contacts = connection.Table<Contact>().ToList();
            }

            //If readed correctly from database
            if(contacts != null)
            {
                //Add contacts list to the item source of contacts list view
                contactsListView.ItemsSource = contacts;
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Convert the sender to a text box
            TextBox searchTextBox = sender as TextBox;

            //Retrieve a list of contacts filtered on the name (name must contain the value in the filter text box)
            var filteredList = contacts.Where(contact => contact.Name.Contains(searchTextBox.Text)).ToList();

            //Add filtered contacts list to the item source of contacts list view
            contactsListView.ItemsSource = filteredList;
        }
    }
}
