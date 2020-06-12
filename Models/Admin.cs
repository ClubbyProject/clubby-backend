using System;
using System.Collections.Generic;

namespace Clubby.Models
{
    public partial class Admin
    {
        public int UserId { get; set; }
        public int? ClubId { get; set; }

        public virtual Club Club { get; set; }
        public virtual User User { get; set; }
    }
}
