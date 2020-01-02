using Microsoft.EntityFrameworkCore;

namespace Blazor.Demo.Data {
    public class EndToEndContext : DbContext {
        public EndToEndContext (DbContextOptions<EndToEndContext> options) : base (options) {

        }
        public DbSet<WeatherForecast> WeatherForecast { get; set; }
    }
}