using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseDetailsResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}

