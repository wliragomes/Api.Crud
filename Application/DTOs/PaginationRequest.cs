namespace Application.DTOs
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; } // Número da página solicitada.
        public int PageSize { get; set; }   // Tamanho da página (quantidade de itens por página).
    }
}
