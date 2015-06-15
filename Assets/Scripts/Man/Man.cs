using UnityEngine;
using System.Collections;

public class Man : MonoBehaviour {
	
	private Vector3 initPos = Vector3.zero;
	private Vector3 endPos = Vector3.zero;
	
	void Start () {
		Init (initPos);
	}
	
	void Update () {
		if (DataManager.getInstance ().IsGameOver) {
			return;
		}

		float speed = DataManager.getInstance ().GetCurManSpeed ();
		transform.localPosition += new Vector3 (0, speed * Time.deltaTime, 0);
		if (transform.localPosition.y >= endPos.y) {
			DataManager.getInstance().IsGameOver = true;
		}
	}

	void Init(Vector3 pos) {
		print (pos);

		float startPos = DataManager.getInstance().StartPos;
		float endtPos = DataManager.getInstance().EndPos;

		transform.localPosition = new Vector3 (0, startPos, 0) + pos ;
		endPos = new Vector3 (0, endtPos, 0) + pos;
	}

	public bool IsCanBeAttacked() {
		float endtPos = DataManager.getInstance().EndPos;
		float canBeAttackRange = DataManager.getInstance().CanBeAttackRange;
		if (transform.localPosition.y >=  endtPos - canBeAttackRange)
			return true;

		return false;
	}

	public Vector3 InitPos {
		set { initPos = value; }
	}
}
