using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerApi.Core.Dtos;

namespace NLayerApi.Main.Controllers
{

    public class CustomBaseController : ControllerBase
    {
        [NonAction]//Ona gore bunu yazdiq ki, sweager bunu bildiyimiz Action kimi anlamsin
        public IActionResult CreateActionResault<T>(CustomResponseDto<T> responseDto)
        {
            if (responseDto.StatusCode == 204)//204 - no content
            {
                //https://learn.microsoft.com/tr-tr/dotnet/api/microsoft.aspnetcore.mvc.objectresult?view=aspnetcore-6.0
                /* Indi bu ObjectResult ASP.NET daxilinde value ve HTTP status codlari saxlayan bir sinifdir. Buradan ASP.NET daxilinde olan status kodlari ele aliriq hemicinin eger nocontent deyilse responsdean gelen deyeri donuruk. Status code 200 ise ele geri 200 donecek, yox 400 se ele 400 donecek. Day her defe retunrk ok() , return BadRequest() kimi donmeye ehtiyac yoxdur. Ne gondereceyikse ele onuda donecek
                 */
                return new ObjectResult(null)
                {
                    StatusCode = responseDto.StatusCode,
                };

            }
            else
            {
                return new ObjectResult(responseDto)
                {
                    StatusCode = responseDto.StatusCode
                };
            }
        }
    }
}
