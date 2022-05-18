using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerProf_fb;
    public GameObject playerMissile;
    public GameObject explosion;
    public float vertForce = 5;
    public float horForce = 5;
    public float vertAxis;
    public float horAxis;
    public float xbound = 4;
    public bool hasMissile;

    private GameManager gameManager;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.gameOver || !gameManager.startedGame)
            return;
        transform.eulerAngles = new Vector3(playerRb.velocity.y * -10.0f, 0, playerRb.velocity.x * -10.0f);
        vertAxis = Input.GetAxis("Vertical");
        if(vertAxis != 0.0f)
        {
            playerRb.AddForce(Vector3.up * (-vertAxis * vertForce) * Time.deltaTime, ForceMode.Impulse);
        }

        horAxis = Input.GetAxis("Horizontal");
        //this makes the edge of the screen a softer boundary if a bit less precise.
        if( (horAxis < 0.0f && transform.position.x > -xbound ) ||
            (horAxis > 0.0f && transform.position.x < xbound))
        {
            playerRb.AddForce(Vector3.right * (horAxis * horForce) * Time.deltaTime, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!hasMissile)
                Instantiate(playerProf_fb, transform.position + new Vector3(0,-0.25f,1.5f), playerProf_fb.transform.rotation);
            else 
            {
                Instantiate(playerMissile, transform.position + new Vector3(0, -0.35f, 1.75f), playerMissile.transform.rotation);
                hasMissile = false;
            }
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") )
        {
            if (collision.GetContact(0).normal == Vector3.back)
            {
                Killed();
            }
        }
        else if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Killed();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Killed();
            Destroy(collision.gameObject);
        }

    }

    public void Killed()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        gameManager.EndGame();
        gameObject.SetActive(false);
    }

}
