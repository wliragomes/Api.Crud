using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateClienteDto
    {
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
    }
}
