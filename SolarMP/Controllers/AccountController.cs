using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarMP.DTOs;
using SolarMP.Interfaces;
using SolarMP.Models;

namespace SolarMP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccount _service;
        public AccountController(IAccount Service)
        {
            this._service = Service;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ResponseAPI<List<Account>> responseAPI = new ResponseAPI<List<Account>>();
            try
            {
                responseAPI.Data = await this._service.getAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
