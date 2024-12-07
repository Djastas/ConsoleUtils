namespace ConsoleUtils;

public class EConsole
{
    public static EConsole Instance { get; private set; } = new EConsole();
    
    public StreamWriter? Output;

    public int BufferScaleX = 255;
    public int BufferScaleY = 255;
}