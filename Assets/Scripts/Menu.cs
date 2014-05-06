using UnityEngine;

public class Menu : MonoBehaviour {
    public GUIStyle style;
    public GUIStyle replayStyle;
    public GUIStyle exitStyle;

    public Vector2 buttonSize;
    public Vector2 buttonPercentPosition;

    public bool hasStarted = false;

    public Transform lastCheckpoint;
    public Transform ball;
    public Transform enadisaObjects;

    public bool HasStarted
    {
        get
        {
            return hasStarted;
        }
        set
        {
            var removeObj = enadisaObjects.gameObject;
            removeObj.SetActive(!value);
            transform.FindChild("BottomMenuText").gameObject.SetActive(!value);
            transform.FindChild("ThanksForPlaying").gameObject.SetActive(!value);
            hasStarted = value;
        }
    }

    void DisableWorld(string name)
    {
        var lvl = GameObject.Find(name);
        var colliders = lvl.transform.GetComponentsInChildren<Collider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
        var spawners = lvl.transform.GetComponentsInChildren<PillSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.enabled = false;
        }
    }

    // Use this for initialization
    void Awake () {
        DisableWorld("world1");
        DisableWorld("world2");
        DisableWorld("world3");
        ball.position = lastCheckpoint.position;
    }
    
    // Update is called once per frame
    void Update () {
    }

    void OnGUI()
    {


        if (!hasStarted)
        {
            style.fontStyle = FontStyle.Bold;
            Color oldNormal = style.normal.textColor;
            Color oldHover  = style.hover.textColor;
            style.normal.textColor = Color.black;
            style.hover.textColor = Color.black;


            GUI.Label(new Rect((int)Screen.width * buttonPercentPosition.x - buttonSize.x / 2,
                                        8,
                                        buttonSize.x,
                                        buttonSize.y),
                             "Start Game",
                             style);

            style.fontStyle = FontStyle.Normal;
            style.normal.textColor = oldNormal;
            style.hover.textColor = oldHover;
        }


        if (!hasStarted && GUI.Button(new Rect( (int) Screen.width * buttonPercentPosition.x - buttonSize.x/2, 
                                                8, 
                                                buttonSize.x, 
                                                buttonSize.y), 
                                     "Start Game", 
                                     style))
        {
            HasStarted = true;
            //audio.Play();
            transform.FindChild("ButtonPressSound").audio.Play();
        }
        if (GUI.Button(new Rect(8,
                                                8,
                                                64,
                                                64),
                                     "",
                                     exitStyle))
        {
            transform.FindChild("ButtonPressSound").audio.Play();
            Application.Quit();
        }
        if (hasStarted && GUI.Button(new Rect(8,
                                                80,
                                                64,
                                                64),
                                     "",
                                     replayStyle))
        {
            ball.position = lastCheckpoint.position;
            ball.rigidbody2D.velocity = Vector2.zero;
            transform.FindChild("ButtonPressSound").audio.Play();
        
            var spawners = lastCheckpoint.parent.GetComponentsInChildren<PillSpawner>();
            foreach (var spawner in spawners)
            {
                spawner.enabled = false;
                spawner.enabled = true;
            }
        }
    }
}
