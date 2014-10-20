using UnityEngine;
using System.Collections;

public class FlipScript : MonoBehaviour {

    private int timeLeft;
    private int timeRight;

    public int duration = 10;

    private double curX;

    public bool isFlipped = false;
    public bool goingLeft;
    public bool goingRight;
    
    public Sprite Left;
    public Sprite Right;

    public GameObject parent;

    // Use this for initialization
	void Start () {
        curX = transform.rotation.eulerAngles.z;
        timeLeft = 0;
        timeRight = 0;
	}
	
	// Update is called once per frame
	void Update () {
        curX = transform.rotation.eulerAngles.z;
        if (((curX > 270) || (curX < 90)) && name == "Head")
        {
            ++timeRight;
            goingLeft = false;
            goingRight = true;
            timeLeft = 0;
        }
        else if (((curX < 270) || (curX > 90)) && name == "Head")
        {
            ++timeLeft;
            goingLeft = true;
            goingRight = false;
            timeRight = 0;
        }
        else if (((!parent.gameObject.GetComponent<FlipScript>().isFlipped)))
        {
            ++timeRight;
            goingLeft = false;
            goingRight = true;
            timeLeft = 0;
        }
        else if (((parent.gameObject.GetComponent<FlipScript>().isFlipped)))
        {
            ++timeLeft;
            goingLeft = true;
            goingRight = false;
            timeRight = 0;
        }

        
       if (((timeLeft > duration) && goingLeft) || (name == "HindLeg" && GameObject.Find("Neck10").GetComponent<FlipScript>().isFlipped) || (name == "ForeLeg" && GameObject.Find("Neck4").GetComponent<FlipScript>().isFlipped))
        {
            isFlipped = true;
            GetComponent<SpriteRenderer>().sprite = Left;
            if (name == "ForeLeg")
            {
                Vector2 anch;
                anch = GetComponent<HingeJoint2D>().anchor;
                anch.y = -1;
                GetComponent<HingeJoint2D>().anchor = anch;
            }
            else if (name == "HindLeg")
            {
                Vector2 anch;
                anch = GetComponent<HingeJoint2D>().anchor;
                anch.y = (float)-1.3;
                GetComponent<HingeJoint2D>().anchor = anch;
            }
            
        }
        else if (((timeRight > duration) && goingRight) || (name == "HindLeg" && !GameObject.Find("Neck10").GetComponent<FlipScript>().isFlipped) || (name == "ForeLeg" && !GameObject.Find("Neck4").GetComponent<FlipScript>().isFlipped))
        {
            isFlipped = false;
            GetComponent<SpriteRenderer>().sprite = Right;
            if (name == "ForeLeg")
            {
                Vector2 anch;
                anch = GetComponent<HingeJoint2D>().anchor;
                anch.y = 1;
                GetComponent<HingeJoint2D>().anchor = anch;
            }
            else if (name == "HindLeg")
            {
                Vector2 anch;
                anch = GetComponent<HingeJoint2D>().anchor;
                anch.y = (float)1.3;
                GetComponent<HingeJoint2D>().anchor = anch;
            }
       }
       if (name == "rider")
       {
           if (isFlipped)
           {
               this.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2((float).4, (float)-.6);
               GameObject.Find("UpperArm").GetComponent<FlipScript>().isFlipped = true;
               GameObject.Find("Forearm").GetComponent<FlipScript>().isFlipped = true;
           }
           else
           {
               this.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2((float).4, (float).6);
               GameObject.Find("UpperArm").GetComponent<FlipScript>().isFlipped = false;
               GameObject.Find("Forearm").GetComponent<FlipScript>().isFlipped = false;

           }
       }
       if (name == "UpperArm")
       {
           if (isFlipped)
           {
               this.GetComponent<HingeJoint2D>().anchor = new Vector2((float)-.1, (float)-.18);
               this.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2((float)-.1, (float)-.5);
           }
           else
           {
               this.GetComponent<HingeJoint2D>().anchor = new Vector2((float)-.1, (float).18);
               this.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2((float)-.1, (float).5);
           }
       }
       if (name == "Forearm")
       {
           HingeJoint2D[] joints = this.GetComponents<HingeJoint2D>();
           if (isFlipped)
           {
               joints[0].anchor = new Vector2((float)-.3, (float)-.1);
               joints[0].connectedAnchor = new Vector2((float).27, (float).27);
               joints[1].anchor = new Vector2((float).3, (float).02);
               joints[1].connectedAnchor = new Vector2((float)0, (float)-.7);
           }
           else
           {
               joints[0].anchor = new Vector2((float)-.3, (float).1);
               joints[0].connectedAnchor = new Vector2((float).27, (float)-.27);
               joints[1].anchor = new Vector2((float).3, (float)-.02);
               joints[1].connectedAnchor = new Vector2((float)0, (float).7);
           }
       }
	}
}
