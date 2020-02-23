using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public int? Parent_DepartmentID { get; set; }

        public Department Parent_Department { get; set; }

        public Department() { }
        public Department(string departmentName, Department parent_Department = null)
        {
            DepartmentName = departmentName;
            Parent_Department = parent_Department;
        }
        public Department(int id, string departmentName, Department parent_Department = null)
        {
            Id = id;
            DepartmentName = departmentName;
            Parent_Department = parent_Department;
        }
    }
}
