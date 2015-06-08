using UnityEngine;
using System.Collections;

public class Man : MonoBehaviour {

	private TweenPosition tween;
	private Vector3 initPos = Vector3.zero;

	void Awake() {

	}

	void Start () {
		InitTween (initPos);
	}
	
	void Update () {

	}

	void InitTween(Vector3 pos) {
		print (pos);

		Vector3 yCenter = NGUIUtils.YCenterPosition ();
		float startPos = DataManager.getInstance().StartPos;
		float endtPos = DataManager.getInstance().EndPos;

		tween = GetComponent<TweenPosition> ();
		tween.from = new Vector3 (0, startPos, 0) + pos - yCenter;
		tween.to = new Vector3 (0, endtPos, 0) + pos - yCenter;
		tween.duration = 5.0f;
		tween.delay = 0.0f;
		tween.enabled = true;
	}

	public bool IsCanBeAttacked() {
		Vector3 yCenter = NGUIUtils.YCenterPosition ();
		float endtPos = DataManager.getInstance().EndPos;
		float canBeAttackRange = DataManager.getInstance().CanBeAttackRange;
		if (transform.localPosition.y >=  endtPos - canBeAttackRange - yCenter.y)
			return true;

		return false;
	}

	public Vector3 InitPos {
		set { initPos = value; }
	}
}
