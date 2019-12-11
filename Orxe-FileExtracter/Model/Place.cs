using System;
using System.Collections.Generic;
using System.Text;

namespace Orxe_FileExtracter
{
    public class Place
    {
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionNameLong { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SubClassification { get; set; }

        public Place()
        {
            RegionID = "";
            RegionName = "";
            RegionNameLong = "";
            Latitude = "";
            Longitude = "";
            SubClassification = "";
        }

        public string GetQueryString()
        {
            return $"\"{RegionID}\", \"{RegionName}\", \"{RegionNameLong}\", \"{Latitude}\", \"{Latitude}\", \"{SubClassification}\"";
        }
    }
}
