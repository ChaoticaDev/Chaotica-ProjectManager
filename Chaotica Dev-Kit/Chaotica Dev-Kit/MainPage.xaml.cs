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
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Chaotica_Dev_Kit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ChaoticaProject> _projs;

        private ObservableCollection<ChaoticaBug> _bugs;

        public Button btnn;

        private ObservableCollection<ChaoticaProject> MyProjects
        {
            get
            {
                return _projs;
            }

            set
            {
                _projs = value;
                NotifyPropertyChanged("Projects");
            }
        }

        private ObservableCollection<ChaoticaBug> MyBugs
        {
            get
            {
                return _bugs;
            }

            set
            {
                _bugs = value;
                NotifyPropertyChanged("Bugs");
            }
        }

        //Create new database instance
        //Connects to database
        ChaoticaDBManager db = new ChaoticaDBManager();

        public void RefreshProjectsList()
        {
            //Clear project list
            this.MyProjects.Clear();

            btnn = c_CreateProject;

            //MySQL Query
            MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM projects;");

            //Loop Tables
            while (reader.Read())
            {
                //Add Project [Get Project Title]
                this.MyProjects.Add(new ChaoticaProject(reader.GetString("ID"), reader.GetString("Title")));
            }

            reader.Close();

        }

        public MainPage()
        {
            this.InitializeComponent();


            this.MyProjects = new ObservableCollection<ChaoticaProject>();
            this.MyBugs = new ObservableCollection<ChaoticaBug>();
            this.MyProjects.Clear();

            c_ProjectsPanel.ItemsSource = this.MyProjects;

            /*ENCODING BEGIN*/
            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            System.Text.Encoding.RegisterProvider(ppp);
            /*ENCODING END*/

            //MySQL Query
            MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM projects;");
            
            //Loop Tables
            while (reader.Read())
            {
                //Add Project [Get Project Title]
                 this.MyProjects.Add(new ChaoticaProject(reader.GetString("ID"), reader.GetString("Title"))); 
            }

            reader.Close();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void c_ProjectsPanel_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            
        }

        private void c_ProjectsPanel_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Enable edit button on project selection
            this.c_EditProject.IsEnabled = true;
            this.p_Selector.Width = 100;

            ChaoticaProject selectedProj = (ChaoticaProject)e.ClickedItem;
            this.MyBugs.Clear();

            selectedProj.LoadBugList(selectedProj);
            foreach(ChaoticaBug b in selectedProj.Bugs)
            {
                this.MyBugs.Add(b);
            }

        }

        void RefProj_WinClose(object sender, RoutedEventArgs e)
        {
            //Refresh projects list
            RefreshProjectsList();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentAV = ApplicationView.GetForCurrentView();
            var newAV = CoreApplication.CreateNewView();

            /*await newAV.Dispatcher.RunAsync(
            CoreDispatcherPriority.Normal,
            async () =>
            {*/

            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = "Create Project";

            var frame = new Frame();
            frame.Navigate(typeof(X_CreateProject), this);
            newWindow.Content = frame;
            newWindow.Activate();
                
            this.GotFocus += new RoutedEventHandler(RefProj_WinClose);
            
        }

        private void c_EditProject_Click(object sender, RoutedEventArgs e)
        {
            ChaoticaProject selectedProject = (ChaoticaProject)this.c_ProjectsPanel.Items.ElementAt(this.c_ProjectsPanel.SelectedIndex);

            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = "Create Project";

            var frame = new Frame();
            frame.Navigate(typeof(X_EditProject), selectedProject);
            newWindow.Content = frame;
            newWindow.Activate();


            //frame.Unloaded += new RoutedEventHandler(RefProj_WinClose);
            this.GotFocus += new RoutedEventHandler(RefProj_WinClose);
        }

        public static void GoHome()
        {
            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = "Create Project";

            var frame = new Frame();
            frame.Navigate(typeof(MainPage), null);
            newWindow.Content = frame;
            newWindow.Activate();
        }
    }
}
