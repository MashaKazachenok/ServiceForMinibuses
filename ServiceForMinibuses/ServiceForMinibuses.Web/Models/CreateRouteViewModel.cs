
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace ServiceForMinibuses.Web.Models
{
    public class CreateRouteViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Stop> Stops { get; set; }
    }
}