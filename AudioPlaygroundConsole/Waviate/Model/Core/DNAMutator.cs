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
        public static SoundCreature CrossBreed(SoundCreature a, SoundCreature b)
        {
            return a.CreateOffspring(b);
        }
        public static void Mutate(SoundCreature offspring, double MutationLimit)
        {
            if (MutationLimit < 0) return;
            double mutationCount = 0;
            for (int i = 0; mutationCount < MutationLimit; i += 1)
            {
                mutationCount += mutes.GetRandomMember()(offspring);
            }
            offspring.MakeDirty();
        }
        delegate double Mutation(SoundCreature target);
        static double ChangeRandomConnector(SoundCreature target)
        {
            var node = target.GetRandomNodeInRange(0, target.Size - 1);
            var prev = node.Child;
            var next = DNAConnector.GetRandomConnector();
            node.Child = next;
            return next.Difference(prev);
        }
        static double ReplaceNodeWithRandom(SoundCreature target)
        {
            int index = EvolutionAlgorithmRandomizer.Next(0, target.Size);
            var AddedNode = RandomTreeNodeCreator.CreateRandomNode();
            var DeletedNode = target[index];
            AddedNode.Child = DeletedNode.Child;
            target[index] = AddedNode;
            return Math.Max(AddedNode.MuteScore(), DeletedNode.MuteScore());
        }
        static double RemoveNodeIfPossible(SoundCreature target)
        {
            if (target.Size > 1)
            {
                int index = EvolutionAlgorithmRandomizer.Next(0, target.Size);
                DNABase resultNode = target.RemoveNodeAtIndex(index);
                return resultNode.MuteScore();
            }
            return 0;
        }
        public static double AddRandomNode(SoundCreature target)
        {
            int index = EvolutionAlgorithmRandomizer.Next(0, target.Size + 1);
            var randomNode = RandomTreeNodeCreator.CreateRandomNode();
            target.AddNodeAtIndex(index, randomNode);
            return randomNode.MuteScore();
        }
        static double MutateRandomNode(SoundCreature target)
        {
            var rNode = target.GetRandomNodeInRange();
            if (rNode == null) return 0;
            return rNode.Mutate(.5);
        }
        static Mutation[] mutes = new Mutation[]
        {
            ChangeRandomConnector,
            MutateRandomNode,
            AddRandomNode,
            ReplaceNodeWithRandom,
            RemoveNodeIfPossible,
        };
    }
}
