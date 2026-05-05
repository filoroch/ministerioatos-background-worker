// using Quartz;
// using MinisterioAtos_JobScheduler;
// using Microsoft.IdentityModel.Tokens;

// /// <summary>
// /// Representa uma instancia responsavel por agendar lives no youtube usando o metodo Execute
// /// </summary>
// public class ScheduleLive : YoutubeJob
// {

//     private readonly EventoService _eventoService;
//     //private readonly LiveScheduleService _liveScheduleService;

//     public ScheduleLive
//     (
//         ILogger<ScheduleLive> logger, 
//         EventoService eventoService,
//         LiveScheduleService liveScheduleService
//     )
//     {
//         Logger = logger;
//         _eventoService = eventoService;
//         //_liveScheduleService = liveScheduleService;
//     }

//     /// <summary>
//     /// - Puxa os eventos do banco <br/>
//     /// - Puxa os agendamentos do banco <br/>
//     /// - Verifica os eventos sem agendamento <br/> 
//     /// - Agenda cada evento no padrão (DIA/MES | TITULO DO EVENTO | PRELETOR) <br/>
//     /// - Confirma <br/>
//     /// - Chama o serviço de agendamento <br/>
//     /// </summary>
//     /// <param name="context"></param>
//     /// <returns></returns>
//     public override async Task Execute(IJobExecutionContext context)
//     {
//         Logger.LogInformation($"Iniciando o agendamento de livestream do YT em {DateTime.Now}");

//         try
//         {
//             // Puxa os eventos do banco
//             var events = await _eventoService.GetEventsAsync();
//             Logger.LogInformation($"Recebendo eventos do serviço em {DateTime.Now}");
        
//             if (events == null || events.Count <= 0)
//             {
//                 Logger.LogWarning("A lista de eventos esta vazia ou nula. Verifique!");    
//                 return;
//             }

//             // puxa os agendamentos do banco
//             var liveShedules = await _liveScheduleService.GetSchedulesAsync();
//             Logger.LogInformation($"Recebendo agendamentos do serviço em {DateTime.Now}");

//             if (liveShedules == null || liveShedules.Count <= 0)
//             {
//                 Logger.LogWarning("A lista de agendamentos esta vazia ou nula. Verifique!");    
//                 return;
//             }

//             // Pega os eventos
//             var eventsWithoutSchedules = from e in events
//                              join l in liveShedules on e.Id equals l.EventId into groupJoin
//                              from subL in groupJoin.DefaultIfEmpty()
//                              where subL == null
//                              select e;
            
//             if (eventsWithoutSchedules.IsNullOrEmpty())
//             {
//                 Logger.LogWarning("Não existe eventos sem agendamento no banco");    
//                 return;
//             }

//             _eventService.GetEventsAsync();
        
//         } catch (Exception ex)
//         {
//             Logger.LogError($"Ocorreu um erro: {ex.Message}");
//         }
//         return;
//     }
// }