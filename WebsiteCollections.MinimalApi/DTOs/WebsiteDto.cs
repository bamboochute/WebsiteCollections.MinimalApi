using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebsiteCollections.MinimalApi.DTOs
{
    public class WebsiteDto
    {
        [Required]
        public string Url { get; set; }
        public string Collection { get; set; } = "default";
        public string Title { get; set; }
    }
}
