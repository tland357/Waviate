using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waviate.Model
{
    public abstract class DNABase
    {
        public DNABase()
        {
            Child = DNAConnector.GetRandomConnector();
        }
        public DNAConnector Child;
        
        public double Evaluate(double? nextDNA, int sampleNumber, double duration)
        {
            double result = eval(sampleNumber, duration);
            if (nextDNA == null) return result;
            return Child.Evaluate(result, nextDNA.Value, sampleNumber, duration);
        }
        public DNABase DeepCopy()
        {
            var replicated = (DNABase)MemberwiseClone();
            replicated.Child = Child.copy();
            return replicated;
        }
        protected abstract double eval(int sampleNumber, double duration);

        public abstract double Mutate(double amount);
        public abstract double MuteScore();
    }
}
