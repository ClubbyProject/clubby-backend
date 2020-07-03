using System;
using System.Collections.Generic;

namespace Clubby.Models
{
    public partial class Club
    {
        public Club()
        {
            Event = new HashSet<Event>();
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClubLocation { get; set; }
        public string DutyTime { get; set; }
        public string MeetLocation { get; set; }
        public string MeetTime { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
