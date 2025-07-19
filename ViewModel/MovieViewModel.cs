using System.ComponentModel.DataAnnotations;

namespace MovieManage.ViewModel
{
    public class MovieViewModel
    {
        public int? MovieId { get; set; } 

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Detail is required.")]
        [StringLength(1000, ErrorMessage = "Detail can't be longer than 1000 characters.")]
        public string Detail { get; set; } = null!;

        [Required(ErrorMessage = "Release Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateOnly ReleaseDate { get; set; }
    }
}
