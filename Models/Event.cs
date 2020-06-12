using System;
using System.Collections.Generic;

namespace Clubby.Models
{
    public partial class Event
    {
        public Event()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CreateByClub { get; set; }
        public int? CreateByUser { get; set; }

        public virtual Club CreateByClubNavigation { get; set; }
        public virtual User CreateByUserNavigation { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
