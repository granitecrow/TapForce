using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + 4, transform.position.y, transform.position.z);
        }
    }

}
