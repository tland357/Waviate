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
                        yield return CurrentPopulation[survivorindex].CreateOffspring(MutationAllowance);
                    }
                }
            }
            
        }
        public delegate void ProgressEventHandler(object sender, ProgressChangedEventArgs e);
        public static event ProgressEventHandler OnUpdateProgress;
        public static void NextGeneration(IList<int> Survivors, int AmountInNextGeneration, double MutationAllowance)
        {
            if (Survivors.Count > 0 && AmountInNextGeneration > 0 && Survivors.Count <= AmountInNextGeneration)
            {
                List<SoundCreature> list = new List<SoundCreature>();
                for (int i = 0; i < AmountInNextGeneration; i += 1)
                {
                    int index = Survivors[i % Survivors.Count];
                    var newCreature = DNAMutator.Mutate(CurrentPopulation[index], MutationAllowance);
                    list.Add(newCreature);
                    if (OnUpdateProgress != null)
                    {
                        OnUpdateProgress(newCreature, new ProgressChangedEventArgs((int)((double)100 * (i + 1) / AmountInNextGeneration), null));
                    }
                }
                if (OnNextGenPopulation != null)
                {
                    OnNextGenPopulation(list, null);
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
