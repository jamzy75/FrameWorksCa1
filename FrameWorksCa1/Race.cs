using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksCA1
{
    internal class Race
    {
        public string raceName;

        public DateTime startTime;

        public List<Horse> horses = new List<Horse>();



        public string RaceName
        {
            get { return raceName; }
            set { raceName = value; }

        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }

        }
        public List<Horse> horse
        {
            get { return horse; }
            set { horse = value; }
        }


        public Race()
        {
        }

        // Full constructor
        public Race(string raceName, DateTime startTime, List<Horse> horses)
        {
            this.raceName = raceName;
            this.startTime = startTime;
            this.horses = horses;
        }

        public void AddHorse(Horse horse)
        {
            horses.Add(horse);
        }

        public List<Horse> GetHorses()
        {
            return horses;
        }




        public override string ToString()
        {
            string display = $"RaceName: {raceName}, StartTime: {startTime}, Horses: ";
            foreach (Horse horse in horses)
            {
                display += horse.ToString();
            }
            return display;
        }


    }
}