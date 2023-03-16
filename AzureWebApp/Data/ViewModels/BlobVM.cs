using System.ComponentModel.DataAnnotations;

namespace AzureWebApp.Data.ViewModels
{
    public class BlobVM
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "File is required")]
        public IFormFile File { get; set; }
    }
}
