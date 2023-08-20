using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult> GetFilter([FromQuery] PaginationRequest paginationRequest)
        {
            var responseService = await _clienteService.GetFilter(paginationRequest);
            return Ok(responseService);
        }

        [HttpGet("teste")]
        public string TratarDuplicacaoDFe(int idEmpresa)
        {
            return "teste";
        }
    }

 
}
