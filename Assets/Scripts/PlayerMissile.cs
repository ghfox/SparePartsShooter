using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{

    private GameObject target = null;
    private GameObject player;
    private Rigidbody rb;
    public float speed = 50f;
    public float maxRotation = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        FindTarget();
        Invoke("SelfDestruct", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If we have a target rotate towrds it, or try to find a new one
        if (target != null)
        {
            Vector3 targetVec = (target.transform.position - transform.position);
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.LookRotation(targetVec), maxRotation));
        }
        else
            FindTarget();
        rb.velocity = (rb.transform.forward * speed); 
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public void FindTarget()
    {
        GameObject [] goArr = GameObject.FindGameObjectsWithTag("Enemy");
        float dist = Mathf.Infinity;
        foreach(GameObject enem in goArr)
        {
            if (enem.transform.position.z > player.transform.position.z + 5)
            {
                float curDist = (enem.transform.position - transform.position).sqrMagnitude;
                if (curDist < dist)
                {
                    dist = curDist;
                    target = enem;
                }
            }
        }
    }
}
