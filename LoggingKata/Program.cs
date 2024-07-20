using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            

            //logger.LogInfo("Log initialized");

            
            string[] lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            //logger.LogInfo($"Lines: {lines[0]}");

            // new instance of the TacoParser class
            TacoParser parser = new TacoParser();

            
            ITrackable[] locations = lines.Select(parser.Parse).ToArray();
            //ITrackable[] locations  = lines.Select(line => parser.Parse(line)).ToArray();
            //List<ITrackable> tacoList = new List<ITrackable>();
            //foreach (var line in lines)
            //{
            //    tacoList.Add(parser.Parse(line));
            //}


            
            ITrackable tb1 = new TacoBell();
            ITrackable tb2 = new TacoBell();

            
            double distance = 0;

            
            for (int i = 0; i < locations.Length; i++)
            {
                ITrackable locA = locations[i];
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int j = 0; j < locations.Length; j++)
                {
                    ITrackable locB = locations[j];
                    GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if(corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tb1 = locA;
                        tb2 = locB;
                    }
                }
            }

            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells located furthest from each other.");
            Console.WriteLine($"The distance in meters between the two taco bells is this {distance}");

            

            
        }
    }
}
