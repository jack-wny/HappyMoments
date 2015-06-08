using UnityEngine;
using System.Collections;

public class Princess : MonoBehaviour {

	private float lastAtkTime = 0.0f;

	// Use this for initialization
	void Start () {
		Vector3 yCenter = NGUIUtils.YCenterPosition ();
		transform.localPosition = new Vector3(0, DataManager.getInstance ().EndPos - yCenter.y, 0) ;
	}
	
	// Update is called once per frame
	void Update () {
		lastAtkTime += Time.deltaTime;
	}

	public bool IsCanAttack() {
		float interval = DataManager.getInstance ().AtkInterval;
		if (lastAtkTime >= interval) {
			return true;
		}

		return false;
	}

	public void AttackMan(Man man) {
		lastAtkTime = 0.0f;
	}
}
