using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    public float speed;
    public float backZbound = -25;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver)
            return;
        transform.position += Vector3.forward * -speed * Time.deltaTime;
        if (transform.position.z < backZbound && !gameObject.CompareTag("Ground"))
            Destroy(gameObject);
    }
}
