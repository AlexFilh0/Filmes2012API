namespace Filmes2012API.Models;

public class Filme
{
    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Genero {get; set;}
    public int AnoLancamento {get; set;}
    public int Duracao {get; set;} // em minutos
    public bool Bom {get; set;} // Secret
}