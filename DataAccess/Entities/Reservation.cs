using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime ReservationTime { get; set; }
        public int PeopleCount { get; set; }
        public string Comment { get; set; }
        public Restaurant Restaurant { get; set; }
        public User User { get; set; }

    }
}
