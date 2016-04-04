using SztucznaInteligencja.Containers;

namespace SztucznaInteligencja
{
    public interface IDisplay
    {
        void DrawResult(Result result);
        void PrintResult(Result result);
        void WriteLine(string s);
    }
}