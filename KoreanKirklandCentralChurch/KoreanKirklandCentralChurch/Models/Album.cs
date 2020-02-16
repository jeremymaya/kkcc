using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoreanKirklandCentralChurch.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "앨범커버링크")]
        public string Thumbnail { get; set; }

        [Required]
        [Display(Name = "앨범제목")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "앨범날짜")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "앨범링크")]
        public string AlbumLink { get; set; }
    }
}
