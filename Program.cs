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
    try {
        Control command = new Control(input.Parse());
        return command.Execute();
    } catch(Exception e) {
        return "[ERROR] " + e.Message;
    }
});

app.Run();
