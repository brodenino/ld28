using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    public Transform target = null;
    public float force = 0.0f;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "movable") && target)
        {
            other.transform.position = target.position;
            other.attachedRigidbody.velocity = Vector2.zero;// Vector2(other.transform.up.x, other.transform.up.z) * force;//Vector2.zero;
            other.attachedRigidbody.AddForce( new Vector2(target.transform.up.x, target.transform.up.y) * force );
            audio.Play();
        }
    }
}
