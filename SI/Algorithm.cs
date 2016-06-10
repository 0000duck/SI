using SI.Constructs;

namespace SI
{
    public abstract class Algorithm
    {
        protected Result _result;
        public abstract void Execute(Lines lines);

        public virtual Result GetResult()
        {
            return _result;
        }
    }
}
