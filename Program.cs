var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.MapPost("/robot/control", (Input input) => {
    if (string.IsNullOrWhiteSpace(input.command)) {
        return "Please provide a command";
    }

    Control command = new Control(input.command);
    return command.Execute();
});

app.Run();
