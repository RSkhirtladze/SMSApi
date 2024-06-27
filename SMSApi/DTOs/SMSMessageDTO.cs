using System.ComponentModel.DataAnnotations;

namespace SMSApi.DTOs
{
    public class SMSMessageDTO
    {
        public string Phone  { get; set; }
        public string Text { get; set; }
    }
}
