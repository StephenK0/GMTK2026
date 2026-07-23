using UnityEngine;
using System.Collections.Generic;

public class Util
{
	//Should implement Fisher-Yates, if I did everything correctly?
	public static List<T> ShuffleList<T>(List<T> toShuffle) {
		for(int i = 1; i < toShuffle.Count; i++) {
			int j = Random.Range(i, toShuffle.Count);
			T temp = toShuffle[j];
			toShuffle[j] = toShuffle[i - 1];
			toShuffle[i - 1] = temp;
		}
		return toShuffle;
	}

	public static void TestShuffleList(int count, int repeats = 1) {
		Debug.Log("Testing list shuffling: ");

		List<int> ints = new List<int>();
		for(int j = 0; j < count; j++) ints.Add(j);

		for(int i = 0; i < repeats; i++) {
			Debug.Log("Trial " + i + ": ");
			ints = ShuffleList(ints);
			Util.PrintList(ints);
		}
	}

	public static void PrintList<T>(List<T> list, string tag = "") {
		tag += "[ " + list[0];
		for(int i = 1; i < list.Count; i++) tag += ", " + list[i];
		Debug.Log(tag + " ]");
	}
}
