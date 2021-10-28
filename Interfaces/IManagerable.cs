using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Interfaces
{
    public interface IManagerable
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        bool Married { get; set; }
        string Phone{ get; set; }
        decimal Salary{ get; set; }
    }
}
