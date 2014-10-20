using UnityEngine;
using System.Collections;

//called so, only because it was originally for the ground, but is now used for most/all collisions involving the player.
public class LandingDetectionPlayer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        //aka, floor, any horizontal surface to stand on
        if (coll.gameObject.tag == "Ground")
        {
            this.gameObject.GetComponent<GroundPlayerScript>().jumping = false;
            this.gameObject.GetComponent<GroundPlayerScript>().landing = true;
            this.gameObject.GetComponent<GroundPlayerScript>().onGround = false;
        }
        if (coll.gameObject.tag== "Obstacle")//aka, any vertical thing to run into
        {
            if (this.gameObject.GetComponent<GroundPlayerScript>().goingRight)
            {
                this.gameObject.GetComponent<GroundPlayerScript>().collisionRight = true;
            }
            else if (this.gameObject.GetComponent<GroundPlayerScript>().goingLeft)
            {
                this.gameObject.GetComponent<GroundPlayerScript>().collisionLeft = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            this.gameObject.GetComponent<GroundPlayerScript>().jumping = true;
            this.gameObject.GetComponent<GroundPlayerScript>().landing = false;
            this.gameObject.GetComponent<GroundPlayerScript>().onGround = false;
        }
        if (coll.gameObject.tag == "Obstacle")
        {
                this.gameObject.GetComponent<GroundPlayerScript>().collisionRight = false;
                this.gameObject.GetComponent<GroundPlayerScript>().collisionLeft = false;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            this.gameObject.GetComponent<GroundPlayerScript>().jumping = false;
            this.gameObject.GetComponent<GroundPlayerScript>().landing = false;
            this.gameObject.GetComponent<GroundPlayerScript>().onGround = true;
        }
    }
}
