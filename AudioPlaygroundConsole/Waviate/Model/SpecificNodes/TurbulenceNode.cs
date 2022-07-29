using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waviate.Model;
using SharpNoise;
using SharpNoise.Models;

namespace Waviate.Model.SpecificNodes
{
    class TurbulenceNode : PolynomialNode
    {
        SharpNoise.Modules.Perlin turb = new SharpNoise.Modules.Perlin()
        {
            Frequency = DNAMutator.EvolutionAlgorithmRandomizer.NextDouble() * .00001 + .000001,
            Lacunarity = DNAMutator.EvolutionAlgorithmRandomizer.Next(1, 8),
            OctaveCount = DNAMutator.EvolutionAlgorithmRandomizer.Next(1, 10),
            Seed = DNAMutator.EvolutionAlgorithmRandomizer.Next(),
        };
        public int DurationSampleMode = 0;
        public override double Mutate(double amount)
        {
            double multer = DNAMutator.EvolutionAlgorithmRandomizer.NextDouble();
            turb.Frequency *= multer + .5;
            return (.5 - multer) / 5;
        }

        public override double MuteScore()
        {
            return .1;
        }

        protected override double eval(int sampleNumber, double duration)
        {
            double polyEval = base.eval(sampleNumber, duration);
            switch (DurationSampleMode)
            {
                case 0:
                    return 8000 * turb.GetValue((double)sampleNumber / 100000, duration / 1000, 0) + polyEval;
                case 1:
                    return 8000 * turb.GetValue(0, 0, (double)sampleNumber / 100000);
                case 2:
                    return turb.GetValue(duration, 0, 0);
                default:
                    goto case 0;
            }
        }
    }
}
