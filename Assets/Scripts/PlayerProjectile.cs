using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 5;
    public float frontZbound = 25;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f,2.0f), 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > frontZbound)
            Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
      
    }
}
