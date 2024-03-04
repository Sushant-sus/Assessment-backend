using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodmandu.Model
{
    [Table("LayoutItems")]
    public class LayoutItems
    {
        [Key]
        public int LayoutItemId { get; set; }
        public string? type { get; set; }
        public string? title { get; set; }
        public int layoutId { get; set; }
        public int displayOrder { get; set; }
        public bool featured { get; set; }
        public string? image { get; set; }
        public string? subtitle1 { get; set; }
        public string? subtitle2 { get; set; }
        public string? subtitle3 { get; set; }
        public string? logo { get; set; }
        public string? extraInfo1 { get; set; }
        public string? extraInfo2 { get; set; }
        public int ParentLayoutItemId { get; set; }

        //[NotMapped]
        //public IFormFile? logoFile { get; set; }
        //[NotMapped]
        //public IFormFile? imagefile { get; set; }
    }
}
