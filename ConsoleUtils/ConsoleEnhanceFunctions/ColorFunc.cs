using System.Drawing;

namespace ConsoleUtils.ConsoleEnhanceFunctions;

public static class ColorFunc
{
    public static ColorScheme CurrentColorScheme = new()
    {
        StartColor = Color.FromArgb(201,255,195),
        StartColorBackground = Color.FromArgb(17,34,18),
        AccentColor = Color.FromArgb(249,249,255),
        AccentColorBackground = Color.FromArgb(249,249,255),
    };
    public static void SetStartupColor(this EConsole console)
    {
        console.SetColor(CurrentColorScheme.StartColor);
        console.SetColor(CurrentColorScheme.StartColorBackground,true);
    }
    
    public static void SetColor(this EConsole console,Color color,bool isBackground = false) => 
        console.Output?.Write($"\x1b[{(isBackground ? "4" : "3")}8;2;" + color.R + ";" + color.G + ";" + color.B + "m");
}