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

        [HttpPost]
        public async Task<ActionResult> CreateCliente([FromBody] ClienteDto clienteDto)
        {
            var result = await _clienteService.Add(clienteDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(Guid id)
        {
            var cliente = await _clienteService.GetById(id);
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<ActionResult> GetFilter([FromQuery] PaginationRequest paginationRequest)
        {
            var responseService = await _clienteService.GetFilter(paginationRequest);
            return Ok(responseService);
        }
    }
}
