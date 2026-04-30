using System;
using Quartz;

namespace MinisterioAtos_JobScheduler;

/// <summary>
/// Classe abstrata que representa um Job 
/// e suas propriedades e seu metodo base de execução
/// </summary>
public abstract class YoutubeJob : IJob
{
    /// <summary>
    /// Representa o objeto estatico que loga 
    /// e é chamado a cada chamada de `Execute()`
    /// </summary>
    protected ILogger<YoutubeJob> Logger {get; set;}

    /// <summary>
    /// Metodo que executa o Job em si
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public abstract Task Execute(IJobExecutionContext context);
}
