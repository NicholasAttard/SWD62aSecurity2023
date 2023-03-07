using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ReservationViewModel
    {
        public string Isbn { get; set; }
        public DateTime From { get; set; }

        [DateGreaterThanToValidator]
        public DateTime To { get; set; }

    }
}
