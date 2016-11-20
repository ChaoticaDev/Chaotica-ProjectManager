using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;

namespace Chaotica_Dev_Kit
{
    class ChaoticaBugVote
    {
        public ObservableCollection<ChaoticaUser> Voted = new ObservableCollection<ChaoticaUser>();
    }

    class ChaoticaBug
    {
        public String ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String TimeStamp { get; set; }

        public Image _pImage;
        public ImageSource priorityImage
        {
            get
            {
                Image img = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                Uri uri;
                switch (this.Priority)
                {
                    case 0:
                    default:
                        uri = new Uri("ms-appx:///Assets/arrow-circle-down_256_0_ff0000_none.png");
                        break;

                    case 1:
                        uri = new Uri("ms-appx:///Assets/arrow-circle-up_256_0_ff0000_none.png");
                        break;

                    case 2:
                        uri = new Uri("ms-appx:///Assets/arrow-circle-down_256_0_faff00_none.png");
                        break;

                    case 3:
                        uri = new Uri("ms-appx:///Assets/arrow-circle-up_256_0_faff00_none.png");
                        break;

                    case 4:
                        uri = new Uri("ms-appx:///Assets/arrow-circle-down_256_0_2ab800_none.png");
                        break;

                    case 5:
                        uri = new Uri("ms-appx:///Assets/arrow-circle-up_256_0_2ab800_none.png");
                        break;
                }
                bitmapImage.UriSource = uri;
                img.Source = bitmapImage;

                this._pImage = img;
                return img.Source;
            }

            set
            {
                
            }
        }

        public int Priority { get; set; }

        public bool Resolved { get; set; }

        public ChaoticaProject Project { get; set; }

        public ObservableCollection<ChaoticaComment> Comments { get; set; }

        public ChaoticaBug(String _id, String _title, String _description, String _timestamp, int _priority, bool _resolved, ChaoticaProject proj)
        {
            Comments = new ObservableCollection<ChaoticaComment>();

            this.ID = _id;
            this.Title = _title;
            this.Description = _description;
            this.TimeStamp = _timestamp;
            this.Priority = _priority;
            this.Resolved = _resolved;
            this.Project = proj;
        }

        public ChaoticaComment AddComment(String title, String commentText)
        {
            Comments.Add(new ChaoticaComment(title, commentText));

            return this.Comments.ElementAt(this.Comments.Count-1);
        }

    }
}
