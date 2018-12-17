using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlers : MonoBehaviour {

	private Button roll_btn;
	private Button bounce_btn;

	int script_no = BallManager.script_no;
    GameObject monster;


    void Start()
	{
		roll_btn = GameObject.FindGameObjectWithTag("RollBtn").GetComponent<Button>();
		roll_btn.gameObject.SetActive(false);


		bounce_btn = GameObject.FindGameObjectWithTag("BounceBtn").GetComponent<Button>();
		bounce_btn.gameObject.SetActive(false);
	}
	public void startStimulation()
	{
		Debug.Log("startStimulation called.");
        BallManager.script_no = script_no;
    }
	public void CreateGround()
	{
		Debug.Log("CreateGround called.");
        monster = (GameObject)Instantiate(Resources.Load("Ground"));
        monster.transform.localPosition = new Vector3(0.19f, -0.6f, -1.51f);
    }
	public void CreateBall()
	{
		Debug.Log("CreateBall called.");
		roll_btn.gameObject.SetActive(true);
		bounce_btn.gameObject.SetActive(true);
	}
	public void RollingBall()
	{
		Debug.Log("Rolling Ball called.");
		script_no = 1;

	}
	public void BouncingBall()
	{
		Debug.Log("Bouncing Ball called.");
		script_no = 2;

	}
}
