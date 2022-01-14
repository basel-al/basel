using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CastModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
/*        public string Gender{ get; set; }
        public string TmdbUrl { get; set; }*/
        public string ProfilePath { get; set; }
    }
}
