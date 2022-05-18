using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public List<AudioClip> explosions;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource aud = GetComponent<AudioSource>();
        aud.PlayOneShot(explosions[Random.Range(0, explosions.Count)]);
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
