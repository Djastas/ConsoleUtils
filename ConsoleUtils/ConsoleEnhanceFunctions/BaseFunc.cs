using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleUtils.ConsoleEnhanceFunctions;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public static class BaseFunc
{
    
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);
    
    [DllImport( "kernel32.dll", SetLastError = true )]
    private static extern bool SetConsoleMode( IntPtr hConsoleHandle, int mode );
    [DllImport( "kernel32.dll", SetLastError = true )]
    private static extern bool GetConsoleMode( IntPtr handle, out int mode );
    
    public static void Init(this EConsole console)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        console.Output = new StreamWriter(Console.OpenStandardOutput(), Encoding.UTF8);
        
        Console.SetOut(console.Output);
        
        Console.BufferHeight = console.BufferScaleY;
        Console.BufferWidth = console.BufferScaleX;
        
        var handle = GetStdHandle(-11);
        GetConsoleMode(handle, out var mode);
        SetConsoleMode(handle, mode | 0x4);

        console.SetStartupColor();
    }

    public static void Clear(this EConsole console)
        => console.Clear(console.BufferScaleX, console.BufferScaleY);
    public static void Clear(this EConsole console,int x, int y)
    {
        if (console.Output == null) {return;}
        
        Console.SetCursorPosition(0,0);
        for (int l = 0; l < y; l++)
        {
            for (int i = 0; i <  x; i++)
            {
                console.Output.Write(' ');
            }
            console.Output.Write('\n');
        }
        Console.SetCursorPosition(0,0);
    }

    public static void Write(this EConsole console, string text)
    {
        if (console.Output == null) {return;}
        console.Output.Write(text);
        console.Output.Flush();
    }
    
    
}