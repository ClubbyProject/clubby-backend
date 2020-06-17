using System;
using System.Collections.Generic;

namespace Clubby.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int? EventId { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; }

        public virtual Club Club { get; set; }
        public virtual User CreateByUser { get; set; }
        public virtual Event Event { get; set; }
    }
}
