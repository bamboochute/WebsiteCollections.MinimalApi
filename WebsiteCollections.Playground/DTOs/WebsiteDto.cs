using System.ComponentModel.DataAnnotations;

namespace WebsiteCollections.Playground.DTOs
{
    public class WebsiteDto
    {
        [Required]
        public string Url { get; set; }
        public string Collection { get; set; } = "default";
        public string Title { get; set; }
    }
}
