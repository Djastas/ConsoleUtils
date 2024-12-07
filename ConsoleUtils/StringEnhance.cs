using System.Text;

namespace ConsoleUtils;

public static class StringEnhance
{
    public static string Multiply(this string source, int multiplier) 
    { 
        return Enumerable.Range(1,multiplier)
            .Aggregate(new StringBuilder(multiplier*source.Length), 
                (sb, n)=>sb.Append(source))
            .ToString();
    }
}