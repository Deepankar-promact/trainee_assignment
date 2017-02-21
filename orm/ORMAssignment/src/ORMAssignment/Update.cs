using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMAssignment
{
    /// <summary>
    /// Update Fields
    /// </summary>
    public class Update
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product product { get; set; }
    }
}
