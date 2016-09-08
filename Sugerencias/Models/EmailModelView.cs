using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sugerencias.Models
{
    public class EmailModelView
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        public string Telefono { get; set; }
        [Display(Name = "Queja/Reclamo/Sugerencia")]
        public string Sugerencia { get; set; }
    }
}