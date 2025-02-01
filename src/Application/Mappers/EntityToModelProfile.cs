using Application.Handlers.WeatherForecast.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Mappers;

public class EntityToModelProfile : Profile
{
    public EntityToModelProfile()
    {
        CreateMap<SaveWeatherRequest, WeatherForecastEntity>();                
        CreateMap<WeatherForecastEntity, WeatherForecastModel>();
    }
}
