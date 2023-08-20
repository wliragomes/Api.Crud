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
            var cliente = await _clienteService.Add(clienteDto);
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateClienteDto clienteDto)
        {
            await _clienteService.Update(clienteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _clienteService.Delete(id);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        [HttpGet("get-pagination")]
        public async Task<ActionResult> GetPagination([FromQuery] PaginationRequest paginationRequest)
        {
            var responseService = await _clienteService.GetFilter(paginationRequest);
            return Ok(responseService);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var responseService = await _clienteService.Get();
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
