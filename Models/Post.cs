using System;
using System.Collections;

namespace Clubby.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime CreateAt { get; set; }

        public Club Club { get; set; }
        public Event Event { get; set; }
        public User CreateBy { get; set; }
    }
}