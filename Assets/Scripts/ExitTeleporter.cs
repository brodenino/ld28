using UnityEngine;
using System.Collections;

public class ExitTeleporter : MonoBehaviour {
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
        if (other.gameObject.tag == "movable")
        {
            Destroy(other.gameObject);
            if (transform.childCount > 0)
            {
                transform.GetChild(0).audio.Play();
            }

            return;
        }

        if (other.gameObject.tag == "Player" && target)
        {
            GameObject.Find("world0").GetComponent<Menu>().lastCheckpoint = target;

            other.transform.position = target.position;
            other.attachedRigidbody.velocity = Vector2.zero;// Vector2(other.transform.up.x, other.transform.up.z) * force;//Vector2.zero;
            other.attachedRigidbody.AddForce( new Vector2(target.transform.up.x, target.transform.up.y) * force );

            audio.Play();

            // Handle enabling and disabling of level collision
            var colliders = transform.parent.GetComponentsInChildren<Collider2D>();
            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }
            colliders = target.transform.parent.GetComponentsInChildren<Collider2D>();
            foreach (var collider in colliders)
            {
                collider.enabled = true;
            }
            if (target.parent.name == "world0")
            {
                target.parent.GetComponent<Menu>().HasStarted = false;
            }

            // Handle spawners
            var spawners = transform.parent.GetComponentsInChildren<PillSpawner>();
            foreach (var spawner in spawners)
            {
                spawner.enabled = false;
            }
            spawners = target.transform.parent.GetComponentsInChildren<PillSpawner>();
            foreach (var spawner in spawners)
            {
                spawner.enabled = true;
            }
            
        }
    }
}
