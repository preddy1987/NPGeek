using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class NPGeekDAL : INPGeekDAL
    {

        #region Properties and Variables
        private string connectionString;
        #endregion

        #region Constructor
        public NPGeekDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region Methods
        public List<Park> GetAllParks()
        {
            List<Park> output = new List<Park>();
            
                //Create a SqlConnection to our database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select * from park", connection);

                    // Execute the query to the database
                    SqlDataReader reader = cmd.ExecuteReader();

                    // The results come back as a SqlDataReader. Loop through each of the rows
                    // and add to the output list
                    while (reader.Read())
                    {
                        // Add the department to the output list                       
                        output.Add(MapToPark(reader));
                    }
                }
            
            
            return output;
        }

        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @parkCode", conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    park = MapToPark(reader);
                }
            }
            return park;
        }

        public Park MapToPark(SqlDataReader reader)
        {
            return new Park()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberofCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
        
        }

        public Forecast GetForecast(string parkCode)
        {
            Forecast forecast = new Forecast();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode", conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forecast.ParkCode = Convert.ToString(reader["parkCode"]);
                    forecast.DayOfTheWeek = Convert.ToInt32(reader["fiveDayForecastValue"]);
                    forecast.LowTemp = Convert.ToInt32(reader["low"]);
                    forecast.HighTemp = Convert.ToInt32(reader["high"]);
                    forecast.DailyForecast = Convert.ToString(reader["forecast"]);
                }
            }
            return forecast;
        }
        #endregion
    }
}
