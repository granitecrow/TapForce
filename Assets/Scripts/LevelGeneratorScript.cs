using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGeneratorScript : MonoBehaviour {

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public float heightMin;
    public float heightMax;

	// Use this for initialization
	void Start () {
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void Spawn()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x, Random.Range(heightMin, heightMax), transform.position.z), Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
