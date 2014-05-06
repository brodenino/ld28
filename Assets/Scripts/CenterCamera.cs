using UnityEngine;

class CenterCamera : MonoBehaviour
{
    public Transform ball = null;
    public Vector3 offset = Vector3.zero;
    public float horizontalSpeed = 0;
    public float directHorizontalSpeed = 5.0f;
    public float angleClamp = 0;

    public bool analogControl = false;

    void Start()
    {
        //var lvl = GameObject.Find("world2");
        //var colliders = lvl.transform.GetComponentsInChildren<Collider2D>();
        //foreach (var collider in colliders)
        //{
        //    collider.enabled = false;
        //}
    }

    void AnalogUpdate()
    {
        // Clamp to the range of [-1 .. 1]
        float x = Input.mousePosition.x / Screen.width * 2 - 1;
        x = Mathf.Clamp(x, -1.0f, 1.0f) * horizontalSpeed;

        transform.Rotate(transform.forward, -x * Time.deltaTime);
        var angles = transform.eulerAngles;
        if (angles.z >= angleClamp && angles.z <= 180)
        {
            angles.z = angleClamp;
        }
        else if (angles.z <= 360 - angleClamp && angles.z > 180)
        {
            angles.z = 360 - angleClamp;
        }
        transform.eulerAngles = angles;


    }

    void DirectUpdate()
    {
        // Clamp to the range of [-1 .. 1]
        float x = Input.mousePosition.x / Screen.width * 2 - 1;
        x = -Mathf.Clamp(x, -1.0f, 1.0f) * angleClamp;
        
        float a = transform.eulerAngles.z;
        if (a >= 360 - angleClamp)
            a -= 360;

        x = Mathf.Lerp(a, x, Time.deltaTime * directHorizontalSpeed);

        if (x >= angleClamp && x <= 180)
        {
            x = angleClamp;
        }
        else if (x <= 360 - angleClamp && x > 180)
        {
            x = 360 - angleClamp;
        }

        transform.eulerAngles = new UnityEngine.Vector3(transform.eulerAngles.x, transform.eulerAngles.y, x);
        /*var angles = transform.eulerAngles;
        if (angles.z >= angleClamp && angles.z <= 180)
        {
            angles.z = angleClamp;
        }
        else if (angles.z <= 360 - angleClamp && angles.z > 180)
        {
            angles.z = 360 - angleClamp;
        }
        transform.eulerAngles = angles;*/
    }

    void Update()
    {
        if (analogControl)
            AnalogUpdate();
        else
            DirectUpdate();

        transform.position = ball.position + offset;
        Physics2D.gravity = new Vector2(transform.up.x, transform.up.y) * -10.0f;
    }
}
