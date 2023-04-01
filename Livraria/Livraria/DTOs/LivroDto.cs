using Livraria.Entities;

namespace Livraria.DTOs
{
    public class LivroDto
    {
        public LivroDto()
        {
            Autor = new AutorDto();
        }
        public int Id { get; set; }
        public string Titulo { get; set; } = default!;
        public int AnoPublicacao { get; set; }
        public int Edicao { get; set; }
        public string Editora { get; set; } = default!;
        public int AutorId { get; set; }
        public AutorDto Autor { get; set; }
    }
}
