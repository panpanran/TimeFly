using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeFlyApi.Models
{
    public class Logger
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
