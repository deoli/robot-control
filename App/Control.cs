public class Control
{
    private Surface Floor { get; set; }
    private Dictionary<string, Robot> Robots { get; set; }
    private Dictionary<string, Instruction> Instructions { get; set; }

    public Control(string[] command)
    {
        Floor = new Surface(command[0].Split(' '));
        Robots = new Dictionary<string, Robot>();
        Instructions = new Dictionary<string, Instruction>();

        for (int i = 1; i < command.Length; i += 2) {
            Guid uuid = Guid.NewGuid();

            Robot robot = new Robot(command[i].Split(' '));
            Robots.Add(uuid.ToString(), robot);

            Instruction instruction = new Instruction(command[i+1].ToCharArray());
            Instructions.Add(uuid.ToString(), instruction);
        }
    }

    public string Execute()
    {
        return "Floor size is " + Floor.X + " by " + Floor.Y + " and there are " + Robots.Count + " robots and " + Instructions.Count + " instructions";
    }
}
