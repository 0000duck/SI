using SI.Constructs;

namespace SI
{
    public abstract class Algorithm
    {
        public abstract void Execute(Lines lines);

        public abstract Result GetResult();
    }
}
