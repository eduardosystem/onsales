using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onsales.Common.Entities
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo no debe tener más de 50 carácteres")]
        [Required]
        public string Name { get; set; }
        
        [JsonIgnore]//Json
        [NotMapped]//Siempre agregar
        public int IdDepartament { get; set; }
    }
}
