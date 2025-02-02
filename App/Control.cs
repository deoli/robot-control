public class Control
{
    private string Command { get; set; }
    private string Floor { get; set; }
    private string[] Robots { get; set; }

    public Control(string[] command)
    {
        Command = String.Join(',', command);
    }

    public string Execute()
    {
        return Command;
    }
}
