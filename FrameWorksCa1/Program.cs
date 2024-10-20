using FrameWorksCA1;

namespace FrameWorksCa1
{
    internal class Program
    {
        static RaceCourseManager raceCourseManager = new RaceCourseManager();
        static List<HorseOwner> horseOwners = new List<HorseOwner>();
        static List<Racegoer> racegoers = new List<Racegoer>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nHorse Racing Management System Menu:");
                Console.WriteLine("1. Create a new Race Event (RaceCourse Manager)");
                Console.WriteLine("2. Add a Race to an Event (RaceCourse Manager)");
                Console.WriteLine("3. Upload a list of Horses to a Race (RaceCourse Manager)");
                Console.WriteLine("4. Enter a Horse in a Race (Horse Owner)");
                Console.WriteLine("5. View Upcoming Events and Races (Racegoer)");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateRaceEvent();
                        break;
                    case "2":
                        AddRaceToEvent();
                        break;
                    case "3":
                        UploadHorsesToRace();
                        break;
                    case "4":
                        EnterHorseInRace();
                        break;
                    case "5":
                        ViewUpcomingEvents();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void ViewUpcomingEvents()
        {
            List<RaceEvent> events = raceCourseManager.ViewEvents();

            if (events.Count > 0)
            {
                foreach (RaceEvent raceEvent in events)
                {
                    Console.WriteLine(raceEvent.ToString());
                }
            }
            else
            {
                Console.WriteLine("No upcoming events.");
            }
        }




            private static void EnterHorseInRace()
        {
            Console.Write("Enter owner name: ");
            string ownerName = Console.ReadLine();
            HorseOwner owner = null;

            foreach (HorseOwner ho in horseOwners)
            {
                if (ho.OwnerName == ownerName)
                {
                    owner = ho;
                    break;
                }
            }

            if (owner == null)
            {
                Console.WriteLine("Owner is not found,you are about to create new owner profile.");
                owner = new HorseOwner(ownerName);
                horseOwners.Add(owner);
            }

            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();
            RaceEvent raceEvent = raceCourseManager.ViewEventDetails(eventName);

            if (raceEvent != null)
            {
                Console.Write("Enter race name: ");
                string raceName = Console.ReadLine();
                Race race = null;

                foreach (Race r in raceEvent.Races)
                {
                    if (r.RaceName == raceName)
                    {
                        race = r;
                        break;
                    }
                }

                if (race != null)
                {
                    Console.Write("Horse Name: ");
                    string horseName = Console.ReadLine();
                    Console.Write("Horse ID: ");
                    string horseID = Console.ReadLine();
                    Console.Write("Date of Birth (format: yyyy-MM-dd): ");
                    DateTime dob = DateTime.Parse(Console.ReadLine());

                    Horse horse = new Horse(horseID, horseName, dob);
                    owner.enterHorseInRace(race, horse);
                    Console.WriteLine("Horse entered in race.");
                }
                else
                {
                    Console.WriteLine("Race is not there.");
                }
            }
            else
            {
                Console.WriteLine("Event is not there.");
            }
        }






        private static void UploadHorsesToRace()
        {
            throw new NotImplementedException();
        }

        private static void AddRaceToEvent()
        {
            throw new NotImplementedException();
        }

        private static void CreateRaceEvent()
        {
            throw new NotImplementedException();
        }
    }
    }

