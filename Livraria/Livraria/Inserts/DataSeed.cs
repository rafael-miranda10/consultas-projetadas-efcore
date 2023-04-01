using Bogus;
using Bogus.Extensions.Brazil;
using Livraria.Context;
using Livraria.Entities;

namespace Livraria.Inserts
{
    public class DataSeed
    {
        private Faker _faker;
        public DataSeed()
        {
           // _faker = FakerBuilder.Novo().Build();
        }

        public void Inserir_N_Autores(int quantidade)
        {
            for (int i =0; i < quantidade; i++)
            {
                _faker = FakerBuilder.Novo().Build(); //comentar aqui
                var autor = new Autor()
                {
                    Nome = _faker.Person.FullName,
                    Email = _faker.Person.Email,
                    CPF = _faker.Person.Cpf(),
                    Livros = ObterListaDeLivrosDoAutor()
                };

                using (var db = new LivrariaContext())
                {
                    db.Autores.Add(autor);
                    db.SaveChanges();
                }
                _faker = null;//comentar aqui
            }
        }

        private List<Livro> ObterListaDeLivrosDoAutor()
        {
            var livrosDoAutor = new List<Livro>();
            var qtdeLivros = _faker.Random.Int(min: 1, max: 5);
            for (int i = 0; i < qtdeLivros; i++)
            {
                livrosDoAutor.Add(ObterLivro());
            }
            return livrosDoAutor;
        }

        private Livro ObterLivro()
        {
            return new Livro() 
            { 
                AnoPublicacao = _faker.Random.Int(min:1960, 2023),
                Edicao = _faker.Random.Int(min: 1, 5),
                Editora = _faker.Company.CompanyName(),
                Titulo = _faker.Lorem.Paragraph().Substring(0, 50)
        };
        }
    }
}
