using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATKManager.Models
{

    [Table("CourtSchedule")]
    public class CourtScheduleItem
    {
        [Key]

        public int TimeTableID { get; set; }
  
        public string UserID { get; set; }

        public DateTime ReservationDate { get; set; }
        public int CourtID { get; set; }
        public Court Court { get; set; }

    }
}
