using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Demo.Data {
    public class WeatherForecastService {
        private readonly EndToEndContext _context;
        public WeatherForecastService (EndToEndContext context) {
            _context = context;
        }

        public Task<List<WeatherForecast>> GetForecastAsync (string currentUser) {
            List<WeatherForecast> weatherForcastList = new List<WeatherForecast> ();
            weatherForcastList = (from weatherForecast in _context.WeatherForecast where weatherForecast.Username == currentUser select weatherForecast).ToList ();
            return Task.FromResult (weatherForcastList);

        }

        public Task<WeatherForecast> CreateForecastAsync (WeatherForecast objWeatherForecast) {
            _context.WeatherForecast.Add (objWeatherForecast);
            _context.SaveChanges ();
            return Task.FromResult (objWeatherForecast);
        }

        public Task<bool> UpdateForecastAsync (WeatherForecast objWeatherForecast) {
            var ExistingWeatherForecast = _context.WeatherForecast
                .Where (x => x.Id == objWeatherForecast.Id).FirstOrDefault ();
            if (ExistingWeatherForecast != null) {
                ExistingWeatherForecast.Date = objWeatherForecast.Date;
                ExistingWeatherForecast.Summary = objWeatherForecast.Summary;
                ExistingWeatherForecast.TemperatureC = objWeatherForecast.TemperatureC;
                ExistingWeatherForecast.TemperatureF = objWeatherForecast.TemperatureF;
                _context.SaveChanges ();
            } else {
                return Task.FromResult (false);
            }

            return Task.FromResult (true);
        }

        public Task<bool> DeleteForecastAsync (WeatherForecast objWeatherForecast) {
            var ExistingWeatherForecast = _context.WeatherForecast.Where (x => x.Id == objWeatherForecast.Id).FirstOrDefault ();
            if (ExistingWeatherForecast != null) {
                _context.WeatherForecast.Remove (ExistingWeatherForecast);
                _context.SaveChanges ();
            } else {
                return Task.FromResult (false);
            }
            return Task.FromResult (true);
        }

    }
}