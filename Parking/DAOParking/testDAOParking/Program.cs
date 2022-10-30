using System;
using sharedProject.IDAO;
using sharedProject.model;
using DAOParking.Connection;
using DAOParking.IDAOIMP;

namespace testDAOParking
{
    class Program
    {
        static void Main(string[] args)
        {
            IDAOParkingImp p = new IDAOParkingImp(DBConnection.getInstance("Server=localhost;DataBase=gestionparking;Uid=root;Pwd=;"));
            var parkings = p.findAll();
            foreach (Parking par in parkings)
                Console.WriteLine(par);
        }
    }
}
