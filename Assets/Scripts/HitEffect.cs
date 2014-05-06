using UnityEngine;
using System.Collections;

public class HitEffect : MonoBehaviour {
    public float hitFactor = 1;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        float hitVolume = Mathf.Clamp(coll.relativeVelocity.magnitude * hitFactor, 0, 1);
        audio.volume = hitVolume;
        audio.Play();
    }
}
