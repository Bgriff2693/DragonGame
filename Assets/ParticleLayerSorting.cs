using UnityEngine;
using System.Collections;

public class ParticleLayerSorting : MonoBehaviour {

	// Use this for initialization
	void Start () {
        particleSystem.renderer.sortingLayerName = "Particles";
	}
	
}
