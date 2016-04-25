using UnityEngine;
using System.Collections;

public class BackgroundScrollScript : MonoBehaviour {

    private Vector3 backPosition;
    public float width;
    public float height;
    private float X;
    private float Y;

	// Use this for initialization
	void Start () {
	}

    void OnBecameInvisible()
    {
        //calculate current position
        backPosition = gameObject.transform.position;

        //calculate new position
        X = backPosition.x + width * 2;
        Y = backPosition.y + height * 2;

        //move to new position when invisible
        gameObject.transform.position = new Vector3(X, Y, 0f);
   }
}
