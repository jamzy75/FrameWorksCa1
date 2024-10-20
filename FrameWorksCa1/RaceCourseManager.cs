using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksCA1
{
    internal class RaceCourseManager : User
    {
        private List<RaceEvent> Events = new List<RaceEvent>();

        public void CreateEvent(string eventName, string location, int numberOfRaces)
        {
            RaceEvent raceEvent = new RaceEvent(eventName, location, numberOfRaces);
            Events.Add(raceEvent);
        }

       
       


    }
}