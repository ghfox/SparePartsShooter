using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float time = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestructor", 10f);
    }

    public void SelfDestructor()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
