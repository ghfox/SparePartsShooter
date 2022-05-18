using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPlane : MonoBehaviour
{
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<MeshCollider>().bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= -size)
            transform.Translate(new Vector3(0,0,size*2.0f));
    }
}
