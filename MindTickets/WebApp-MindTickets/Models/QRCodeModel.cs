using System.ComponentModel.DataAnnotations;

namespace WebApp_MindTickets.Models
{
    public class QRCodeModel
    {
        [Required]
        public string qrcode { get; set; }
    } 
}
