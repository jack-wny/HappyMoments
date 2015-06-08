using UnityEngine;
using System.Collections;

public class NGUIUtils {

	public static Vector2 GetScreenSize() {
		return new Vector2 (720, 1280);
	}

	public static Vector3 YCenterPosition() {
		return new Vector3(0, GetScreenSize().y / 2, 0);
	}
}
