using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models
{
    public class Sermon
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "설교제목")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "설교제목")]
        public string Speaker { get; set; }

        [Required]
        [Display(Name = "설교날짜")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "설교링크")]
        public string SermonLink { get; set; }
    }
}
