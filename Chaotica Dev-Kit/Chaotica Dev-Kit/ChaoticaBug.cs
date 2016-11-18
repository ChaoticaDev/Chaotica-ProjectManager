using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Chaotica_Dev_Kit
{
    class ChaoticaBugVote
    {
        public ObservableCollection<ChaoticaUser> Voted = new ObservableCollection<ChaoticaUser>();
    }

    class ChaoticaBug
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String TimeStamp { get; set; }

        public int Priority { get; set; }

        public bool Resolved { get; set; }

        public ChaoticaProject Project { get; set; }

        public ObservableCollection<ChaoticaComment> Comments { get; set; }

        public ChaoticaBug()
        {
            Comments = new ObservableCollection<ChaoticaComment>();
        }

        public ChaoticaComment AddComment(String title, String commentText)
        {
            Comments.Add(new ChaoticaComment(title, commentText));

            return this.Comments.ElementAt(this.Comments.Count-1);
        }

    }
}
