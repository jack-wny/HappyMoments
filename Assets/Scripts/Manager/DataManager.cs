using UnityEngine;
using System.Collections;

public class DataManager : IController<DataManager> {

	private int columnCount = 3;      // 行数
	private float[] datas = {0.1f, 0.6f, 0.7f, 0.8f, 0.9f, 1.1f, 1.6f, 1.9f, 2.5f, 2.8f, 3.5f, 4.0f, 5.0f, 6.0f};
	private float canBeAttackRange = 0.2f; // 可攻击范围
	private float startPos = 0.0f;    // 开始位置
	private float endPos = 0.875f;    // 结束位置
	private float width = 0.75f;      // 宽度
	private float atkInterval = 0.3f; // 攻击间隔

	public int Column {
		get { return columnCount; }
	}
	
	public float[] QueueData {
		get { return datas; }
	}

	public float StartPos {
		get { return startPos * ScreenSize.y; }
	}

	public float EndPos {
		get { return endPos * ScreenSize.y; }
	}

	public float CanBeAttackRange {
		get { return canBeAttackRange * ScreenSize.y; }
	}

	public float Width {
		get { return width * ScreenSize.x; }
	}

	public Vector2 ScreenSize {
		get { return NGUIUtils.GetScreenSize (); }
	}

	public float AtkInterval {
		get { return atkInterval; }
	}
}
