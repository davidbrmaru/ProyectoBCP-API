using System;
using System.Collections.Generic;

#nullable disable

namespace trabajo_final_API.Models
{
    public partial class TbTribu
    {
        public TbTribu()
        {
            TbSquads = new HashSet<TbSquad>();
        }

        public decimal Id { get; set; }
        public string TribuName { get; set; }

        public virtual ICollection<TbSquad> TbSquads { get; set; }
    }
}
