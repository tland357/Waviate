﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waviate.Model
{
    public class DNAConnector
    {
        public DNAConnector copy(DNATreeNodeBase newParent)
        {
            DNAConnector clone = (DNAConnector) MemberwiseClone();
            var child = clone.connectedChild.DeepCopy(this);
            clone.connectedChild = child;
            clone.connectedParent = newParent;
            return clone;
        }
        public const int NumberOfModRules = 4;
        public static DNAConnector GetRandomConnector(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule = -1)
        {
            int i = DNAMutator.EvolutionAlgorithmRandomizer.Next(0, 8);
            if (modRule == -1)
            {
                modRule = DNAMutator.EvolutionAlgorithmRandomizer.Next(0, NumberOfModRules);
            }
            switch (i)
            {
                case 1:
                    return new DNAConnectorEvenSlice(child, parent, modRule);
                case 2:
                    return new DNAConnectorAvg(child, parent, modRule);
                case 3:
                    return new DNAConnectorTan(child, parent, modRule);
                case 4:
                    return new DNAConnectorSin(child, parent, modRule);
                case 5:
                    return new DNAConnectorDiv(child, parent, modRule);
                case 6:
                    return new DNAConnectorMult(child, parent, modRule);
                case 7:
                    return new DNAConnectorSubtract(child, parent, modRule);
            }
            return new DNAConnector(child, parent, modRule);
        }
        public DNAConnector(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule = 0)
        {
            child.Parent = this;
            connectedChild = child;
            ModRule = modRule;
        }
        public DNATreeNodeBase connectedParent;
        public DNATreeNodeBase connectedChild {
            get; 
            set;
        }
        int ModRule = 0;
        public double Evaluate(double parentOutput, int sample, double duration)
        {
            double result = EvaluateConnection(parentOutput, sample, duration);
            switch (ModRule)
            {
                case 1:
                    return IkaStaticMath.ZigZagRepeat(result);
                case 2:
                    return Math.Sin(result);
                case 3:
                    return result > 1 ? 1 : (result < -1 ? -1 : 0);
                default:
                    return result % 1.0;
            }
        }
        virtual protected double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            return parentOutput + connectedChild.Evaluate(sample, duration);
        }
        public virtual int ClassOrder() { return 0; }
        public double Difference(DNAConnector other)
        {
            int otherOrder = other.ClassOrder();
            double ModRuleDiff = Math.Abs(0.05 * ModRule - other.ModRule);
            int thisOrder = ClassOrder();
            double diff;
            if (thisOrder < otherOrder)
            {
                diff = Diff(other);
            } else
            {
                diff = other.Diff(this);
            }
            return ModRuleDiff + otherOrder == ClassOrder() ? 0 : diff;
        }
        public virtual double Diff(DNAConnector other)
        {
            switch (other.ClassOrder()) {
                case 1:
                    return 0.1;
                case 2:
                    return 0.31;
                case 3:
                    return 0.41;
                case 4:
                    return 0.88;
                case 5:
                    return 0.78;
                case 6:
                    return 0.01;
                case 7:
                    return 0.22;
            }
            return .3;
        }
    }

    public class DNAConnectorSubtract : DNAConnector
    {
        public DNAConnectorSubtract(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule) : base(child, parent, modRule) { }
        protected override double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            return parentOutput - connectedChild.Evaluate(sample, duration);
        }
        public override int ClassOrder() { return 1; }
        public override double Diff(DNAConnector other)
        {
            return base.Diff(other);
        }
    }

    public class DNAConnectorMult : DNAConnector
    {
        public DNAConnectorMult(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule) : base(child, parent, modRule) { }
        protected override double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            return parentOutput * connectedChild.Evaluate(sample, duration);
        }
        public override int ClassOrder() { return 2; }
        public override double Diff(DNAConnector other)
        {
            switch (other.ClassOrder())
            {
                case 3:
                    return 0.18;
                case 4:
                    return 0.58;
                case 5:
                    return 0.57;
                case 6:
                    return 0.33;
                case 7:
                    return 0.35;
            }
            return base.Diff(other);
        }
    }

    public class DNAConnectorDiv : DNAConnector
    {
        public DNAConnectorDiv(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule) : base(child, parent, modRule) { }
        protected override double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            return IkaStaticMath.Clamp(parentOutput / connectedChild.Evaluate(sample, duration), -1000000, 1000000);
        }
        public override int ClassOrder() { return 3; }
        public override double Diff(DNAConnector other)
        {
            switch (other.ClassOrder())
            {
                case 4:
                    return 0.48;
                case 5:
                    return 0.51;
                case 6:
                    return 0.36;
                case 7:
                    return 0.38;
            }
            return base.Diff(other);
        }
    }
    public class DNAConnectorSin : DNAConnector
    {
        public DNAConnectorSin(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule) : base(child, parent, modRule) { }
        protected override double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            return parentOutput * Math.Sin(connectedChild.Evaluate(sample, duration));
        }
        public override int ClassOrder() { return 4; }
        public override double Diff(DNAConnector other)
        {
            switch (other.ClassOrder())
            {
                case 5:
                    return 0.61;
                case 6:
                    return 0.89;
                case 7:
                    return 0.85;
            }
            return base.Diff(other);
        }
    }

    public class DNAConnectorTan : DNAConnector
    {
        public DNAConnectorTan(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule) : base(child, parent, modRule) { }
        protected override double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            return IkaStaticMath.Clamp(Math.Tan(connectedChild.Evaluate(sample, duration) + parentOutput),-1000000,1000000);
        }
        public override int ClassOrder() { return 5; }
        public override double Diff(DNAConnector other)
        {
            switch (other.ClassOrder())
            {
                case 6:
                    return 0.85;
                case 7:
                    return 0.89;
            }
            return base.Diff(other);
        }
    }

    public class DNAConnectorAvg : DNAConnector
    {
        public DNAConnectorAvg(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule) : base(child, parent, modRule) { }
        protected override double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            return parentOutput * connectedChild.Evaluate(sample, duration);
        }
        public override int ClassOrder() { return 6; }
        public override double Diff(DNAConnector other)
        {
            switch(other.ClassOrder())
            {
                case 7:
                    return 0.11;
            }
            return base.Diff(other);
        }
    }

    public class DNAConnectorEvenSlice : DNAConnector
    {
        public DNAConnectorEvenSlice(DNATreeNodeBase child, DNATreeNodeBase parent, int modRule) : base(child, parent, modRule) { }
        protected override double EvaluateConnection(double parentOutput, int sample, double duration)
        {
            if (sample % 2 == 0)
            {
                return parentOutput;
            }
            return connectedChild.Evaluate(sample, duration);
        }
        public override int ClassOrder() { return 7; }
        public override double Diff(DNAConnector other)
        {
            return base.Diff(other);
        }
    }
}
