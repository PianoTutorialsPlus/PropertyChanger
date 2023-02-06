using PropertyChanger.Model.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PropertyChanger.Model
{
    public class MP3File : IMP3File
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Filename is required")]
        [RegularExpression(@"[0-9]{2}\s[-]\s[\w\s\.\`]{0,}[.mp3]$",
            ErrorMessage = "Format is incorrect")]
        public string Name { get; set; }
        public string Title { get; set; }
        public int TitleNumber { get; set; }
    }
}
