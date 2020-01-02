using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Demo.Data {
    public class WeatherForecast {

        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF {get;set;}
        [StringLength (50)]
        public string Summary { get; set; }

        [StringLength (50)]
        public string Username { get; set; }
    }
}