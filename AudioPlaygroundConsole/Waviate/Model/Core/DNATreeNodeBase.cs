using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waviate.Model
{
    public abstract class DNATreeNodeBase
    {
        public DNATreeNodeBase()
        {
            Children = new List<DNAConnector>();
        }
        public List<DNAConnector> Children;
        public int Size {
            get {
                int size = 0;
                for (int i = 0; i < Children.Count; i++)
                {
                    size += Children[i].connectedChild.Size;
                }
                return size + 1;
            }
        }
        public double Evaluate(int sampleNumber, double duration)
        {
            double result = eval(sampleNumber, duration);
            for (int i = 0; i < Children.Count; i++)
            {
                result = Children[i].Evaluate(result, sampleNumber, duration);
            }
            return result;
        }
        public DNAConnector Parent;
        public DNATreeNodeBase DeepCopy(DNAConnector parent = null)
        {
            var replicated = (DNATreeNodeBase)MemberwiseClone();
            replicated.Parent = parent;
            replicated.Children = replicated.Children.Copy();
            foreach (var child in Children)
            {
                replicated.Children.Add(child.copy(this));
            }
            return replicated;
        }
        protected abstract double eval(int sampleNumber, double duration);

        public abstract double Mutate(double amount);
        public abstract double MuteScore();
    }
}
