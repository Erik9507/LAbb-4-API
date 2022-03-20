using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Models
{
    public class Interests
    {
        [Key]
        public int Id { get; set; }
        public string InterestName { get; set; }
        public string InterestDescription { get; set; }

        public Person person { get; set; }
        public int FPersonId { get; set; }
        
    }
}
