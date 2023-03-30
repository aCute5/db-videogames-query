using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Genre { get; set; }

        public string? Publisher { get; set; }
        public int ReleaseYear { get; set; }
    }
}
