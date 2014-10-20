using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

    public GameObject child;

    void OnCollisionEnter2DChild(Collision2D coll)
    {
        coll.gameObject.GetComponent<ImpactScript>().OnCollisionEnter2D(coll);
        //child.GetComponent<CollisionForwarding>().OnCollisionEnter2D(coll);
    }
}
