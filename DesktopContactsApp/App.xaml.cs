using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Set the database name
        public static string databaseName = "Contacts.db";
        //Set the folder path equals to "My Documents" path
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //Define the database path as a path combine of folder path + database name
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
