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

            Robot robot = new Robot(command[i].Split(' '), Floor);
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
            foreach (char instruction in kvp.Value.GetInstructions()) {
                switch (instruction) {
                    case 'L':
                        robot.TurnLeft();
                        break;
                    case 'R':
                        robot.TurnRight();
                        break;
                    case 'M':
                        robot.MoveForward();
                        CheckCollision();
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
        foreach (Robot robot in Robots.Values) {
            output.Add(robot.ReportPosition());
        }
        return String.Join("\n", output);
    }

    private void CheckCollision()
    {
        foreach (KeyValuePair<string, Robot> kvpA in Robots) {
            string uuidA = kvpA.Key;
            Robot robotA = kvpA.Value;
            foreach (KeyValuePair<string, Robot> kvpB in Robots) {
                string uuidB = kvpB.Key;
                Robot robotB = kvpB.Value;
                if (uuidA == uuidB) {
                    continue;
                }
                if (robotA.GetPosition() == robotB.GetPosition()) {
                    throw new Exception("Collision detected /!\\");
                }
            }
        }
    }
}
