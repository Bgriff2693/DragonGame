using UnityEngine;
using System.Collections;

public class CollisionForwarding : MonoBehaviour {

    public bool isHit = false;
	// Use this for initialization
	void Start () {
        isHit = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "shot")
        {
            isHit = true;

            coll.gameObject.GetComponent<ImpactScript>().OnCollisionEnter2D(coll);
        }
        if (coll.gameObject.name == "shotAnchor")
        {
            isHit = true;

            coll.gameObject.GetComponentInChildren<ImpactScript>().OnCollisionEnter2D(coll);
        }
    }

}
