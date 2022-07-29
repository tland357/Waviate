using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waviate.Model;
using Waviate.Model.SpecificNodes;

public static class RandomTreeNodeCreator
{
    public static DNATreeNodeBase CreateRandomNode()
    {
        int type = DNAMutator.EvolutionAlgorithmRandomizer.Next();
        PolynomialNode poly;
        switch (type % 4)
        {
            case 0:
                poly = new TurbulenceNode();
                break;
                
            case 1:
                poly = new PolynomialNode();
                break;
            default: goto case 1;
        }
        int t = DNAMutator.EvolutionAlgorithmRandomizer.Next(2, 7);
        for (int i = 0; i < t; i += 1)
        {
            double x = DNAMutator.EvolutionAlgorithmRandomizer.Next(19, 480);
            double y = DNAMutator.EvolutionAlgorithmRandomizer.NextDouble();
            double z = DNAMutator.EvolutionAlgorithmRandomizer.Next() % 2 == 0 ? -1 : 1;
            poly.Polynomial.Add((x + y) * z);
        }
        //res.Polynomial = new List<double> { 84.12512512, 982.523151515};
        return poly;
    }
}
