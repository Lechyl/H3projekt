using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public DepartmentDto Parent_Department { get; set; }


        public DepartmentDto(string departmentName, DepartmentDto parent_Department = null)
        {
            DepartmentName = departmentName;
            Parent_Department = parent_Department;
        }
        public DepartmentDto(int id, string departmentName, DepartmentDto parent_Department = null)
        {
            Id = id;
            DepartmentName = departmentName;
            Parent_Department = parent_Department;
        }
    }
}
