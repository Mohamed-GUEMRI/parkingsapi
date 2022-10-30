using shareedproject.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shareedproject.IDAO
{
    public interface IDAOParking
    {
        List<Parking> findAll();
        bool Add(Parking p);
        bool Update(int id, Parking p);
        bool Delete(Parking p);
        Parking GetById(int id);
    }
}
