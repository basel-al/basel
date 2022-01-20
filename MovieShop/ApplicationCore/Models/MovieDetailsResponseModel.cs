using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieDetailsResponseModel
    {
        public MovieDetailsResponseModel()
        {
            Genres = new List<GenreModel>();
            Trailers = new List<TrailerResponseModel>();
            Casts = new List<CastResponseModel>();
            Reviews = new List<UserReviewResponseModel>();
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal? Rating { get; set; }
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string? ImdbUrl { get; set; }
        public string? TmdbUrl { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public List<GenreModel> Genres { get; set; }
        public List<TrailerResponseModel> Trailers { get; set; }
        public List<CastResponseModel> Casts { get; set; }
        public List<UserReviewResponseModel> Reviews { get; set; }


    }
}
