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
        [Display(Name = "설교자")]
        public string Speaker { get; set; }

        [Required]
        [Display(Name = "설교본문")]
        public string Scripture { get; set; }

        [Required]
        [Display(Name = "설교날짜")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy년MM월dd일}",ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "설교링크")]
        public string SermonLink { get; set; }
    }
}
