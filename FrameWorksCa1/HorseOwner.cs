using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksCA1
{
    internal class HorseOwner : User
    {
        public string ownerName;


        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }

        }

        public HorseOwner()
        {
        }

        // Full constructor
        public HorseOwner(string ownerName)
        {
            this.ownerName = ownerName;
        }

        public void enterHorseInRace(Race race, Horse horse)
        {
            race.AddHorse(horse);
        }


        public override string ToString()
        {
            return $"OwnerName: {ownerName}";
        }
    }
}