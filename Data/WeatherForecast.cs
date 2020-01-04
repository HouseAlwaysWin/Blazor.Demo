using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Demo.Data {
    public class WeatherForecast {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required (ErrorMessage = "Celsius is required")]
        [Range (typeof (int), "-51", "106")]
        public int TemperatureC { get; set; }

        [Required (ErrorMessage = "Fahrenheit is required")]
        [Range (typeof (int), "-60", "224")]
        public int TemperatureF { get; set; }

        [Required]
        [StringLength (50, MinimumLength = 2)]
        public string Summary { get; set; }

        [StringLength (50)]
        public string Username { get; set; }
    }

    public partial class WeatherForecastOptions {
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
    }
}