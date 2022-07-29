using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waviate.Model
{
    public class SoundCreature : AudioPlaygroundConsole.AudioArrayCreator
    {
        public SoundCreature()
        {
            TreeRoot = RandomTreeNodeCreator.CreateRandomNode();
            int add = DNAMutator.EvolutionAlgorithmRandomizer.Next(3, 8);
            for (int i = 0; i < add; i++)
            {
                DNAMutator.AddRandomNode(this);
            }
        }
        public SoundCreature CreateOffspring(double MutationAllowance)
        {
            SoundCreature creature = (SoundCreature)MemberwiseClone();
            creature.TreeRoot = TreeRoot.DeepCopy();
            return creature;
        }
        public SoundCreature(SoundCreature parent)
        {

        }
        public int Size
        {
            get { return TreeRoot?.Size ?? 0; }
        }
        DNATreeNodeBase TreeRoot;
        protected double SecondsLength()
        {
            return EvolutionAlgo.EvolutionAlgorithm.TimeLength;
        }
        protected override IList<double> GetAudio()
        {
            double SamplesPerSecond = AudioFileWriter.numsamples;
            int totalSamples = (int)Math.Round(SamplesPerSecond * SecondsLength());
            double[] result = new double[totalSamples];
            Parallel.For(0, totalSamples, i =>
            {
                double duration = (double)i / totalSamples;
                result[i] = TreeRoot.Evaluate(i, duration) * EvolutionAlgo.EvolutionAlgorithm.Volume;
            });
            //for (int i = 0; i < totalSamples; i++)
            //{
            //    double duration = (double)i / totalSamples;
            //    result[i] = TreeRoot.Evaluate(i, duration) * EvolutionAlgo.EvolutionAlgorithm.Volume;
            //}
            return result;
        }
        public DNATreeNodeBase GetNthNode(int n, int knownSize = -1)
        {
            int curr = 0;
            DNATreeNodeBase node = TreeRoot;
            int size = knownSize;
            if (knownSize == -1) size = Size;
            if (n >= size) n = size - 1;
            if (n < 0) n = 0;
            return getNthNode(n, node, ref curr);
        }

        DNATreeNodeBase getNthNode(int n, DNATreeNodeBase node, ref int curr)
        {
            if (n == curr) return node;
            curr += 1;
            for (int i = 0; i < node.Children.Count; i += 1)
            {
                DNATreeNodeBase child = node.Children[i].connectedChild;
                var next = getNthNode(n, child, ref curr);
                if (next != null)
                {
                    return next;
                }
            }
            return null;
        }

        public DNAConnector GetNthConnector(int n, int knownSize = -1)
        {
            int curr = 0;
            DNATreeNodeBase node = TreeRoot;
            int size = knownSize;
            if (knownSize == -1) size = Size;
            if (n >= size - 1) n = size - 2;
            if (n < 0) n = 0;
            return getNthConnector(n, node,ref curr);
        }

        DNAConnector getNthConnector(int n, DNATreeNodeBase node, ref int curr)
        {
            for (int i = 0; i < node.Children.Count; i += 1)
            {
                DNAConnector child = node.Children[i];
                var next = getNthConnector(n, child.connectedChild, ref curr);
                if (next != null)
                {
                    return next;
                }
                curr += 1;
            }
            return null;
        }
        public DNATreeNodeBase GetRandomLeafNode()
        {
            List<DNATreeNodeBase> leaves = new List<DNATreeNodeBase>();
            DNATreeNodeBase root = TreeRoot;
            getLeafNodeList(root, ref leaves);
            return leaves.GetRandomMember();
        }

        void getLeafNodeList(DNATreeNodeBase node, ref List<DNATreeNodeBase> list)
        {
            if (node.Children.Count == 0) list.Add(node);
            else
            {
                foreach (var child in node.Children)
                {
                    getLeafNodeList(child.connectedChild, ref list);
                }
            }
        }

        public DNATreeNodeBase GetRandomNode()
        {
            List<DNATreeNodeBase> nodes = new List<DNATreeNodeBase>();
            if (this.TreeRoot == null) return null;
            getNodeList(this.TreeRoot, ref nodes);
            return nodes.GetRandomMember();
        }

        void getNodeList(DNATreeNodeBase node, ref List<DNATreeNodeBase> list)
        {
            list.Add(node);
            foreach (var child in node.Children)
            {
                getNodeList(child.connectedChild, ref list);
            }
        }
    }
}
