namespace Livraria.DTOs
{
    public class LivroAutoMapperDto
    {
        public LivroAutoMapperDto()
        {
            Autor = new AutorAutoMapperDto();
        }

        public int Id { get; set; }
        public string Titulo { get; set; } = default!;
        public int AutorId { get; set; }
        public AutorAutoMapperDto Autor { get; set; }
    }
}
