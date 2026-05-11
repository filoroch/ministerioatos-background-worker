///Table: congregacoes
public class Congregacao
{
    public int Id {get; set; }
    public String Titulo {get; set;}
    public String Rua {get; set; }
    public String Area {get; set;}
    public int Numero {get; set;}
    public string Cidade {get; set;}
    public string UF {get; set;}
    public string CEP {get; set;}
    public EStatusCongregacao Status{get; set;}
    public Pessoa PastorResponsavel {get; set;}

    public bool Equals(Congregacao congregacao)
    {
        return Id == congregacao.Id ? true : false;
    }
    public bool Equals(int congregacao_id)
    {
        return Id == congregacao_id? true : false;
    }

    public override string ToString()
    {
        return $"{Rua} {Numero}, {Area} - {Cidade}/{UF}";
    }
}

