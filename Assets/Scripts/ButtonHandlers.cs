using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class ButtonHandlers : MonoBehaviour {

	private Button roll_btn;
	private Button bounce_btn;

	int script_no = BallManager.script_no;
	GameObject ground,ball;

	FileStream file;

    StreamWriter writer;


    void Start()
	{

        file = File.Open("Objects.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        writer = new StreamWriter(file);

        roll_btn = GameObject.FindGameObjectWithTag("RollBtn").GetComponent<Button>();
		roll_btn.gameObject.SetActive(false);


		bounce_btn = GameObject.FindGameObjectWithTag("BounceBtn").GetComponent<Button>();
		bounce_btn.gameObject.SetActive(false);
	}
	public void startStimulation()
	{
		Debug.Log("startStimulation called.");

		string script="";

		if (script_no == 1)
		{
			script = "Rolling";
		} else
		{
			script = "Bouncing";
		}

        writer.WriteLine("{ \"BallScript\": \" "+ script + "\" }");
        writer.Close();

        BallManager.script_no = script_no;
	}
	public void CreateGround()
	{
		Debug.Log("CreateGround called.");

        writer.WriteLine("{ \"obj\": \"Ground\" }");
        

        ground = (GameObject)Instantiate(Resources.Load("Prefabs/Ground"));
		ground.transform.localPosition = new Vector3(0.19f, -0.6f, -1.51f);
	}
	public void CreateBall()
	{
		Debug.Log("CreateBall called.");
		roll_btn.gameObject.SetActive(true);
		bounce_btn.gameObject.SetActive(true);

        writer.WriteLine("{ \"obj\": \"Ball\" }");

        ball = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"));
		ball.transform.localPosition = new Vector3(-5.76f, 0f, -2.5f);

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
