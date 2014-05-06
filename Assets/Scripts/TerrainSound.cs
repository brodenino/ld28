using UnityEngine;
using System.Collections;

public class TerrainSound : MonoBehaviour {
    public Transform hitEffect;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "collidablewall")
        {
            
            audio.Play();
            //GameObject effect = GameObject.Instantiate(hitEffect, transform.position, Quaternion.identity) as GameObject;
            //Destroy(effect, 1.0f);
        }
    }
}
