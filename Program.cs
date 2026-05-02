using Microsoft.VisualBasic;
using Quartz;
using Quartz.Util;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

/// Adicionado os serviços da aplicação
builder.Services.AddOpenApi();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<LiveScheduleService>();

/// Adicionando o Quartz como serviço de Scheduling Job e configurando
builder.Services.AddQuartz(quartz => 
{
    var ScheduleLiveJobKey = new JobKey("ScheduleLiveJob");
    
    
    quartz.AddJob<ScheduleLive>(options => options
        .WithIdentity(ScheduleLiveJobKey)
    );

    quartz.AddTrigger(options => options
        .ForJob(ScheduleLiveJobKey)
        .WithIdentity("ScheduleLiveOnYoutube - Trigger")
        // Defir o tempo do trigger
        .WithCronSchedule("0/15 * * * * ?")
    );

    var UpdateLivestreamJobKey = new JobKey("UpdateLiveJob");

    quartz.AddJob<UpdateLivestream>(options => options
        .WithIdentity(UpdateLivestreamJobKey)
    );

    quartz.AddTrigger(options => options
        .ForJob(ScheduleLiveJobKey)
        .WithIdentity("UpdateLivestreamOnYoutube - Trigger")
        .WithCronSchedule("0 6 * * 0") // 06h de todo domingo
    );

});

// Adiciona o serviço que efetivamente executa o agendador em segundo plano
builder.Services.AddQuartzHostedService(options =>
{
    // Aguarda a finalização dos jobs ao fechar a aplicação
    options.WaitForJobsToComplete = true;
});

var supabaseUrl = Environment.GetEnvironmentVariable("SUPAURL");
var supabaseKey = Environment.GetEnvironmentVariable("SUPAKEY");

builder.Services.AddSingleton(provider => {
    
    var options = new SupabaseOptions
    {
        AutoConnectRealtime = true
    };    
    return new Supabase.Client(supabaseUrl, supabaseKey, options);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 3. Inicializando o cliente assincronamente ANTES do app rodar
var supabaseClient = app.Services.GetRequiredService<Supabase.Client>();
await supabaseClient.InitializeAsync();

app.Run();
