using UnityEngine;
using System.Collections;

public class PillSpawner : MonoBehaviour {
    public float force = 0.0f;
    public float spawnInterval = 2.0f;
    public Transform typeToSpawn;
    public int maxSpawnCount = 10;

    float currentTime = 0.0f;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = spawnInterval;

            if (transform.GetChild(0).childCount < maxSpawnCount)
            {
                var spawnUnit = Instantiate(typeToSpawn, transform.position, Quaternion.identity) as Transform;
                spawnUnit.parent = transform.GetChild(0);
                audio.Play();
                spawnUnit.rigidbody2D.AddForce(new Vector2(transform.up.x, transform.up.y) * force);
            }
        }
    }

    void OnEnable()
    {
        var obj = new GameObject();
        obj.transform.parent = transform;
    }

    void OnDisable()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

}
