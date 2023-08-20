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
        public async Task<ActionResult> Post([FromBody] AddUpdateClienteDto clienteDto)
        {
            var result = await _clienteService.Add(clienteDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] AddUpdateClienteDto clienteDto)
        {
            await _clienteService.Update(id, clienteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _clienteService.Delete(id);

            if (result)
                return NoContent(); // Retorna 204 No Content se a exclusão for bem-sucedida.
            else
                return NotFound(); // Retorna 404 Not Found se o cliente não for encontrado ou a exclusão falhar por algum motivo.
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
