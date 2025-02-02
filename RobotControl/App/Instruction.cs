public class Instruction
{
    private char[] Instructions { get; set; }

    public Instruction(char[] instructions)
    {
        Instructions = instructions;
    }

    public char[] GetInstructions()
    {
        return Instructions;
    }
}
