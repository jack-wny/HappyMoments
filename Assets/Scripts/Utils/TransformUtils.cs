using UnityEngine;
using System.Collections;

public class TransformUtils {
	
	public static  Vector3 SetPositionX(Vector3 pos, int x) {
		return new Vector3 (x, pos.y, pos.z);
	}

	public static  Vector3 SetPositionY(Vector3 pos, int y) {
		return new Vector3 (pos.x, y, pos.z);
	}

	public static Vector3 SetPositionZ(Vector3 pos, int z) {
		return new Vector3 (pos.x, pos.y, z);
	}
}
