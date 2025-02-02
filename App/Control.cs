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
        MoveRobots();
        return GetRobotPositions();
    }

    private void MoveRobots()
    {
        foreach (KeyValuePair<string, Instruction> kvp in Instructions) {
            Robot robot = Robots[kvp.Key];
            foreach (char instruction in kvp.Value.Instructions) {
                switch (instruction) {
                    case 'L':
                        robot.TurnLeft();
                        break;
                    case 'R':
                        robot.TurnRight();
                        break;
                    case 'M':
                        robot.MoveForward();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private string GetRobotPositions()
    {
        List<string> output = [];
        foreach (KeyValuePair<string, Robot> kvp in Robots) {
            Robot robot = kvp.Value;
            var cardinal = Cardinal.Direction.Where(d => d.Value == robot.Rotation).Select(d => d.Key);
            output.Add(robot.X + " " + robot.Y + " " + String.Join(" ", cardinal));
        }
        return String.Join("\n", output);
    }
}
