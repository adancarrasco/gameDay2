using UnityEngine;
using System.Collections;

public class MoveFly : MonoBehaviour {

    public SpriteRenderer flyLegs;

	// Use this for initialization
	void Start () {
        Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
        var pos = Input.mousePosition;
        pos.z = 1;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;

        if (Input.GetMouseButton(0))
        {
            flyLegs.enabled = false;
        }
        else
        {
            flyLegs.enabled = true;
        }
	}
}
