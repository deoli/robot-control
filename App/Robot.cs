public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Rotation { get; set; }

    public Robot(string[] position)
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
        if (Rotation == Cardinal.Direction['N']) {
            Y++;
        }
        if (Rotation == Cardinal.Direction['E']) {
            X++;
        }
        if (Rotation == Cardinal.Direction['S']) {
            Y--;
        }
        if (Rotation == Cardinal.Direction['W']) {
            X--;
        }
    }
}
