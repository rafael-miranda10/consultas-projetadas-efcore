using AutoMapper;
using BenchmarkDotNet.Attributes;
using Livraria.Context;
using Livraria.DTOs;
using Livraria.Entities;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Queries
{
    [MemoryDiagnoser]
   //[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MyQueries
    {
        private IMapper mapper;
        public MyQueries()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Autor, AutorDto>();
                cfg.CreateMap<Livro, LivroDto>();
                cfg.CreateMap<Autor, AutorAutoMapperDto>();
                cfg.CreateMap<Livro, LivroAutoMapperDto>();
            });

            mapper = config.CreateMapper();
        }

        public void ImprimirMensagemConsole(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"#### {mensagem} #####");
            Console.ResetColor();
        }

        public void PrimeiraConexao()
        {
            ImprimirMensagemConsole("Primeira Conexão");
            using var db = new LivrariaContext();
            var autores = db.Autores.Include(x => x.Livros).ToList();
        }

        //[Benchmark(Baseline = true)]
        [Benchmark]
        public void ConsultarAutoresEFCore()
        {
            ImprimirMensagemConsole("CONSULTA EF CORE PADRAO - NAO PROJETADA");
            using var db = new LivrariaContext();
            var autores = db.Autores.Include(x => x.Livros).ToList();
        }

        [Benchmark]
        public void ConsultarAutoresLINQ()
        {
            ImprimirMensagemConsole("CONSULTA LINQ - NAO PROJETADA");
            using var db = new LivrariaContext();
            var autores = from aut in db.Autores.Include("Livros")
                          join liv in db.Livros on aut.Id equals liv.Id
                          select aut;

            autores.ToList();
        }

        [Benchmark]
        public void ConsultaeAutoresEFCoreProjetada()
        {
            ImprimirMensagemConsole("CONSULTA EF CORE PADRAO - PROJETADA");
            using var db = new LivrariaContext();
            var autores = db.Autores
                .Include(x => x.Livros)
                .Select(x => new AutorDto()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Livros = x.Livros.Select(y => new LivroDto()
                    {
                        Id = y.Id,
                        Titulo = y.Titulo
                    })
                    .ToList()
                })
                .ToList();
        }

        public void ConsultaeAutoresEFCoreProjetada2()
        {
            ImprimirMensagemConsole("CONSULTA EF CORE PADRAO - PROJETADA 2");

            /*
             FALAR NO TEXTO QUE SEM O INCLUDE E SÓ COM O SELECT DESSA FORMA TAMBÉM FAZ O JOIN E QUE 
            DEVE TOMAR CUIDADO PARA QUE JUNTOS NÃO DUPLICAR OS JOINS (FALAR QUE NESSE CASO NÃO DUPLICOU MAS É BOM FICAR DE OLHO), SEMPRE OBSERVAR A QUERY GERADA
             */


            using var db = new LivrariaContext();
            var autores = db.Autores
                .Select(x => new AutorDto()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Livros = x.Livros.Select(y => new LivroDto()
                    {
                        Id = y.Id,
                        Titulo = y.Titulo
                    })
                    .ToList()
                })
                .ToList();
        }

        [Benchmark]
        public void ConsultaeAutoresEFCoreProjetadaAsNoTracking()
        {
            ImprimirMensagemConsole("CONSULTA EF CORE PADRAO - PROJETADA NAO TRACKEADA");
            using var db = new LivrariaContext();
            var autores = db.Autores
                .AsNoTracking()
                .Include(x => x.Livros)
                .Select(x => new AutorDto()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Livros = x.Livros.Select(y => new LivroDto()
                    {
                        Id = y.Id,
                        Titulo = y.Titulo
                    })
                    .ToList()
                })
                .ToList();
        }

        [Benchmark]
        public void ConsultaeAutoresEFCoreProjetadaComResolucaoIdentidade()
        {
            ImprimirMensagemConsole("CONSULTA EF CORE PADRAO - PROJETADA NAO TRACKEADA COM RESOLUCAO DE IDENTIDADE");
            using var db = new LivrariaContext();
            var autores = db.Autores
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Livros)
                .Select(x => new AutorDto()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Livros = x.Livros.Select(y => new LivroDto()
                    {
                        Id = y.Id,
                        Titulo = y.Titulo
                    })
                    .ToList()
                })
                .ToList();
        }

        [Benchmark]
        public void ConsultarAutoresLINQProjetada()
        {
            ImprimirMensagemConsole("CONSULTA LINQ - PROJETADA");
            using var db = new LivrariaContext();
            var autores = from aut in db.Autores
                          select new AutorDto()
                          {
                              Id = aut.Id,
                              Nome = aut.Nome,
                              Livros = from listAutLiv in aut.Livros
                                       select new LivroDto()
                                       {
                                           Id = listAutLiv.Id,
                                           Titulo = listAutLiv.Titulo
                                       }
                          };

            autores.ToList();
        }

        [Benchmark]
        public void ConsultarAutoresAutoMapperProjetada()
        {
            ImprimirMensagemConsole("CONSULTA EF CORE - PROJETADA COM AUTOMAPPER");
            using var db = new LivrariaContext();
            var autores = mapper.ProjectTo<AutorDto>(db.Autores.Include(x => x.Livros)).ToList();
        }

        [Benchmark]
        public void ConsultarAutoresAutoMapperProjetadaEspecifica()
        {
            ImprimirMensagemConsole("CONSULTA EF CORE - PROJETADA COM AUTOMAPPER DTO ESPECÍFICO");
            using var db = new LivrariaContext();
            var autores = mapper.ProjectTo<AutorAutoMapperDto>(db.Autores.Include(x => x.Livros)).ToList();
        }



        public void ConsultaDeAutoresEFCore()
        {
            var nomeFiltro = "Rafael";
            using var db = new LivrariaContext();
            var autores = db.Autores
                .AsNoTrackingWithIdentityResolution()
                .Where(x => x.Nome == nomeFiltro.ToUpper()).ToList();
        }
    }
}
