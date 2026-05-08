using FluentNHibernate.Mapping;
using NHibernate.Type;

public class PessoaMap : ClassMap<Pessoa>
{
    public PessoaMap()
    {
        Id(p => p.Id)
            .GeneratedBy.Identity();
        
        Map(p => p.Nome)
            .Length(50)
            .Not.Nullable();

        Map(p => p.Sobrenome)
            .Length(50);

        Map(p => p.Situacao)
            .CustomType("situacao")
            .CustomType<EnumStringType<ESituacaoPessoa>>();

        Map(p => p.Status)
            .CustomType("status")
            .CustomType<EnumStringType<EStatusPessoa>>();

        Table("congregacoes");
    }
}