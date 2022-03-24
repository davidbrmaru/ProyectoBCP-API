using System;
using System.Collections.Generic;

#nullable disable

namespace trabajo_final_API.Models
{
    public partial class TbSquad
    {
        public decimal Id { get; set; }
        public string SquadName { get; set; }
        public decimal IdTribu { get; set; }

        public virtual TbTribu IdTribuNavigation { get; set; }
    }
}
