using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        public String Title {
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

        public ObservableCollection<ChaoticaBug> Bugs { get; set; }

        public ChaoticaBug AddBug(String bugTitle, String bugDescription, int bugPriority = 1, bool bugResolved = false)
        {
            ChaoticaBug bug = new ChaoticaBug();
            bug.Title = bugTitle;
            bug.Description = bugDescription;
            bug.Priority = bugPriority;
            bug.Project = this;
            bug.Resolved = bugResolved;

            bug.Comments.Add(new ChaoticaComment("Hello", "This is so cool"));

            this.Bugs.Add(bug);

            return this.Bugs.ElementAt(this.Bugs.Count-1);
        }

        public ChaoticaProject(String title)
        {
            this.Title = title;
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

            projects.Add(new ChaoticaProject("Getting Started"));

            return projects;
        }
    }
}
