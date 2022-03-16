using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category:BaseEntity
    {
        [MaxLength(150)]
        public string Title { get; set; } = null!;
        [MaxLength(350)]
        public string? Description { get; set; }
        [MaxLength(650)]
        public string? PhotoUrl { get; set; }
    }

}
