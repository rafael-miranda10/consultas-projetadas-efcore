namespace Livraria.DTOs
{
    public class AutorAutoMapperDto
    {
        public AutorAutoMapperDto()
        {
            Livros = new List<LivroAutoMapperDto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public IEnumerable<LivroAutoMapperDto> Livros { get; set; }
    }
}
