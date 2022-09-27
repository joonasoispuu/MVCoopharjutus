using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCoopkrodus.Models
{
    public class GDP
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 4)]
        [Required]
        public string Country { get; set; }

        [StringLength(60)]
        [Required]
        public string Region { get; set; }

        [Range(1, 100000)]
        [Required]
        public int? EstimatebyDollar { get; set; }

        [Range(1, 1000000000)]
        [Required]
        public int? Population { get; set; }


        [Display(Name ="Year calculated")]
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string Year { get; set; }
    }
}
