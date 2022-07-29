using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waviate.Model
{
    public static class DNAMutator
    {
        public static Random EvolutionAlgorithmRandomizer = new Random(0);
        public static void SeedRandomizer(int seed)
        {
            EvolutionAlgorithmRandomizer = new Random(seed);
        }
        public static SoundCreature Mutate(SoundCreature parent, double MutationLimit)
        {
            SoundCreature offspring = parent.CreateOffspring(MutationLimit);
            double mutationCount = 0;
            for (int i = 0; i < 32 && mutationCount < MutationLimit; i += 1)
            {
                mutationCount += mutes.GetRandomMember()(offspring);
            }
            return offspring;
        }
        delegate double Mutation(SoundCreature target);
        static double ChangeRandomConnector(SoundCreature target)
        {
            double connectorChangeAmount = 0;
            int s = target.Size - 1;
            int randomN = EvolutionAlgorithmRandomizer.Next(0, s);
            var connector = target.GetNthConnector(randomN, s);
            if (connector == null) return 0;
            var par = connector.connectedParent;
            for (int i = 0; i < par.Children.Count; i++)
            {
                if (par.Children[i] == connector)
                {
                    var newChild = DNAConnector.GetRandomConnector(connector.connectedChild, par, EvolutionAlgorithmRandomizer.Next(0, DNAConnector.NumberOfModRules));
                    connectorChangeAmount += newChild.Difference(connector) / s + 10;
                }
            }
            return connectorChangeAmount;
        }
        static double ReplaceNodeWithRandom(SoundCreature target)
        {
            var randomNode = RandomTreeNodeCreator.CreateRandomNode();
            var DeletedNode = target.GetRandomNode();
            if (DeletedNode == null) return 0;
            var ParentConnector = DeletedNode.Parent;
            ParentConnector.connectedChild = randomNode;
            randomNode.Parent = ParentConnector;
            randomNode.Children = DeletedNode.Children;
            return Math.Max(randomNode.MuteScore(), DeletedNode.MuteScore());
        }
        public static double AddRandomNode(SoundCreature target)
        {
            
            var randomNode = RandomTreeNodeCreator.CreateRandomNode();
            var leaf = target.GetRandomNode();
            if (leaf == null) return 0;
            var conn = DNAConnector.GetRandomConnector(randomNode, leaf);
            leaf.Children.Add(conn);
            return randomNode.MuteScore();
        }
        static double MutateRandomNode(SoundCreature target)
        {
            var rNode = target.GetRandomNode();
            if (rNode == null) return 0;
            return rNode.Mutate(.5);
        }
        static Mutation[] mutes = new Mutation[]
        {
            ChangeRandomConnector,
            ChangeRandomConnector,
            ChangeRandomConnector,
            MutateRandomNode,
            MutateRandomNode,
            MutateRandomNode,
            MutateRandomNode,
            MutateRandomNode,
            MutateRandomNode,
            AddRandomNode,
            AddRandomNode,
            AddRandomNode,
            AddRandomNode,
        };
    }
}
