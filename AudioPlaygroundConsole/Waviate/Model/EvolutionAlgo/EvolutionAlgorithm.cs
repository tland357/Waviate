using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waviate.Model;
using System.Windows.Forms;
using System.ComponentModel;
namespace Waviate.Model.EvolutionAlgo
{
    public static class EvolutionAlgorithm
    {
        static double vol = 0.2;
        static double time;
        public static double TimeLength
        {
            get { return time; }
            set 
            { 
                time = value; 
                foreach (var creature in CurrentPopulation)
                {
                    creature.MakeDirty();
                }
            }
        }
        public static event EventHandler OnSpawnedPopulation;
        public static event EventHandler OnNextGenPopulation;
        public static event EventHandler OnClearedPopulation;
        public static double Volume
        {
            get
            {
                return vol;
            }
            set 
            {
                vol = value;
                foreach (var creature in CurrentPopulation)
                {
                    creature.MakeDirty();
                }
            }
        }
        public static List<SoundCreature> CurrentPopulation = new List<SoundCreature>();
        public static bool Started;
        public static void Start(int NumberOfStarters, int seed)
        {
            DNAMutator.SeedRandomizer(seed);
            CurrentPopulation = new List<SoundCreature>();
            for (int i = 0; i < NumberOfStarters; i++)
            {
                CurrentPopulation.Add(new SoundCreature());
            }
            OnSpawnedPopulation(CurrentPopulation, null);
            Started = true;
        }

        //returns empty list if no survivors are chosen
        public static IEnumerable<SoundCreature> NextGenerationTest(IList<int> Survivors, int AmountInNextGeneration, double MutationAllowance)
        {
            if (Survivors.Count > 0 && AmountInNextGeneration > 0 && Survivors.Count <= AmountInNextGeneration)
            {
                CurrentPopulation.Shuffle();
                for (int i = 0; i < AmountInNextGeneration; i += 1)
                {
                    foreach (int survivorindex in Survivors)
                    {
                        yield return null;// CurrentPopulation[survivorindex].CreateOffspring(MutationAllowance);
                    }
                }
            }
            
        }
        public delegate void ProgressEventHandler(object sender, ProgressChangedEventArgs e);
        public static event ProgressEventHandler OnUpdateProgress;
        public static event EventHandler OnStartGeneratingChildren;
        public static bool Breeds;
        public static bool OnlyRecentGeneration;
        public static bool Mutates;
        public static int NumberOfChildrenPerCouple = 1;
        public static void NextGeneration(List<int> Kills, int AmountInNextGeneration, double MutationAllowance)
        {
            OnStartGeneratingChildren?.Invoke(null, null);
            if (Kills.Count < CurrentPopulation.Count && AmountInNextGeneration > 0)
            {
                int killIndexShift = -1;
                Kills.Sort();
                foreach (var kill in Kills)
                {
                    CurrentPopulation.RemoveAt(kill - ++killIndexShift);
                }
                int MostRecentGen = CurrentPopulation.Select(x => x.Lifetime).Min();
                List<SoundCreature> breedables;
                if (OnlyRecentGeneration)
                {
                    breedables = CurrentPopulation.Where(c => c.Lifetime == MostRecentGen).ToList();
                }
                else if (Breeds)
                {
                    breedables = CurrentPopulation;
                } else
                {
                    breedables = CurrentPopulation.Copy();
                }
                int breedablesLength = breedables.Count;
                if (Breeds)
                {
                    int index = 0;
                    for (int childNum = 0; childNum < NumberOfChildrenPerCouple; childNum += 1)
                    {
                        for (int i = 0; i < breedablesLength; i += 1) { 
                            int next = (index + 1) % breedablesLength;
                            var newCreature = DNAMutator.CrossBreed(breedables[index], breedables[next]);
                            DNAMutator.Mutate(newCreature, Mutates ? MutationAllowance : -1);
                            CurrentPopulation.Add(newCreature);
                            if (OnUpdateProgress != null)
                            {
                                OnUpdateProgress(newCreature, new ProgressChangedEventArgs((int)(100.0 * (1.0 + i + ((childNum)* breedablesLength)) / (double)(breedablesLength *NumberOfChildrenPerCouple)), null));
                            }
                            index = next;
                        }
                    }
                } 
                else
                {
                    int i = 0;
                    foreach (SoundCreature creature in breedables)
                    {
                        var newCreature = creature.CreateOffspring();
                        DNAMutator.Mutate(newCreature, MutationAllowance);
                        CurrentPopulation.Add(newCreature);
                        if (OnUpdateProgress != null)
                        {
                            OnUpdateProgress(newCreature, new ProgressChangedEventArgs((int)(100.0 * ((double)++i / (double)breedablesLength)), null));
                        }
                    }
                }
                
                CurrentPopulation.Sort((c1, c2) =>
                {
                    return c1.Lifetime - c2.Lifetime;
                });
                if (OnNextGenPopulation != null)
                {
                    OnNextGenPopulation(CurrentPopulation, null);
                }
            }
        }

        public static void Reset()
        {
            CurrentPopulation.Clear();
            Started = false;
            OnClearedPopulation(null, null);
        }
    }
}
