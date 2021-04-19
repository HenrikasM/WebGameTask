using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebGameTask.Models
{
    public class GameTask
    {
        [Key]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Input { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Output { get; set; }
    }
}
