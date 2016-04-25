using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed = 2;
    public float force = 300;
    public ScoreScript score;
    public GameObject explosion;
    public AudioClip explosionSound;
    public AudioClip jumpSound;
    public AudioClip metalSound;
    private AudioSource source;

    private Vector3 worldSize;
    private float half_szY;


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        //gameOver.enabled = false;

        worldSize = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f));
        half_szY = GetComponent<Renderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
            source.PlayOneShot(jumpSound, 1);
        }
        Vector2 dir = GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // see if the player goes off the screen, if so, stick them to the top
        Vector3 playerPosScreen = transform.position;
        if (playerPosScreen.y >= (worldSize.y - half_szY))
        {
            playerPosScreen.y = worldSize.y - half_szY;
            transform.position = playerPosScreen;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground") || coll.gameObject.CompareTag("Obstacle"))
        {
            source.PlayOneShot(explosionSound, 1);
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject, explosionSound.length);

            //if score.HighScore == True, pop-up high-score dialog and then game over, else just gameover
            score.HighScore();
            Handheld.Vibrate();

            //gameOver.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Gate"))
        {
            //play sound
            source.PlayOneShot(metalSound, 1);
            score.IncreaseScore(1);
        }
        if(coll.gameObject.CompareTag("PowerUp"))
        {
            source.PlayOneShot(metalSound, 1);
            score.IncreaseScore(1);
            Destroy(coll.gameObject);
        }
    }

}
