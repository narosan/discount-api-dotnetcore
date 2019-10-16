using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ingressocom_promocodeAPI.Services.Interface;
using ingressocom_promocodeAPI.Domain;
using Microsoft.Data.Sqlite;
using System;

namespace ingressocom_promocodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private ICheckoutService _checkoutService;

        public PromotionController(ICheckoutService checkoutService) {
            _checkoutService = checkoutService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Checkout checkout)
        {
            try {
                var descountValue = await _checkoutService.StartProcess(checkout);
                return Ok(descountValue < 0 ? 0 : descountValue);
            } 
            catch(ArgumentException e) { return this.StatusCode(StatusCodes.Status400BadRequest, e.Message); } 
            catch(SqliteException e) { return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message); } 
            catch(System.Exception e) { return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message); }
        }
    }
}
