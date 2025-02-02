public class Surface
{
    public int X { get; set; }
    public int Y { get; set; }

    public Surface(string[] coordinates)
    {
        if (coordinates.Length < 2) {
            throw new Exception("To define a surface, provide two vales");
        }

        X = int.Parse(coordinates[0]);
        Y = int.Parse(coordinates[1]);
    }
}
