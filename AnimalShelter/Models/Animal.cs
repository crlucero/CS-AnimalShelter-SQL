using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;
using System.Linq;

namespace AnimalShelter.Models
{
    public class Animal
    {
        private int _id;
        private string _name;
        private string _sex;
        private string _type;
        

        public Animal(int id, string name, string sex, string type)
        {
            _id = id;
            _name = name;
            _sex = sex;
            _type = type;
          
        }

          public Animal(string name, string sex, string type)
        {
            _name = name;
            _sex = sex;
            _type = type;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetSex()
        {
            return _sex;
        }

        public string GetAnimalType()
        {
            return _type;
        }

         public void Save()
            {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO Animal (name, sex, type) VALUES (@AnimalName, @AnimalSex, @AnimalType);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@AnimalName";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            MySqlParameter sex = new MySqlParameter();
            sex.ParameterName = "@AnimalSex";
            sex.Value = this._sex;
            cmd.Parameters.Add(sex);

            MySqlParameter type = new MySqlParameter();
            type.ParameterName = "@AnimalType";
            type.Value = this._type;
            cmd.Parameters.Add(type);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            }

            public static List<Animal> GetAll()
            {
                List<Animal> allAnimals = new List<Animal> {};
                MySqlConnection conn = DB.Connection();
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT * FROM Animal ORDER BY name;";
                MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
                while(rdr.Read())
                {
                    int AnimalId = rdr.GetInt32(0);
                    string AnimalName = rdr.GetString(1);
                    string AnimalSex = rdr.GetString(2);
                    string AnimalType = rdr.GetString(3);
                    Animal newAnimal = new Animal(AnimalId, AnimalName, AnimalSex, AnimalType);
                    allAnimals.Add(newAnimal);
                }
                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
                return allAnimals;
            }

            public static void DeleteAll()
            {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM Animal;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            }

            public static List<Animal> GetAllSortRecent()
            {
                List<Animal> allAnimals = new List<Animal> {};
                MySqlConnection conn = DB.Connection();
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT * FROM Animal ORDER BY id DESC;";
                MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
                while(rdr.Read())
                {
                    int AnimalId = rdr.GetInt32(0);
                    string AnimalName = rdr.GetString(1);
                    string AnimalSex = rdr.GetString(2);
                    string AnimalType = rdr.GetString(3);
                    Animal newAnimal = new Animal(AnimalId, AnimalName, AnimalSex, AnimalType);
                    allAnimals.Add(newAnimal);
                }
                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
                return allAnimals;
            }

            public static List<Animal> GetAnimal(int animalId)
            {
                List<Animal> allAnimals = new List<Animal> {};
                MySqlConnection conn = DB.Connection();
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT * FROM Animal WHERE id = " + animalId + ";";
                MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
                while(rdr.Read())
                {
                    int AnimalId = rdr.GetInt32(0);
                    string AnimalName = rdr.GetString(1);
                    string AnimalSex = rdr.GetString(2);
                    string AnimalType = rdr.GetString(3);
                    Animal newAnimal = new Animal(AnimalId, AnimalName, AnimalSex, AnimalType);
                    allAnimals.Add(newAnimal);
                }
                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
                return allAnimals;
            }

        

    }
}
