using System;
using System.Collections.Generic;

namespace SeedData
{
    // classes
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        // foreign key for location 
        public int LocationId { get; set; }
        // navigation property
        public Location Location { get; set; }
    }


    class MainClass
    {

        // program
        public static void Main(string[] args)
        {
            List<Location> locations = new List<Location>()
            {
                new Location {LocationId = 1, Name = "Patio Door"},
                new Location {LocationId = 2, Name = "Garage"},
                new Location {LocationId = 3, Name = "Front Door"},
                new Location {LocationId = 4, Name = "Basement"}
            };


            DateTime startTime = DateTime.Now;

            DateTime currentDate = DateTime.Now;

            DateTime eventDate = currentDate.AddMonths(-6);
            List<Event> allEvents = new List<Event>();

            Random rand = new Random();

            while (eventDate < currentDate)
            {
                int eventNumber = rand.Next(0, 6);

                SortedList<DateTime, Event> allDailyEvents = new SortedList<DateTime, Event>();

                for (int i = 0; i < eventNumber; i++)
                {
                    int hr = rand.Next(0, 24);
                    int minute = rand.Next(0, 60);
                    int sec = rand.Next(0, 60);
                    int location = rand.Next(0, locations.Count);

                    DateTime eventDateTime = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hr, minute, sec);
                    Event newEvent = new Event { Flagged = false, Location = locations[location], LocationId = locations[location].LocationId, TimeStamp = eventDateTime };


                    allDailyEvents.Add(eventDateTime, newEvent);


                }

                foreach (var e in allDailyEvents)
                {
                    allEvents.Add(e.Value);
                }

                eventDate = eventDate.AddDays(1);

            }

            foreach (Event e in allEvents)
            {
                Console.WriteLine($"{e.TimeStamp},{e.Location.Name}");
            }

            DateTime endTime = DateTime.Now;
            TimeSpan difference = endTime.Subtract(startTime);

            Console.WriteLine($"Days: {difference.Days}");
            Console.WriteLine($"Hours: {difference.Hours}");
            Console.WriteLine($"Minutes: {difference.Minutes}");
            Console.WriteLine($"Seconds: {difference.Seconds}");
            Console.WriteLine($"Milliseconds: {difference.Milliseconds}");

        }
    }
}



