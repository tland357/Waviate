using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waviate.Model;

public static class Syllable
{
	public static string[] consonants = {"b","br","c","ch","d","dr","f","fr","g","h","j",
										"k","l","m","n","p","ph","q","qu","r","s","sh","sch",
										"sr","t","th","tr","tw","v","w","x","y","z"};
	public static string[] vowels = { "a", "e", "i", "o", "u", "ah", "ee", "oo", "ou" };
	public static string[] endings = {"b","ck","d","g","m","n","p","ph",
										"t","th","v","w","x"};
	public static string RandomName(bool FirstName = true)
	{
		string start;
		bool startsWithVowel = DNAMutator.EvolutionAlgorithmRandomizer.Next() % 4 == 0;
		if (startsWithVowel)
		{
			start = vowels.GetRandomMember(0, 5);
		} else
		{
			start = consonants.GetRandomMember() + vowels.GetRandomMember();
		}
		string middle = "";
		int min = FirstName ? 1 : 2;
		int max = FirstName ? 3 : 4;
		int MiddleLength = DNAMutator.EvolutionAlgorithmRandomizer.Next(min,max);
		for (int i = 0; i < MiddleLength; i += 1)
		{
			middle += consonants.GetRandomMember() + vowels.GetRandomMember();
		}
		return start + middle + endings.GetRandomMember();
	}
}
