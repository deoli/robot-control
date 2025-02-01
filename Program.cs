var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/robot/control", (Input input) =>
{
    if (string.IsNullOrWhiteSpace(input.command)) {
        return "Please provide a command";
    }

    Command command = new Command(input.command);
    return command.Execute();
});

app.Run();

public class Input
{
    public string? command { get; set; }
}

public class Command
{
    private string Input { get; set; }

    public Command(string input)
    {
        Input = input;
    }

    public string Execute()
    {
        return Input;
    }
}
