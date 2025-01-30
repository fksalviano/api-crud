using Application.Handlers.WeatherForecast.SaveWeatherHandler;
using AutoMapper;
using Domain.Models;
using Domain.Responses.WeatherForecast;

namespace Application.Mappers;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<SaveWeatherCommand, WeatherForecast>();                
        CreateMap<WeatherForecast, WeatherForecastResponse>();
    }
}
