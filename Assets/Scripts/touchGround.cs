using UnityEngine;
using System.Collections;

public class touchGround : MonoBehaviour {

    private GameObject dragon;

    //dust kicking up
    public ParticleSystem effect;
    public ParticleSystem effect2;

	void Start () {
        dragon = GameObject.Find("Dragon");
        GameObject.Find("Dragon").GetComponent<PlayerScript>().isFlying = true;
	}

    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.gameObject.name == "Ground" && this.gameObject.name != "HindLeg")
        {
            GameObject.Find("Dragon").GetComponent<PlayerScript>().isFlying = false;

            Vector3 eff1pos = new Vector3(GameObject.Find("ForeLeg").transform.position.x + (float).5, GameObject.Find("ForeLeg").transform.position.y - (float) .5, 10);
            Vector3 eff2pos = new Vector3(GameObject.Find("ForeLeg").transform.position.x - (float).5, GameObject.Find("ForeLeg").transform.position.y - (float) .5, 10);

            instantiate(effect, eff1pos);
            instantiate(effect2, eff2pos);

            eff1pos = new Vector3(GameObject.Find("HindLeg").transform.position.x + (float) .5, GameObject.Find("ForeLeg").transform.position.y - (float) .5, 10);
            eff2pos = new Vector3(GameObject.Find("HindLeg").transform.position.x - (float) .5, GameObject.Find("ForeLeg").transform.position.y - (float) .5, 10);

            instantiate(effect, eff1pos);
            instantiate(effect2, eff2pos);
            

        }
        else
        {
            GameObject.Find("Dragon").GetComponent<PlayerScript>().isFlying = true;
        }
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }

    void Update()
    {
        dragon = GameObject.Find("Dragon");
        if (!dragon.GetComponent<PlayerScript>().isFlying)
        {
            this.GetComponent<HingeJoint2D>().useMotor = true;

        }
        else
        {
            this.rigidbody2D.fixedAngle = false;
            this.GetComponent<HingeJoint2D>().useMotor = false;

        }

    }
	
}
