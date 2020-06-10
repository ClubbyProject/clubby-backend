using System.Collections.Generic;

namespace Clubby.Models
{
    public class Club
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<UserInClub> Users { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}