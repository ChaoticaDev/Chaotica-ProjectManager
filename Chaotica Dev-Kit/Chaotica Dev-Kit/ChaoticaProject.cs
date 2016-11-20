using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace Chaotica_Dev_Kit
{
    class ChaoticaComment
    {
        public String Title { get; set; }
        public String CommentText { get; set; }
        public String TimeStamp { get; set; }

        public ChaoticaComment(String title, String commentText)
        {
            this.Title = title;
            this.CommentText = commentText;
        }
    }

    class ChaoticaProject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String _Title;

        public String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private String _ID;

        public String ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                NotifyPropertyChanged("Title");
            }
        }

        public ObservableCollection<ChaoticaBug> Bugs { get; set; }

        public ChaoticaBug AddBug(ChaoticaBug bug)
        {
            //Create new comments container
            bug.Comments.Add(new ChaoticaComment("Hello", "This is so cool"));

            //Add bug to container
            this.Bugs.Add(bug);

            //Return newly created bug report
            return this.Bugs.ElementAt(this.Bugs.Count-1);
        }

        public void LoadBugList(ChaoticaProject proj)
        {
            //Clear bug list
            this.Bugs.Clear();

            //MySQL Query
            MySqlDataReader reader = ChaoticaDBManager.Query("SELECT * FROM `bugs` WHERE PID = '" + this.ID + "';");

            //Loop Tables
            while (reader.Read())
            {
                //Add Project [Get Project Title]
                this.AddBug(new ChaoticaBug(reader.GetString("ID"), reader.GetString("Title"), reader.GetString("Description"), reader.GetString("TimeStamp"), reader.GetInt32("Priority"), reader.GetBoolean("Resolved"), proj));
            }

            //Close reader
            reader.Close();
        }

        public ChaoticaProject(String pID, String title)
        {
            this.Title = title;
            this.ID = pID;
            Bugs = new ObservableCollection<ChaoticaBug>();
        }

        private void NotifyPropertyChanged(String propertyName = "")

        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }
    }

    class ChaoticaProjectManager
    {
        public static List <ChaoticaProject> GetProjects()
        {
            var projects = new List<ChaoticaProject>();
            

            return projects;
        }
    }
}
