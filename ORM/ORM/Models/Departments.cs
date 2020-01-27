using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public Departments Parent_Department { get; set; }


        public Departments(string department, Departments parent_Department = null)
        {
            Department = department;
            Parent_Department = parent_Department;
        }
        public Departments(int id, string department, Departments parent_Department = null)
        {
            Id = id;
            Department = department;
            Parent_Department = parent_Department;
        }
    }
}
