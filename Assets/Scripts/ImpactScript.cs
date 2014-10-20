using UnityEngine;
using System.Collections;

public class ImpactScript : MonoBehaviour {

    public ParticleSystem effect;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.transform.gameObject);
 
        Vector3 eff1pos = new Vector3(this.transform.position.x, this.transform.position.y, 10);
        instantiate(effect, eff1pos);
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
}
