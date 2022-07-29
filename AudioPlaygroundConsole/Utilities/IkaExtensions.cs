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

    public static List<T> Copy<T> (this List<T> coll)
    {
        List<T> list = new List<T>();
        foreach (T c in coll)
        {
            list.Add(c);
        }
        return list;
    }
}
