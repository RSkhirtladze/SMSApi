using System.ComponentModel.DataAnnotations;

namespace SMSApi.API.DTOs
{
    public class SMSMessageDTO
    {
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
