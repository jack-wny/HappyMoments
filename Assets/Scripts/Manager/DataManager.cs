using UnityEngine;
using System.Collections;

public class DataManager : IController<DataManager> {

	// ---- 配置数据
	private int columnCount = 3;      		// 行数
	private float goManSpeed = 1.0f;        // 出怪速度
	private float goManAcc = 0.05f; 		// 出怪加速度
	private float canBeAttackRange = 0.2f;  // 可攻击范围
	private float startPos = 0.0f;          // 开始位置
	private float endPos = 0.875f;      	// 结束位置
	private float width = 1.30f;      		// 宽度
	private float atkInterval = 0.1f;  		// 攻击间隔
	private float startSpeed = 0.1f;    	// 开始速度
	private float acceleration = 0.01f;		// 加速度

	// ---- 游戏数据
	private float curGameTime = 0.0f; 		// 当前游戏时间
	private bool isGameOver = false;        // 是否游戏结束
	private float lastManTime = 0.0f;       // 下一个出怪点

	public int Column {
		get { return columnCount; }
	}

	public float StartPos {
		get { return startPos * ScreenSize.y - NGUIUtils.YCenterPosition().y; }
	}

	public float EndPos {
		get { return endPos * ScreenSize.y - NGUIUtils.YCenterPosition().y; }
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

	public float GetCurManSpeed() {
		return (startSpeed + acceleration * curGameTime) * ScreenSize.y;
	}

	public bool IsGameOver {
		get { return isGameOver; }
		set { isGameOver = value; }
	}

	public float CurGameTime {
		get { return curGameTime; }
		set { curGameTime = value; }
	}

	public float CurGoManSpeed {
		get { 
			float speed =  goManSpeed - goManAcc * curGameTime; 
			return speed > 0.3f ? speed : 0.3f;
		}
	}

	public bool IsGoMan {
		get { return curGameTime >= lastManTime; }
	}

	public void GoMan() {
		lastManTime = curGameTime + CurGoManSpeed;
	}

	public void ResetGame () {
		IsGameOver = false;
		CurGameTime = 0.0f;
		lastManTime = 0.0f;
	}
}
