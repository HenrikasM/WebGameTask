using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebGameTask.Models
{
    public class Solution
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PlayerName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string TaskName { get; set; }
    }
}
