using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramacionAvanzada.Web.Models
{
    public class Car
    {

        [Key]
        public int Id_Car { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Data_Created { get; set; }
    }
}