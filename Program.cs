using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

/// Adicionado os serviços da aplicação
builder.Services.AddOpenApi();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEventoLiveRepository, EventoLiveRepository>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoLiveService, EventoLiveService>();
builder.Services.AddHttpClient<IYoutube, YoutubeAPIService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

/// Adicionando o Quartz como serviço de Scheduling Job e configurando
// builder.Services.AddQuartz(quartz => 
// {

//     var FixLivesOnYoutube = new JobKey("FixLivesOnYoutubeJob");

//     quartz.AddJob<FixLivesOnYoutubeJob>(options => options.WithIdentity(FixLivesOnYoutube));
//     // quartz.AddTrigger(options => options
//     //     .ForJob(FixLivesOnYoutube)
//     //     .WithIdentity("FixLivesOnYoutubeJob")
//     //     .WithCronSchedule("0/35 * * * * ?")
//     // );

// //     // var ScheduleLiveJobKey = new JobKey("ScheduleLiveJob");
    
// //     // quartz.AddJob<>(options => options
// //     //     .WithIdentity(ScheduleLiveJobKey)
// //     // );

// //     // quartz.AddTrigger(options => options
// //     //     .ForJob(ScheduleLiveJobKey)
// //     //     .WithIdentity("ScheduleLiveOnYoutube - Trigger")
// //     //     .WithCronSchedule("0/15 * * * * ?")
// //     // );

// //     // var UpdateLivestreamJobKey = new JobKey("UpdateLiveJob");

// //     // quartz.AddJob<UpdateLivestream>(options => options
// //     //     .WithIdentity(UpdateLivestreamJobKey)
// //     // );

// //     // quartz.AddTrigger(options => options
// //     //     .ForJob(UpdateLivestreamJobKey)
// //     //     .WithIdentity("UpdateLivestreamOnYoutube - Trigger")
// //     //     .WithCronSchedule("0 6 * * 0") // 06h de todo domingo
// //     // );

// });

// // Adiciona o serviço que efetivamente executa o agendador em segundo plano
builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});

// Registra a fabrica de Sessões do NHIbernate como um serviço global (singleton)
builder.Services.AddSingleton<ISessionFactory>(sp => {
    return Fluently.Configure()
            .Database(MySQLConfiguration.Standard
                .ConnectionString("Server=localhost;Database=ministerioatos;User ID=root;Password=;")
                .Driver<NHibernate.Driver.MySqlDataDriver>()
            )
            // .Database(PostgreSQLConfiguration.Standard
            //     .ConnectionString(""))
            // .Database(SQLiteConfiguration.Standard
            //     .UsingFile("MinisterioAtos")
            //     .Driver<NHibernate.Driver.SQLite20Driver>()
            //     .Dialect<NHibernate.Dialect.SQLiteDialect>()
            // )
            .Mappings(map => map.FluentMappings.AddFromAssemblyOf<Evento>()
                .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()) 
            )
            //.ExposeConfiguration(config => new SchemaUpdate(config).Execute(true, true))
            .BuildSessionFactory();
});

builder.Services
    .AddScoped(factory => factory.GetRequiredService<ISessionFactory>().OpenSession());

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
// app.UseHttpsRedirection();
app.Run();
