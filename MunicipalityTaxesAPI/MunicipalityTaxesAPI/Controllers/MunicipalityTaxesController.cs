using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Models.MunicipalityTaxes;
using Services.Services.Contracts;
using System.Threading.Tasks;

namespace MunicipalityTaxesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipalityTaxesController : ControllerBase
    {
        private readonly IMunicipalityTaxesService _municipalityTaxesService;
        public MunicipalityTaxesController(IMunicipalityTaxesService municipalityTaxesService)
        {
            _municipalityTaxesService = municipalityTaxesService;
        }

        [HttpPost]
        public async Task<ActionResult<MunicipalityTax>> Add([FromBody] AddMunicipalityTaxRequest model)
        {
            var result = await _municipalityTaxesService.AddTax(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<MunicipalityTax>> Update([FromBody] UpdateMunicipalityTaxRequest model)
        {
            var result = await _municipalityTaxesService.UpdateTax(model);
            return Ok(result);
        }
    }
}
