using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RCM.BLL.Services;
using RCM.DAL.Models;
using RCM.Web.Models;

namespace RCM.Web.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly IRetailerService _retailerService;

        public HomeController(IRetailerService retailerService)
        {
            _retailerService = retailerService;
        }

        [HttpPost("create-retailer")]
        public async Task<IActionResult> CreateRetailer([FromBody] RetailerInformation retailerInformation)
        {

            var res = await _retailerService.CreateRetailerAsync(retailerInformation);
            return Ok(res);
        }

        [HttpGet("GetRetailerList")]
        public async Task<IActionResult> GetRetailerList()
        {
            var res = await _retailerService.GetRetailerList();
            return Ok(res);
        }

        [HttpPut("ModifyRetailerInfo/{id}")]
        public async Task<IActionResult> ModifyRetailerInfo([FromBody] RetailerInformation retailerInformation, int id)
        {
            var res = await _retailerService.ModifyRetailerInfo(retailerInformation, id);
            return Ok(res);
        }

        [HttpDelete("RemoveRetailer/{id}")]

        public async Task<IActionResult> RemoveRetailer(long id)
        {
            var res = await _retailerService.RemoveRetailer(id);
            return Ok(res);
        }
    }
}
