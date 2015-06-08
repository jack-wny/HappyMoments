using UnityEngine;
using System.Collections;

public class MathUtils {
	private static System.Random random = new System.Random ();
	
	public static double Random() {
		return random.NextDouble();
	}
	
	public static int Random(int max) {
		return random.Next(max+1);
	}

	public static int Random(int min, int max) {
		return random.Next(min, max+1);
	}
}
