﻿using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private static string connectionString;
        #endregion

        #region Constructor
        public NPGeekDAL(string connString)
        {
            connectionString = connString;
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

        public static List<SelectListItem> GetParkCodeList()
        {
            List<SelectListItem> output = new List<SelectListItem>();
            string parkCodeSearch = "select distinct parkCode, parkName from park";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(parkCodeSearch, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var park = new SelectListItem() { Text = Convert.ToString(reader["parkName"]),
                                                        Value = Convert.ToString(reader["parkCode"]) };
                    output.Add(park);
                }
            }

            return output;
        }

        public static HashSet<SelectListItem> GetAllStates()
        {
            var states = new HashSet<SelectListItem>()
        {
            new SelectListItem() { Value = "AL", Text = "Alabama" },
            new SelectListItem() { Value = "AK", Text = "Alaska" },
            new SelectListItem() { Value = "AZ", Text = "Arizona" },
            new SelectListItem() { Value = "AR", Text = "Arkansas" },
            new SelectListItem() { Value = "CA", Text = "California" },
            new SelectListItem() { Value = "CO", Text = "Colorado" },
            new SelectListItem() { Value = "CT", Text = "Connecticut" },
            new SelectListItem() { Value = "DE", Text = "Delaware" },
            new SelectListItem() { Value = "DC", Text = "District Of Columbia" },
            new SelectListItem() { Value = "FL", Text = "Florida" },
            new SelectListItem() { Value = "GA", Text = "Georgia" },
            new SelectListItem() { Value = "HI", Text = "Hawaii" },
            new SelectListItem() { Value = "ID", Text = "Idaho" },
            new SelectListItem() { Value = "IL", Text = "Illinois" },
            new SelectListItem() { Value = "IN", Text = "Indiana" },
            new SelectListItem() { Value = "IA", Text = "Iowa" },
            new SelectListItem() { Value = "KS", Text = "Kansas" },
            new SelectListItem() { Value = "KY", Text = "Kentucky" },
            new SelectListItem() { Value = "LA", Text = "Louisiana" },
            new SelectListItem() { Value = "ME", Text = "Maine" },
            new SelectListItem() { Value = "MD", Text = "Maryland" },
            new SelectListItem() { Value = "MA", Text = "Massachusetts" },
            new SelectListItem() { Value = "MI", Text = "Michigan" },
            new SelectListItem() { Value = "MN", Text = "Minnesota" },
            new SelectListItem() { Value = "MS", Text = "Mississippi" },
            new SelectListItem() { Value = "MO", Text = "Missouri" },
            new SelectListItem() { Value = "MT", Text = "Montana" },
            new SelectListItem() { Value = "NE", Text = "Nebraska" },
            new SelectListItem() { Value = "NV", Text = "Nevada" },
            new SelectListItem() { Value = "NH", Text = "New Hampshire" },
            new SelectListItem() { Value = "NJ", Text = "New Jersey" },
            new SelectListItem() { Value = "NM", Text = "New Mexico" },
            new SelectListItem() { Value = "NY", Text = "New York" },
            new SelectListItem() { Value = "NC", Text = "North Carolina"},
            new SelectListItem() { Value = "ND", Text = "North Dakota"},
            new SelectListItem() { Value = "OH", Text = "Ohio" },
            new SelectListItem() { Value = "OK", Text = "Oklahoma" },
            new SelectListItem() { Value = "OR", Text = "Oregon" },
            new SelectListItem() { Value = "PA", Text = "Pennsylvania" },
            new SelectListItem() { Value = "RI", Text = "Rhode Island" },
            new SelectListItem() { Value = "SC", Text = "South Carolina" },
            new SelectListItem() { Value = "SD", Text = "South Dakota" },
            new SelectListItem() { Value = "TN", Text = "Tennessee" },
            new SelectListItem() { Value = "TX", Text = "Texas" },
            new SelectListItem() { Value = "UT", Text = "Utah" },
            new SelectListItem() { Value = "VT", Text = "Vermont" },
            new SelectListItem() { Value = "VA", Text = "Virginia" },
            new SelectListItem() { Value = "WA", Text = "Washington" },
            new SelectListItem() { Value = "WV", Text = "West Virginia" },
            new SelectListItem() { Value = "WI", Text = "Wisconsin" },
            new SelectListItem() { Value = "WY", Text = "Wyoming" }
        };

            return states;
        }
        #endregion
    }
}    

