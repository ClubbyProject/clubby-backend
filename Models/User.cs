using System;
using System.Collections.Generic;

namespace Clubby.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }
        public DateTime CreateAt { get; set; }
        public string Token { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Admin> ClubAdmin { get; set; }
        public ICollection<UserInClub> Club { get; set; }
    }
}