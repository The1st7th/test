using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace cityList.Models
{
    public class cityItem
    {
        private int  _id;
        private string  _cityname;
        private string  _countrycode;
        private string  _district;
        private int  _population;
        

        public cityItem(int id, string cityname, string countrycode, string district, int population)
        {
          _id = id;
          _cityname = cityname;
          _countrycode = countrycode;
          _district = district;
          _population = population;
        }
        public int getid(){
        return _id;
        }
        public string getcityname(){
        return _cityname;
        }
        public string getcountrycode(){
        return _countrycode;
        }
        public string getdistrict(){
        return _district;
        }
        public int getpopulation(){
        return _population;
        }
        public static List<cityItem> GetAll()
        {
            Console.WriteLine("hello");
            List<cityItem> allcityItems = new List<cityItem> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityItemId = rdr.GetInt32(0);
              string cityItemcityname = rdr.GetString(1);
              string cityItemcode = rdr.GetString(2);
              string cityItemcitydistrict = rdr.GetString(3);
              int cityItempopulation = rdr.GetInt32(4);
              cityItem newcityItem = new cityItem(cityItemId, cityItemcityname, cityItemcode, cityItemcitydistrict, cityItempopulation);
              allcityItems.Add(newcityItem);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allcityItems;
        }
    }
}
