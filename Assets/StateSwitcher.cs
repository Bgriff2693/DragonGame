using UnityEngine;
using System.Collections;

public class StateSwitcher : MonoBehaviour {
    public int state; //1 for player-control, 2 for scripted path/player-control

    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject DragonCamera;

    public bool collision;
	// Use this for initialization
	void Start () {
        state = 3;
        collision = false;
	}
	
	// Update is called once per frame
	void Update () {
        bool _switch = false;
        if(Input.GetKeyUp(KeyCode.Space)){
            if(state == 3) 
            {
                state = 1;
                _switch = true;
            }
            else if (state == 1)
            {
                state = 2;
                _switch = true;
            }
        }

        if (state == 1)//switching to path
        {
            if (_switch)
            {
                this.GetComponent<PlayerScript>().enabled = false;
                this.GetComponent<PathScript>().enabled = true;

                this.GetComponent<PathScript>().tether = GameObject.Find("PathNode1");
                
                //activating player, deactivating dragon
                DragonCamera.SetActive(false);
                Player.SetActive(true);

                Vector3 position = new Vector3(GameObject.Find("rider").transform.position.x, GameObject.Find("rider").transform.position.y, Player.transform.position.z);
                Player.transform.position = position;

                PlayerCamera.SetActive(true);
                Player.GetComponent<PositionMatching>().enabled = false;
                Player.GetComponent<GroundPlayerScript>().enabled = true;
                Player.GetComponent<GroundPlayerScript>().onGround = false;

                GameObject.Find("background").GetComponent<backgroundmove>().g = Player;
            }
        }
        else if (state == 2)//switching to player controlled, will trigger dragon to return, by following path to player
        {
            if (_switch)
            {
                this.GetComponent<PathScript>().tether = GameObject.Find("PlayerRoot");                
            }

            //when dragon hits player, player will board dragon
            if (GameObject.Find("Head").transform.position.x < Player.transform.position.x + .3 && GameObject.Find("Head").transform.position.x > Player.transform.position.x - .3 && GameObject.Find("Head").transform.position.y < Player.transform.position.y + .1 && GameObject.Find("Head").transform.position.y > Player.transform.position.y - .1)
            {
                this.GetComponent<PlayerScript>().enabled = true;
                this.GetComponent<PathScript>().enabled = false;

                //turning off player, activating dragon
                Player.GetComponent<GroundPlayerScript>().enabled = false;
                Player.GetComponent<PositionMatching>().enabled = true;
                PlayerCamera.SetActive(false);
                Player.SetActive(false);
                DragonCamera.SetActive(true);
                state = 3;
                collision = true;

                GameObject.Find("background").GetComponent<backgroundmove>().g = GameObject.Find("Head");

            }
        } _switch = false;
	}
}
