using System.ComponentModel.DataAnnotations;


namespace ServiceForMinibuses.Web.Models
{
    public class CreateStopViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int XCoord { get; set; }

        [Required]
        public int YCoord { get; set; }
        
    }
}