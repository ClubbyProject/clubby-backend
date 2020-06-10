using System;
using System.Collections.Generic;

namespace Clubby.Models
{
    public class Event
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<Post> Posts { get; set; }
        public Club CreateByClub { get; set; }
        public User CreateByUser { get; set; }
    }
}