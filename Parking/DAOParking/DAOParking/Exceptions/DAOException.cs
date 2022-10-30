using System;

namespace DAOParking.Exceptions
{
    public class DAOException : Exception
    {
        public DAOException()
        {

        }
        public DAOException(string msg) : base(msg)
        {

        }
    }
}
