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
        public async Task<ActionResult> Post([FromBody] AddClienteDto clienteDto)
        {
            var result = await _clienteService.Add(clienteDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateClienteDto clienteDto)
        {
            await _clienteService.Update(id, clienteDto);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PaginationRequest paginationRequest)
        {
            var responseService = await _clienteService.GetFilter(paginationRequest);
            return Ok(responseService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var cliente = await _clienteService.GetById(id);
            return Ok(cliente);
        }
    }
}
