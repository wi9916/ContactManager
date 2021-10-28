using ContactManager.Interfaces;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    public class ManagerService : IManagerService
    {
        private readonly DataContext _db;

        public ManagerService(DataContext dataContext)
        {
            _db = dataContext;
        }

        public bool Add(Manager manager)
        {
            manager.Id = default(int);
            _db.Managers.Add(manager);
            return true;
        }

        public List<Manager> Get()
        {
            var managers = new List<Manager>();
            foreach (var obj in _db.Managers)
                managers.Add(Get(obj.Id));

            return managers;
        }

        public Manager Get(int id)
        {
            var manager = _db.Managers.Find(id);
            return manager;
        }

        public void Edit(Manager manager)
        {
            var entity = _db.Managers.Find(manager.Id);
            if (entity == null)
            {
                return;
            }

            _db.Entry(entity).CurrentValues.SetValues(manager);
            Save();
        }

        public void Delete(int id)
        {
            Manager manager = _db.Managers.Find(id);
            if (manager != null)
                _db.Managers.Remove(manager);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
