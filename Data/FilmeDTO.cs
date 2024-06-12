namespace Filmes2012API.Data;

public class FilmeDTO
{
     public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Genero {get; set;}
    public int Ano {get; set;}
    public int Duracao {get; set;} // em minutos
    public bool Bom {get; set;} // Secret

}