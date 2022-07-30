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
            Lifetime = 0;
            DNA = new List<DNABase>();
            int dnaLength = DNAMutator.EvolutionAlgorithmRandomizer.Next(3, 30);

            for (int i = 0; i < dnaLength; i++)
            {
                DNA.Add(RandomTreeNodeCreator.CreateRandomNode());
            }
            EvolutionAlgo.EvolutionAlgorithm.OnStartGeneratingChildren += (x, y) =>
            {
                Lifetime += 1;
            };
            FirstName = Syllable.RandomName(true);
            LastName = Syllable.RandomName(false);
        }
        List<DNABase> DNA;
        int life;
        public delegate void CreatureData(SoundCreature creature);
        public event CreatureData OnLifetimeChanged;
        public string FirstName;
        public string LastName;
        public int Lifetime
        {
            get => life;
            set
            {
                life = value;
                OnLifetimeChanged?.Invoke(this);
            }
        }
        public SoundCreature CreateOffspring(SoundCreature partner = null, double MutationAllowance = -1)
        {
            SoundCreature creature = new SoundCreature();
            creature.life = 0;
            creature.DNA = DNA.CopyCreatures();
            creature.LastName = this.LastName;
            if (partner == null)
            {
                creature.FirstName = Syllable.RandomName();
            } else
            {
                creature.FirstName = partner.FirstName;
                if (creature.FirstName[0].IsAnyOf('a', 'e', 'i', 'o', 'u'))
                {
                    if (DNAMutator.EvolutionAlgorithmRandomizer.Next() % 2 == 0)
                    {
                        creature.FirstName = creature.FirstName.TrimStart('a', 'e', 'i', 'o', 'u');
                    }
                    else
                    {
                        creature.FirstName = Syllable.consonants.GetRandomMember() + creature.FirstName;
                    }
                }
                else
                {
                    if (DNAMutator.EvolutionAlgorithmRandomizer.Next() % 2 == 0)
                    {
                        creature.FirstName = creature.FirstName + Syllable.vowels.GetRandomMember(0, 5) + Syllable.endings.GetRandomMember();
                    }
                    else
                    {
                        creature.FirstName = Syllable.vowels.GetRandomMember() + creature.FirstName;
                    }
                }
                creature.DNA.AddRange(partner.DNA.CopyCreatures());
            }
            
            return creature;
        }
        public SoundCreature(SoundCreature parent)
        {

        }
        public int Size
        {
            get { return DNA.Count; }
        }

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
                double? res = null;
                if (DNA != null && DNA.Count > 0)
                {
                    for (int j = DNA.Count - 1; j >= 0; j -= 1)
                    {
                        res = DNA[j].Evaluate(res, i, duration);
                    }
                } else
                {
                    res = 0;
                }
                result[i] = res.Value * EvolutionAlgo.EvolutionAlgorithm.Volume;
            });
            //for (int i = 0; i < totalSamples; i++)
            //{
            //    double duration = (double)i / totalSamples;
            //    result[i] = TreeRoot.Evaluate(i, duration) * EvolutionAlgo.EvolutionAlgorithm.Volume;
            //}
            return result;
        }
        public DNABase this[int i] {
            get => GetNthNode(i);
            set {
                while (i >= DNA.Count) {
                    DNA.Add(RandomTreeNodeCreator.CreateRandomNode());
                }
            }
        }
        DNABase GetNthNode(int n)
        {
            if (DNA.Count == 0) return null;
            return DNA[n % DNA.Count];
        }
        public DNABase GetRandomNodeInRange(int startIndex = 0, int Count = -1)
        {
            return DNA.GetRandomMember(startIndex, Count);
        }

        public void AddNodeAtIndex(int index, DNABase node)
        {
            if (index < 0)
            {
                index = 0;
            }
            if (index >= DNA.Count)
            {
                DNA.Add(node);
            } else
            {
                DNA.Insert(index, node);
            }
        }

        public DNABase RemoveNodeAtIndex(int index)
        {
            if (index < 0) index = 0;
            if (index >= Size) index = Size - 1;
            var result = DNA[index];
            DNA.RemoveAt(index);
            return result;
        }
    }
}
