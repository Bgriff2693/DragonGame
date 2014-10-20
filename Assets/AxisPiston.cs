using UnityEngine;
using System.Collections;

public class AxisPiston : MonoBehaviour {

    public int time = 100;
    public double minDist;
    public double maxDist;
    public double increment;

    private int tick;
    HingeJoint2D[] curJoints;
	
    void Start () {
        curJoints = this.GetComponents<HingeJoint2D>();
        tick = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.Find("Dragon").GetComponent<PlayerScript>().isFlying)
        {
            ++tick;
            //operations only on one hinge joint
            if (GameObject.Find("Head").GetComponent<FlipScript>().isFlipped)
            {
                if (Mathf.Abs(curJoints[2].anchor.x - curJoints[3].anchor.x) > minDist && increment < 0)
                {
                    Vector2 v;
                    v.x = curJoints[2].anchor.x + (float)((increment / 2) * tick);
                    v.y = curJoints[2].anchor.y;

                    curJoints[2].anchor = v;

                    v.x = curJoints[3].anchor.x - (float)((increment / 2) * tick);
                    v.y = curJoints[3].anchor.y;

                    curJoints[3].anchor = v;
                }/*
                else if (Mathf.Abs(curJoints[2].anchor.x - curJoints[3].anchor.x) < maxDist && increment > 0)
                {
                    Vector2 v;
                    v.x = curJoints[2].anchor.x + (float)((increment / 2) * tick);
                    v.y = curJoints[2].anchor.y;

                    curJoints[2].anchor = v;

                    v.x = curJoints[3].anchor.x - (float)((increment / 2) * tick);
                    v.y = curJoints[3].anchor.y;

                    curJoints[3].anchor = v;
                }*/
                else
                {
                    tick = 0;
                    increment = increment * -1; //reset clock, negate increment to move in other direction
                }
            }
            else
            {
                if (Mathf.Abs(curJoints[0].anchor.x - curJoints[1].anchor.x) > minDist && increment < 0)
                {
                    Vector2 v;
                    v.x = curJoints[0].anchor.x - (float)((increment / 2) * tick);
                    v.y = curJoints[0].anchor.y;

                    curJoints[0].anchor = v;

                    v.x = curJoints[1].anchor.x + (float)((increment / 2) * tick);
                    v.y = curJoints[1].anchor.y;

                    curJoints[1].anchor = v;
                }/*
                else if (Mathf.Abs(curJoints[0].anchor.x - curJoints[1].anchor.x) < maxDist && increment > 0)
                {
                    Vector2 v;
                    v.x = curJoints[0].anchor.x - (float)((increment / 2) * tick);
                    v.y = curJoints[0].anchor.y;

                    curJoints[0].anchor = v;

                    v.x = curJoints[1].anchor.x + (float)((increment / 2) * tick);
                    v.y = curJoints[1].anchor.y;

                    curJoints[1].anchor = v;
                }*/
                else
                {
                    tick = 0;
                    increment = increment * -1; //reset clock, negate increment to move in other direction
                }
            }
        }
	}

    void OnDisable()
    {
        Vector2 v;

        v.x = -(float)maxDist / 2;
        v.y = curJoints[0].anchor.y;
        curJoints[0].anchor = v;

        v.x = (float)maxDist / 2;
        v.y = curJoints[1].anchor.y;
        curJoints[1].anchor = v;

        v.x = (float)maxDist / 2;
        v.y = curJoints[1].anchor.y;
        curJoints[2].anchor = v;

        v.x = -(float)maxDist / 2;
        v.y = curJoints[3].anchor.y;
        curJoints[3].anchor = v;
    }
}
