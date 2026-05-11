using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinisterioAtos.Application.Commanders.Evento
{
    public record InputEventoCommander
    (
        String Titulo,
        String? Descricao,
        DateTime DataHora,
        int? idCongregacao
    );
    public record OutputEventoCommander
    (
        String Titulo,
        String? Descricao,
        DateTime DataHora,
        String? Congregacao
    );
    public record FilterEventoCommander
    (
        String? Titulo,
        DateTime? StartWith,
        DateTime? EndWith,
        int? idCongregacao
    );
}