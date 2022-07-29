using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waviate.Model;

namespace Waviate.Model.SpecificNodes
{
    class PolynomialNode : DNATreeNodeBase
    {
        public List<double> Polynomial = new List<double>();

        public override double Mutate(double amount)
        {
            double result;
            bool negative = DNAMutator.EvolutionAlgorithmRandomizer.Next() % 2 == 0;
            double s = DNAMutator.EvolutionAlgorithmRandomizer.NextDouble() * 12 * (negative ? -1 : 1);
            int randIndex = DNAMutator.EvolutionAlgorithmRandomizer.Next(0, Polynomial.Count);
            switch (DNAMutator.EvolutionAlgorithmRandomizer.Next() % 5)
            {
                case 0:
                    if (Polynomial.Count > 1)
                    {
                        Polynomial.RemoveAt(randIndex);
                        result = .05;
                        break;
                    }
                    goto case 2;
                case 1:
                    result = .08;
                    Polynomial.Add(s);
                    break;
                case 2:
                    result = .03;
                    Polynomial[randIndex] += s; 
                    break;
                case 3:
                    result = .055;
                    Polynomial[randIndex] = s;
                    break;
                default:
                    if (Polynomial.Count > 1)
                    {
                        int rand2 = (randIndex + 1) % Polynomial.Count;
                        double temp = Polynomial[randIndex];
                        Polynomial[randIndex] = Polynomial[rand2];
                        Polynomial[rand2] = temp;
                        result = .0474;
                        break;
                    }
                    goto case 1;
            }
            return result;
        }

        public override double MuteScore()
        {
            return .09;
        }

        protected override double eval(int sampleNumber, double duration)
        {
            double sum = 0;
            double total = 1;
            for (int i = Polynomial.Count - 1; i >= 0; i -= 1, total *= duration)
            {
                sum += total * Polynomial[i];
            }
            return sum;
        }
    }
}
