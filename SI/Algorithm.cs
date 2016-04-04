using SztucznaInteligencja.Containers;

namespace SI
{
    abstract class Algorithm
    {
        public abstract void Execute(Lines lines);

        public abstract Result GetResult();
    }
}
