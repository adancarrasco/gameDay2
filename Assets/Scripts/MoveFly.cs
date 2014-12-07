using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveFly : MonoBehaviour {

    public SpriteRenderer flyLegs;

	// Use this for initialization
	void Start () {
        Screen.showCursor = false;
	}

    bool onObject;
    public Draggable draggingObject, candidateDrag;
    //public List<Draggable> candidateDrag;
	
	// Update is called once per frame
	void Update () {
        var pos = Input.mousePosition;
        pos.z = 1;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;
        
        if (Input.GetMouseButton(0))
        {
            flyLegs.enabled = false;
            if (draggingObject == null) // && (candidateDrag.Count > 0))
            {
                draggingObject = candidateDrag;//[0];
                if (draggingObject != null) Debug.Log(draggingObject.name);
            }
        }
        else
        {
            flyLegs.enabled = true;
            draggingObject = null;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Draggable>().enabled)
        candidateDrag = other.GetComponent<Draggable>();
    }

    void OnTriggerExit(Collider other)
    {
        candidateDrag = null;//.Remove(other.GetComponent<Draggable>());
    }
}
