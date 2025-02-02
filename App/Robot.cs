public class Robot
{
    private int X { get; set; }
    private int Y { get; set; }
    private int Rotation { get; set; }
    private Surface Floor { get; set; }

    public Robot(string[] position, Surface floor)
    {
        if (position.Length < 3) {
            throw new Exception("To initialise a robot, provide three values");
        }

        X = int.Parse(position[0]);
        Y = int.Parse(position[1]);

        if (!Cardinal.Direction.ContainsKey(position[2][0])) {
            throw new Exception(position[2] + " is not a valid cardinal direction");
        }

        Rotation = Cardinal.Direction[position[2][0]];
        
        Floor = floor;
    }

    public void TurnLeft()
    {
        Rotation--;
        if (Rotation < 1) {
            Rotation += 4;
        }

    }

    public void TurnRight()
    {
        Rotation++;
        if (Rotation > 4) {
            Rotation -= 4;
        }
    }

    public void MoveForward()
    {
        if (Rotation == Cardinal.Direction['N'] && Y < Floor.Y) {
            Y++;
        }
        if (Rotation == Cardinal.Direction['E'] && X < Floor.X) {
            X++;
        }
        if (Rotation == Cardinal.Direction['S'] && Y > 0) {
            Y--;
        }
        if (Rotation == Cardinal.Direction['W'] && X > 0) {
            X--;
        }
    }

    public string ReportPosition()
    {
        var cardinal = Cardinal.Direction.Where(d => d.Value == Rotation).Select(d => d.Key);
        return X + " " + Y + " " + String.Join(" ", cardinal);
    }
}
