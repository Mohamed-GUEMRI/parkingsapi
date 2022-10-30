using DAOParking.Connection;
using DAOParking.Exceptions;
using MySql.Data.MySqlClient;
using sharedProject.IDAO;
using sharedProject.model;
using System;
using System.Collections.Generic;

namespace DAOParking.IDAOIMP
{
    public class IDAOParkingImp : IDAOParking
    {
        private MySqlConnection myConnection;
        private MySqlDataReader reader;
        private MySqlCommand command;
        public IDAOParkingImp(DBConnection conn)
        {
            myConnection = conn.connection;
            command = new MySqlCommand();
            command.Connection = myConnection;
        }
        public bool Add(Parking p)
        {
            try
            {
                string query = "insert into parkings(capacity, location) values('" + p.capacity + "','" + p.localisation + "')";
                command.CommandText = query;
                myConnection.Open();

                command.ExecuteNonQuery();

                myConnection.Close();
                return true;
            }
            catch (Exception)
            {
                throw new DAOException("failed to add parking");
            }
        }

        public bool Delete(Parking p)
        {
            try
            {
                string query = "delete from parkings where id=" + p.id;
                command.CommandText = query;
                myConnection.Open();
                bool result = command.ExecuteNonQuery() == 1;

                myConnection.Close();
                return result;
            }
            catch (Exception)
            {
                throw new DAOException("failed to delete parking");
            }
        }

        public List<Parking> findAll()
        {
            try
            {
                List<Parking> parkings = new List<Parking>();
                string query = "select * from parkings";
                command.CommandText = query;
                myConnection.Open();
                command.ExecuteNonQuery();  

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Parking p = new Parking();
                    p.id = reader.GetInt32(0);
                    p.capacity = reader.GetInt32(1);
                    p.localisation = reader.GetString(2);
                    parkings.Add(p);
                }

                myConnection.Close();
                return parkings;
            }
            catch (Exception)
            {
                throw new DAOException("failed select parking by id");
            }
        }

        public Parking GetById(int id)
        {
            try
            {
                Parking p = null;
                string query = "select * from parkings where id =" + "'" + id + "'";
                command.CommandText = query;
                myConnection.Open();
                command.ExecuteNonQuery();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    p = new Parking();
                    p.id = reader.GetInt32(0);
                    p.capacity = reader.GetInt32(1);
                    p.localisation = reader.GetString(2);
                }

                myConnection.Close();
                return p;
            }
            catch (Exception)
            {
                throw new DAOException("failed select parking by id");
            }
        }

        public bool Update(int id, Parking p)
        {
            try
            {
                string query = "update parkings set capacity ='" + p.capacity + "',location ='" + p.localisation + "' where id =" + id;
                command.CommandText = query;
                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();
                return true;
            }
            catch (Exception)
            {
                throw new DAOException("failed to update the parking");
            }
        }
    }
}
