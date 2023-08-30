namespace NoticiasApi.Models;

public class Noticia : Entidade
{
    #region | Propriedades |

    public string Titulo { get; private set; }
    public string Texto { get; private set; }
    public DateTime DataHora { get; private set; }

    #endregion

    #region | Construtores |

    public Noticia(int id, string titulo, string texto, DateTime dataHora)
    {
        Id = id;
        Titulo = titulo;
        Texto = texto;
        DataHora = dataHora;
    }

    #endregion
}