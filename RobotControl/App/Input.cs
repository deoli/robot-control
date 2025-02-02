public class Input
{
    public string? command { get; set; }

    public string[] Parse()
    {
        if (string.IsNullOrWhiteSpace(this.command)) {
            throw new Exception("Please provide a command");
        }

        return this.command.Split("\\n");
    }
}
