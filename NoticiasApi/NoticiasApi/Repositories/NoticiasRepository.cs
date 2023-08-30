using Dapper;
using Microsoft.Data.SqlClient;
using NoticiasApi.Models;
using NoticiasApi.Repositories.Interfaces;

namespace NoticiasApi.Repositories;

public class NoticiasRepository : INoticiasRepository
{
    private readonly SqlConnection connection;

    public NoticiasRepository()
    {
        var connectionString = "Server=ENDERECOSERVER;Database=NOMEBANCODADOS;Encrypt=False;Trusted_Connection=True";
        connection = new SqlConnection(connectionString);
    }

    public int Adicionar(Noticia noticia)
    {
        return connection.Execute(@"INSERT INTO TbNoticia (Titulo, Texto, DataHora) VALUES (@titulo, @texto, @dataHora)",
          new {
              titulo = noticia.Titulo,
              texto = noticia.Texto,
              dataHora = DateTime.Now,
          }
        );
    }

    public int Alterar(Noticia noticia)
    {
        return connection.Execute(@"
            UPDATE TbNoticia
                SET Titulo = @titulo, Texto = @texto, DataHora = @dataHora
            WHERE Id = @id",
          new
          {
              id = noticia.Id,
              titulo = noticia.Titulo,
              texto = noticia.Texto,
              dataHora = DateTime.Now,
          }
        );
    }

    public Noticia? BuscarPorId(int id)
    {
        return connection.Query<Noticia>("SELECT * FROM TbNoticia WHERE Id = @id", new { id }).FirstOrDefault();
    }

    public IEnumerable<Noticia> BuscarTodas()
    {
        return connection.Query<Noticia>("SELECT * FROM TbNoticia");
    }

    public int Excluir(int id)
    {
        return connection.Execute(@"DELETE FROM TbNoticia WHERE Id = @id", new { id });
    }
}
