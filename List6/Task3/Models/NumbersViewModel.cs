using System.ComponentModel.DataAnnotations;

namespace Task3.Models
{
    public class NumbersViewModel
    {
        public struct NumbersAndCounts
        {
            public int number;
            public int count;
        }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int Min { get; set; }

        [Required]
        public int Max{ get; set; }

        public List<int>? GeneratedNumbers { get; set; }
        public List<int>? NonRepeatedNumbers { get; set; }
        public SortedDictionary<int, int>? RepetationNumbers { get; set; }
    }
}
