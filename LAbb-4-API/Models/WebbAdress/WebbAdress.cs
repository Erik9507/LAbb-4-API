using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Models
{
    public class WebbAdress
    {
        [Key]
        public int Id { get; set; }
        public string WebbSiteName { get; set; }
        public string Webbadress { get; set; }

        public Interests Interests { get; set; }
        public int FInterestId { get; set; }

    }
}
