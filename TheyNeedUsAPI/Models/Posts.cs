using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheyNeedUsAPI.Models
{
    public class Posts
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string  Description { get; set; }
        public string SavedDate { get; set; }
        public string  Status { get; set; }
    }
}
