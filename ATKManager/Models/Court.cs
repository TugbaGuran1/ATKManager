using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATKManager.Models
{
    [Table("Court")]
    public class Court
    {
        [Key]
        public int CourtID { get; set; }
        public string CourtName { get; set; }
   
        public ICollection<CourtScheduleItem> CourtScheduleItems { get; set; }
    }

}
