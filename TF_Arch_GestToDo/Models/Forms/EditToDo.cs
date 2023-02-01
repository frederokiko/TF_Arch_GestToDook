using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TF_Arch_GestToDo.Models.Forms
{
#nullable disable
    public class EditToDo
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z][\w\s]*[\w]$")]
        public string Title { get; set; }

        [Required]
        public bool Done { get; set; }
    }
#nullable enable
}
