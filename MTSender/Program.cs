using MassTransit;
using MTContracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<MsgMT>(c => c.SetEntityName("msgmt-queue"));
    });
});


var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();