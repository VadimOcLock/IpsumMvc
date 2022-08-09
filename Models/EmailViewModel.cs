using System.ComponentModel.DataAnnotations;

namespace Ipsum.Models
{
    public class EmailViewModel
    {
        [EmailAddress]
        [UIHint("EmailAddress")]
        public string? Email { get; set; }
    }
}
