using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class IkaExtensions
{
    public static void Shuffle<T>(this IList<T> list, Random r = null)
    {
        if (r == null)
        {
            r = Waviate.Model.DNAMutator.EvolutionAlgorithmRandomizer;
        }
        for (int i = list.Count - 1; i > 0; i -= 1)
        {
            int j = r.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public static T GetRandomMember<T>(this IList<T> list, Random r = null)
    {
        if (r == null)
        {
            r = Waviate.Model.DNAMutator.EvolutionAlgorithmRandomizer;
        }
        return list[r.Next(0, list.Count)];
    }

    public static T GetRandomMember<T>(this IList<T> list, int StartIndex, int Count, Random r = null)
    {
        if (r == null)
        {
            r = Waviate.Model.DNAMutator.EvolutionAlgorithmRandomizer;
        }
        if (Count == -1) Count = list.Count;
        int max = Math.Min(StartIndex + Count, list.Count - 1);
        return list[r.Next(StartIndex, max)];
    }

    public static List<T> Copy<T> (this List<T> coll)
    {
        
        List<T> list = new List<T>();
        foreach (T c in coll)
        {
            list.Add(c);
            
        }
        return list;
    }
    public static List<Waviate.Model.DNABase> CopyCreatures(this List<Waviate.Model.DNABase> coll)
    {
        List<Waviate.Model.DNABase> creatures = new List<Waviate.Model.DNABase>();
        foreach (var c in coll)
        {
            creatures.Add(c.DeepCopy());
        }
        return creatures;
    }

    public static bool IsAnyOf<T>(this T self, params T[] others)
    {
        foreach (T other in others)
        {
            if (self.Equals(other))
            {
                return true;
            }
        }
        return false;
    }
}
