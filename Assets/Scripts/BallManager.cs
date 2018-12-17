using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	float value = 0.05f;
	float XValue;
	float YValue;
	public static int script_no = 0;
	bool collisionFlag = false;
	float ballheightupto;

	// Use this for initialization
	void Start () {
		ballheightupto = 5.0f;

	}
	
	// Update is called once per frame
	void Update () {

		if (script_no == 1)
		{
			XValue = this.transform.localPosition.x + value;
			this.transform.localPosition = new Vector3(XValue, 0, -2.5f);
		} else if (script_no == 2)
		{
			if (collisionFlag == false)
			{
				YValue = this.transform.localPosition.y - value;
				this.transform.localPosition = new Vector3(0f, YValue, 0);


			}
			else if (collisionFlag == true)
			{
				YValue = this.transform.localPosition.y + value;
				this.transform.localPosition = new Vector3(0f, YValue, 0);

				if (this.transform.localPosition.y >= ballheightupto)
				{
					collisionFlag = false;
				}
			}
		}

	}
	void OnCollisionEnter(Collision collision)
	{
		collisionFlag = true;
	}
}
