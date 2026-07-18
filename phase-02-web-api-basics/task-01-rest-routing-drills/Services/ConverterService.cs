using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIproject.Services
{
    public class ConverterService
    {

        public decimal ConvertCelsiusToFahrenheit(decimal celsius)
        {
            celsius = (celsius * 9 / 5) + 32;
            return celsius;
        }
    }
}
