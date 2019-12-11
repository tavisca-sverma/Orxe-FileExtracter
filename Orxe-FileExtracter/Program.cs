using Microsoft.Extensions.Configuration;
using Orxe_FileExtracter.DAL;
using System;
using System.Diagnostics;
using System.IO;

namespace Orxe_FileExtracter
{
    class Program
    {
        private static IConfiguration _iconfiguration;

        static void Main(string[] args)
        {
            SetConfigurationFromAppSettingsFile();
            Console.WriteLine("Enter 1 to start extraction of data:");
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                int count = 0;
                Console.WriteLine("Extraction started.. ");
                Console.WriteLine("Adding places to database...... ");
                StreamReader reader = File.OpenText("PointOfInterestCoordinatesList.txt");
                PlaceDAL placeDAL = new PlaceDAL(_iconfiguration);
                string line;
                Place place;
                line = reader.ReadLine();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while ((line = reader.ReadLine()) != null)
                {
                    Console.SetCursorPosition(0, 4);
                    count++;
                    place = FileExtractorTranslator.TranslateToPlace(line);
                    placeDAL.InsertPlace(place);
                    Console.Write(count);
                    
                            
                }
                stopwatch.Stop();
                Console.Write("Records added to database:"+count);
                Console.WriteLine("Time taken:"+stopwatch.Elapsed);
               
            }else
            {
                Console.WriteLine("Invalid Input ");
            }
  
            Console.ReadKey();
        }

        static void SetConfigurationFromAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
    }
}
