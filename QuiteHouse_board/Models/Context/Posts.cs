using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiteHouse_board.Model.Context
{
    public class Posts
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public string Author { get; set; }
        [Required]
        public int ThreadId { get; set; }
        public string Image { get; set; }
    }
}
