using System;
using System.Collections.Generic;

namespace Clubby.Models
{
    public partial class User
    {
        public User()
        {
            Event = new HashSet<Event>();
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }
        public DateTime CreateAt { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
