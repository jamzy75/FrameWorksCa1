using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksCA1
{
    internal class Racegoer : User
    {
        public string ticketNumber;
        public string seatNumber;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set { ticketNumber = value; }
        }

        public string SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

        // No-argument constructor
        public Racegoer()
        {
        }

        // Full constructor
        public Racegoer(string ticketNumber, string seatNumber)
        {
            this.ticketNumber = ticketNumber;
            this.seatNumber = seatNumber;
        }

        public override string ToString()
        {
            return $"TicketNumber: {ticketNumber}, SeatNumber: {seatNumber}";
        }
    }
}
