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
            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();
            RaceEvent raceEvent = raceCourseManager.ViewEventDetails(eventName);

            if (raceEvent != null)
            {
                Console.Write("Enter race name: ");
                string raceName = Console.ReadLine();

                Race race = null;

                // Find the race by name
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
                    Console.WriteLine("Enter horses (leave name blank to stop uploading horses):");

                    while (true)
                    {
                        Console.Write("Horse Name: ");
                        string horseName = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(horseName)) break;

                        Console.Write("Horse ID: ");
                        string horseID = Console.ReadLine().Trim();

                        // Validation: i made this to check if a horse with the same ID already exists in the race
                        bool horseIdExists = false;
                        foreach (Horse h in race.horses)
                        {
                            if (h.HorseID == horseID)
                            {
                                horseIdExists = true;
                                break;
                            }
                        }
                        if (horseIdExists)
                        {
                            Console.WriteLine($"Error: A horse with ID {horseID} already exists in this race.");
                            continue;
                        }

                        // Validation: I made this to check if a horse with the same name (case-insensitive) already exists in the race
                        bool horseNameExists = false;
                        foreach (Horse h in race.horses)
                        {
                            if (string.Equals(h.HorseName.Trim(), horseName, StringComparison.OrdinalIgnoreCase))
                            {
                                horseNameExists = true;
                                break;
                            }
                        }
                        if (horseNameExists)
                        {
                            Console.WriteLine($"Error: A horse with name \"{horseName}\" already exists in this race.");
                            continue;
                        }

                        Console.Write("Date of Birth (format: yyyy-MM-dd): ");
                        DateTime dob = DateTime.Parse(Console.ReadLine());

                        // If the validation passess, add the horse to the race
                        Horse horse = new Horse(horseID, horseName, dob);
                        race.AddHorse(horse);
                        Console.WriteLine("Horse added to race.");
                    }
                }
                else
                {
                    Console.WriteLine("Race not found.");
                }
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }









        private static void AddRaceToEvent()
        {
            Console.Write("Enter event name to add a race to: ");
            string eventName = Console.ReadLine();
            RaceEvent raceEvent = raceCourseManager.ViewEventDetails(eventName);

            if (raceEvent != null)
            {
                Console.Write("Enter race name (or press Enter to get an auto-generate one): ");
                string raceName = Console.ReadLine();
                if (string.IsNullOrEmpty(raceName))
                {
                    raceName = $"Race {raceEvent.Races.Count + 1}";
                }

                Console.Write("Enter race start time (format: yyyy-MM-dd HH:mm): ");
                DateTime startTime = DateTime.Parse(Console.ReadLine());

                Race race = new Race(raceName, startTime, new List<Horse>());
                raceEvent.addRace(race);
                Console.WriteLine("Race added to event successfully!");
            }
            else
            {
                Console.WriteLine("Event was not found.");
            }
        }


        static void CreateRaceEvent()
        {
            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();
            Console.Write("Enter location: ");
            string location = Console.ReadLine();
            Console.Write("Enter number of races: ");
            int numberOfRaces = int.Parse(Console.ReadLine());

            raceCourseManager.CreateEvent(eventName, location, numberOfRaces);
            Console.WriteLine("Race event created successfully!");
        }
    }
    }

