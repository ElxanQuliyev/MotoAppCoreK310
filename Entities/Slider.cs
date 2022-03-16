using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Slider:BaseEntity
    {
        [MaxLength(150)]
        public string? SubTitle { get; set; }
        [MaxLength(250)]
        public string? Title { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [MaxLength(650)]
        public string PhotoUrl { get; set; } = null!;
        [MaxLength(650)]
        public string? BackgroundUrl { get; set; }
    }

}
