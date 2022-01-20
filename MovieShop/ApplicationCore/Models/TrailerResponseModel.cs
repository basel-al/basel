using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class TrailerResponseModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string TrailerUrl { get; set; }

    }
}
