using System.ComponentModel.DataAnnotations;

namespace TF_Arch_GestToDo.Models.Forms
{
#nullable disable
    public class CreateToDo
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z][\w\s]*[\w]$")]
        public string Title { get; set; }
    }
#nullable enable
}
