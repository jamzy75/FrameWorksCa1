using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksCA1
{
    internal class RaceEvent
    {
        public string eventName;

        public string location;

        public int numberOfRaces;

        public List<Race> races = new List<Race>();


        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }

        }

        public string Location
        {
            get { return location; }
            set { location = value; }

        }

        public int NumberOfRaces
        {
            get { return numberOfRaces; }
            set { numberOfRaces = value; }

        }

        public List<Race> Races
        {
            get { return races; }
            set { races = value; }
        }

        public RaceEvent()
        {
        }

        // Full constructor
        public RaceEvent(string eventName, string location, int numberOfRaces, List<Race> races)
        {
            this.eventName = eventName;
            this.location = location;
            this.numberOfRaces = numberOfRaces;
            this.races = races;
        }

        public RaceEvent(string eventName, string location, int numberOfRaces)
        {
            this.eventName = eventName;
            this.location = location;
            this.numberOfRaces = numberOfRaces;

        }
        public void addRace(Race race)
        {

            races.Add(race);
        }

        public override string ToString()
        {
            string display = $"EventName: {eventName}, Location: {location}, NumberOfRaces: {numberOfRaces}, Races: ";
            foreach (Race race in races)
            {
                display += race.ToString();
            }
            return display;
        }

    }
}