using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Orxe_FileExtracter.DAL
{
    class PlaceDAL
    {
        private string _connectionString;
        public PlaceDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public  void InsertPlace(Place place)
        {
            try
            {
                using (MySqlConnection con =  new MySqlConnection(_connectionString))
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = con;
                    command.CommandText = "sp_InsertPlace";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection?.Open();
                    AddParamatersToCommand(command,place);

                    command.ExecuteNonQueryAsync(); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
   
        }

        private void AddParamatersToCommand(MySqlCommand command, Place place)
        {
            command.Parameters.Add(
                  new MySqlParameter("@p_RegionID", place.RegionID));
            command.Parameters.Add(
               new MySqlParameter("@p_RegionName", place.RegionName));
            command.Parameters.Add(
               new MySqlParameter("@p_RegionNameLong", place.RegionNameLong));
            command.Parameters.Add(
               new MySqlParameter("@p_Latitude", place.Latitude));
            command.Parameters.Add(
               new MySqlParameter("@p_Longitude", place.Longitude));
            command.Parameters.Add(
               new MySqlParameter("@p_SubClassification", place.SubClassification));
        }
    }

}
