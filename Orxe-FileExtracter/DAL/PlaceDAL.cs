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

   
        public void InsertAllPlaces(List<Place> placesList)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    var placesListQueryString = new StringBuilder();
                    foreach (var place in placesList)
                    {
                        placesListQueryString.Append("(");
                        placesListQueryString.Append(place.GetQueryString());
                        placesListQueryString.Append(")");
                        placesListQueryString.Append(",");
                     
                    }
                    placesListQueryString.Remove(placesListQueryString.Length - 1, 1);

                    MySqlCommand sizeCommand = new MySqlCommand();
                    sizeCommand.Connection = con;
                    sizeCommand.Connection?.Open();
                    sizeCommand.CommandText = "SET GLOBAL max_allowed_packet=100*1024*1024;";
                    sizeCommand.ExecuteNonQuery();
                    sizeCommand.Connection.Close();

                    string query = "Insert into places values"+placesListQueryString;
                    MySqlCommand insertCommand = new MySqlCommand();
                    insertCommand.Connection = con;
                    insertCommand.Connection?.Open();
                    insertCommand.CommandText = query;

                    insertCommand.ExecuteNonQuery();
                    insertCommand.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
