using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarMP.DTOs;
using SolarMP.DTOs.Account;
using SolarMP.Interfaces;
using SolarMP.Models;

namespace SolarMP.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccount _service;
        public AccountController(IAccount Service)
        {
            this._service = Service;
        }

        /// <summary>
        /// hiện h chỉ role 1 dc vào
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
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

        /// <summary>
        /// role 1: admin
        /// role 2: owner
        /// role 3: staff
        /// role 4: customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>
        /// </returns>
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> register(AccountRegisterDTO dto)
        {

            ResponseAPI<List<Account>> responseAPI = new ResponseAPI<List<Account>>();
            try
            {
                responseAPI.Data = await this._service.register(dto);
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
