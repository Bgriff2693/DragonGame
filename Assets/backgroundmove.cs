using UnityEngine;
using System.Collections;

public class backgroundmove : MonoBehaviour {
    public GameObject g;

	// Use this for initialization
	void Start () {
        g = GameObject.Find("Head");
        this.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
            this.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, this.transform.position.z);
        
	}
}
