using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Interfaces
{
    public interface IManagerService
    {
        bool Add(Manager manager);

        List<Manager> Get();

        Manager Get(int id);

        void Edit(Manager manager);

        void Delete(int id);

        void Save();
    }
}
