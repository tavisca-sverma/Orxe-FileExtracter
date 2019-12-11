using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orxe_FileExtracter
{
    public class FileExtractorTranslator
    {
       public static Place TranslateToPlace(string line)
        { 
        // RegionID | RegionName | RegionNameLong | Latitude | Longitude | SubClassification
            Place place = new Place();
            var items = line.Split('|')
                .Select(s => s.Trim().Replace("\"", ""))
                .Concat("      ".Split(' '))
                .ToList();
            place.RegionID = items[0];
            place.RegionName = items[1];
            place.RegionNameLong = items[2];
            place.Latitude = items[3];
            place.Longitude = items[4];
            place.SubClassification = items[5];
                
            return place;
        }

    }
}
