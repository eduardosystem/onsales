using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace onsales.Common.Entities
{
    public class Department
    {
        public int Id { get; set; }

        
        [MaxLength(50, ErrorMessage = "El campo no debe tener más de 50 carácteres")]
        [Required]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }//Un departamento tiene una relacion de ciudades

        [DisplayName("Cities Number")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;//Ciudades que tenemos

        //Para nosotros saber a que pais pertenece
        [JsonIgnore]//Json
        [NotMapped]//Siempre agregar
        public int IdCountry { get; set; }
    }

}
