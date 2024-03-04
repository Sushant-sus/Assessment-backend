using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodmandu.Model
{
    [Table("Layouts")]
    public class Layouts
    {
        [Key]
        public int layoutId { get; set; }
        public string layout { get; set; }
        public int displayOrder { get; set; }
        public string title { get; set; }
        public string tagline { get; set; }
        public string SliderLinkJSON { get; set; }
        public string SeeMoreJSON { get; set; }
        public string seeMore { get; set; }
        public string ratio { get; set; }
        public int webdisplayorder { get; set; }
        public bool allowwebdisplay { get; set; }
    }
}
