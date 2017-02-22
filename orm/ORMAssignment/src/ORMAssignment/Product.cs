using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMAssignment
{
    /// <summary>
    /// Product Fields
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string HomePageURL { get; set; }

        public List<Update> updateList { get; set; } 
        
    }
}
