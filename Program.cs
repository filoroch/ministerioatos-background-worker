using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddQuartz(quartz => 
{
    var ScheduleLiveJobKey = new JobKey("ScheduleLiveJob");
 
    //quartz.UseMicrosoftDependencyInjectionJobFactory();
    
    quartz.AddJob<ScheduleLive>(options => options
        .WithIdentity(ScheduleLiveJobKey)
    );

    quartz.AddTrigger(options => options
        .ForJob(ScheduleLiveJobKey)
        .WithIdentity("ScheduleLiveOnYoutube - Trigger")
        // Defir o tempo do trigger
        .WithCronSchedule("0/60 * * * * ?")
    );
});

// Adiciona o serviço que efetivamente executa o agendador em segundo plano
builder.Services.AddQuartzHostedService(options =>
{
    // Aguarda a finalização dos jobs ao fechar a aplicação
    options.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
