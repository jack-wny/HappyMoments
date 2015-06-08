using UnityEngine;
using System.Collections;

public class IController <T> where T : class, new() {

	private static T instance = new T();
	public static T getInstance() {
		return instance;
	}
}
