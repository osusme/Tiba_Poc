using FlexiStorageManager.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FlexiStorageManager.WebUI.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    [Authorize(Policy = "AuthZPolicy")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
