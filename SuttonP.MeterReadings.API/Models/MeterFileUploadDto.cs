using System.ComponentModel.DataAnnotations;

namespace SuttonP.MeterReadings.API
{
    public class MeterFileUploadDto
    {
        [Required]
        public string FileName { get; set; }
    }
}
