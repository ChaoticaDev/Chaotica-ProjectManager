using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
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
    public sealed partial class X_EditProject : Page
    {
        ChaoticaProject proj;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.proj = e.Parameter as ChaoticaProject;

            this.c_ProjectID.Text = "Project ID: " + this.proj.ID;
            this.xTitle.Text = this.proj.Title;
        }

        public X_EditProject()
        {
            this.InitializeComponent();
        }

        public void FinishProjectEditing()
        {
            MainPage.GoHome();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Update project name
            MySqlDataReader reader = ChaoticaDBManager.Query("UPDATE projects SET Title = '" + xTitle.Text.ToString() + "' WHERE ID = '" + this.proj.ID + "';");
            reader.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FinishProjectEditing();
        }
    }
}
