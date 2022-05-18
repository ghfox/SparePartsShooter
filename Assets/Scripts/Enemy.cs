using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    public GameObject explosion;
    private GameManager gameManager;
    private float maxFireRate;
   

    Vector3 shotOffset = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        maxFireRate = gameManager.maxFireRate;
        StartCoroutine(FireShot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            Explode();
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(collision.gameObject);
            gameManager.Hit();
            Explode();
        }
    }

    IEnumerator FireShot()
    {
        yield return new WaitForSeconds(Random.Range(2.5f, maxFireRate));
        while (!gameManager.gameOver)
        {
            Instantiate(projectile, transform.position + shotOffset, projectile.transform.rotation).
                GetComponent<Rigidbody>().AddTorque(Random.Range(-2.0f, 2.0f),
                Random.Range(-2.0f, 2.0f), 5, ForceMode.Impulse);
            yield return new WaitForSeconds(Random.Range(2.5f, maxFireRate));
        }
    }
}
