public class Control
{
    private Surface Floor { get; set; }
    private List<Robot> Robots { get; set; }

    public Control(string[] command)
    {
        Floor = new Surface(command[0].Split(' '));
        Robots = [];

        for (int i = 1; i < command.Length; i += 2) {
            Robot robot = new Robot(command[i].Split(' '));
            // robot.addCommand(command[i+1]);
            Robots.Add(robot);
        }
    }

    public string Execute()
    {
        return "Floor size is " + Floor.X + " by " + Floor.Y + " and there are " + Robots.Count + " robots";
    }
}
