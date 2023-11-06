using Microsoft.AspNetCore.Mvc;

namespace Hotelum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
        {
            if (count < 0 || request.Max < request.Min)
            {
                return BadRequest();
            }

            var result = _service.Get(count, request.Min, request.Max);
            return Ok(result + "Hi");
        }
        //ma³azmiana
        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var result = _service.Get();
        //    return result;
        //}

        //[HttpGet("currentDay/{max}")]
        //public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        //{
        //    var result = _service.Get();
        //    return result;
        //}

        //[HttpPost]
        //public ActionResult<string> Hello([FromBody]string name)
        //{

        //    return StatusCode(401, $"Hello {name}");
        //    //return NotFound($"Hello {name}");
        //}
    }
}