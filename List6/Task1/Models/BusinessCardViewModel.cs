using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class BusinessCardViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname{ get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string IdNumber { get; set; }
        
        [Required]
        public string Country{ get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int HouseApartmentNumber { get; set; }

       public int? FontSize { get; set; }
        public string? Typeface { get; set; }
        public string? BackgroundColor { get; set; }
        public bool IsBold { get; set; }
        public bool IsUnderlined { get; set; }
        public bool IsItalic { get; set; }

    }
}
