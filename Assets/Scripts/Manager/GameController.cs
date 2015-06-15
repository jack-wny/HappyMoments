using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController :MonoBehaviour{

	public Man man;
	public Princess princess;
	public GameObject parent;
	public UILabel labelScore;
	public GameObject btnRetry ;
	public UILabel scoreLbel ;
	public GameObject gameOverView ;
 
	private List<Man> manList = new List<Man>();
	private int mScore = 0;

	void Start(){
		HideWhenStart();
	}	

	void Update () {
		if (DataManager.getInstance ().IsGameOver) {
			return;
		}

		if (!DataManager.getInstance ().IsStart) {
			return;
		} else {
			ShowAfterStart();
		}
		DataManager.getInstance ().CurGameTime += Time.deltaTime;

		if (DataManager.getInstance ().IsGoMan) {
			DataManager.getInstance().GoMan();
			Man child = GameObject.Instantiate(man);
			AddMan(child);
		}

		if (IsClick() && princess.IsCanAttack()) {
			Debug.Log("click:" + manList.Count);
			for (int i = 0; i < manList.Count; ++i) {
				if (AttackMan(manList[i])) {
					return;
				}
			}
		}
	}

	void AddMan(Man child) {
		int columnCount = DataManager.getInstance().Column;
		float width = DataManager.getInstance().Width;
		int random = MathUtils.Random (0, columnCount - 1);
		Debug.Log (random);
		child.transform.parent = parent.transform;
		child.transform.localScale = new Vector3(1, 1, 1);
		child.InitPos = new Vector3 (width * ((random + 1.0f) / (columnCount + 1.0f) - 0.5f), 0, 0);
		manList.Add(child);
	}

	bool AttackMan(Man child) {
		if (child.IsCanBeAttacked ()) {
			princess.AttackMan (child);
			Destroy (child.gameObject);
			manList.Remove (child);
			AddScore(1);
			return true;
		}
		return false;
	}

	void AddScore(int score) {
		mScore += score;
		labelScore.text = "score:" + mScore;
	}

	public void OnClick () {
		ResetGame ();
	}

	void ResetGame() {
		mScore = 0;
		AddScore(0);
		for (int i = manList.Count - 1; i >= 0; --i) {
			Man child = manList[i];
			Destroy (child.gameObject);
			manList.Remove (child);
		}
		DataManager.getInstance ().ResetGame ();
	}

	bool IsClick() {
		if (Input.GetMouseButtonDown (0)) {
			return true;
		}
		return false;
	}

	public void HideWhenStart(){
		princess.gameObject.SetActive (false);
		btnRetry.gameObject.SetActive (false);
		scoreLbel.gameObject.SetActive (false);
	}

	bool hasStart = false ;
	public void ShowAfterStart(){
		if (hasStart == true)
			return;
		princess.gameObject.SetActive (true);
		btnRetry.gameObject.SetActive (true);
		scoreLbel.gameObject.SetActive(true);
		hasStart = true;
	}
}
