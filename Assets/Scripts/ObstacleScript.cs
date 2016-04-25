using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {

    public float speed = 0;
    public float switchTime = 2;
    public bool canMove = false;

	// Use this for initialization
	void Start () {
        if (canMove)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            InvokeRepeating("Switch", 0, switchTime);

        }
    }
	

    void Switch()
    {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }

}
