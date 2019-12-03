    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiteHouse_board.Model.Context
{
    public class Threads
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int MainPostId { get; set; }
        public List<Posts> Posts { get; set; }
    }
}
