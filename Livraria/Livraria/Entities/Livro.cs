namespace Livraria.Entities
{
    public class Livro
    {
        public Livro()
        {

        }

        public int Id { get; set; } 
        public string Titulo { get; set; } = default!;
        public int AnoPublicacao { get; set; }
        public int Edicao { get; set; }
        public string Editora { get; set; } = default!;
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
