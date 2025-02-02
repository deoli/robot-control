public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Direction { get; set; }

    public Robot(string[] position)
    {
        if (position.Length < 3) {
            throw new Exception("To initialise a robot, provide three values");
        }

        X = int.Parse(position[0]);
        Y = int.Parse(position[1]);
        Direction = position[2];
    }

}
