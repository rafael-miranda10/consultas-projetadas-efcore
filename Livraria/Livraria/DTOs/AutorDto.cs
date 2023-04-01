namespace Livraria.DTOs
{
    public class AutorDto
    {
        public AutorDto()
        {
            Livros = new List<LivroDto>();
        }
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string CPF { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IEnumerable<LivroDto> Livros { get; set; }
    }
}
