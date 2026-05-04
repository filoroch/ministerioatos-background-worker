///Table: congregacoes
public class Congregacao
{
    private int Id {get; set; }
    private String Rua {get; set; }
    private String Area {get; set;}
    private int Numero {get; set;}
    private string Cidade {get; set;}
    private string UF {get; set;}
    private string CEP {get; set;}
    private enum StatusCongregacao;
    private Pessoa PastorResponsavel {get; set;}
}

internal class Pessoa
{
    public int Id;
    public String Nome;
    public String Sobrenome;
    public SituacaoPessoa Situacao;
    
    Table: pessoas
Columns:
id int(11) PK 
nome varchar(45) 
sobrenome varchar(45) 
situacao set('Visitante','Congregado','Batizado') 
status set('Ativo','Desativado')
}