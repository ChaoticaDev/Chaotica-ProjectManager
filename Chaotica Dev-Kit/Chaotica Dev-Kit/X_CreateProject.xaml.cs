using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chaotica_Dev_Kit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class X_CreateProject : Page
    {
        public MainPage rootPage;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.rootPage = e.Parameter as MainPage;
        }

        public X_CreateProject()
        {
            this.InitializeComponent();

        }

        public void FinishProjectCreation()
        {
            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = "Create Project";

            var frame = new Frame();
            frame.Navigate(typeof(MainPage), this);
            newWindow.Content = frame;
            newWindow.Activate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (xTitle.Text == "")
            {
                return;
            }

            //Query existing project
            MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM projects WHERE Title = '" + xTitle.Text.ToString() + "';");

            int x = 0;
            int y = 0;

            while (reader.Read())
            {
                if (xTitle.Text.ToString() == reader.GetString("Title"))
                {
                    x++;
                    break;
                }
            }

            //Close reader
            reader.Close();

            //If project not found
            if (x <= 0)
            {
                //Insert project
                reader = ChaoticaDBManager.Query("INSERT INTO projects (Title) VALUES ('" + xTitle.Text + "')");

                //Close reader
                reader.Close();

                FinishProjectCreation();
            }
            else
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FinishProjectCreation();
        }
    }
}
