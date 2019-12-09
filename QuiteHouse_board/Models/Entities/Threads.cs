using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public DateTime lastBump { get; set; }
        public Posts MainPost { get; set; }
        public List<Posts> Posts { get; set; }
    }
}
