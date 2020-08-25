using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace onsales.Common.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage ="El campo no debe tener más de 50 carácteres")]
        [Required]
        public string Name { get; set;  }

        public ICollection<Department> Departments { get; set; }//Un country tiene una relacion de departamentos

        [DisplayName("Departments Number")]
        public int DepartmentsNumber => Departments == null ? 0 : Departments.Count;

    }
}
