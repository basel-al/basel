using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }

        //foreign key
        public int MovieId { get; set; }

        public string? TrailerUrl { get; set; }
        public string? Name { get; set; }


        //navigation property
        public Movie Movie { get; set; }
        
    }
}
