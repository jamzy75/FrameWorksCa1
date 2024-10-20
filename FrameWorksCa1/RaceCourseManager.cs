﻿using System;
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

        public void AddRaceToEvent(RaceEvent raceEvent, Race race)
        {
            raceEvent.Races.Add(race);
        }

        public void AddHorseToRace(Race race, Horse horse)
        {
            race.AddHorse(horse);
        }

        public List<RaceEvent> ViewEvents()
        {
            return Events;
        }

        public RaceEvent ViewEventDetails(string eventName)
        {
            foreach (var raceEvent in Events)
            {
                if (raceEvent.EventName == eventName) // 
                {
                    return raceEvent;
                }
            }
            return null; // Return null if no event is found
        }

    }
}