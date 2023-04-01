namespace Livraria.Entities
{
    public class Autor
    {
        public Autor()
        {
            Livros = new List<Livro>();
        }

        public int Id { get; set; }
        private string _nome = string.Empty;
        public string Nome 
        {
            get 
            { 
                return _nome;
            }
            set 
            {
                _nome = value.ToUpper();
            } 
        }
        public string CPF { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IEnumerable<Livro> Livros { get; set; }
    }
}
