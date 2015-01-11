using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

    public enum ID { zidane, scream, oropeza, gaviota, pena, cuchillo, hamburguesa, balon };
    public TeleManager TV;

    public MoveFly theFly;
    public Canal currentChannel;
    public int currentState;

    public ID objectType;

    public bool isDragged;

    private bool used; //Para cuando ya se usó el objeto y no se quiere que se pueda draggear u ocultar de nuevo

	private AudioClip pickAudio;

	// Use this for initialization
	void Start () {
        TV.draggables[TV.index] = this;
        TV.index++;
	}

    bool mouseOn;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            mouseOn = true;
			transform.localScale = new Vector3 (1.1f, 1.1f, 1.0f);
			//pickAudio = other.audio;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
			mouseOn = false;
			transform.localScale = new Vector3 (1, 1, 1);
        }
    }

    bool buttonPressed;
	// Update is called once per frame
	void Update () {
		/*
		if (mouseOn) {
			transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
		} else {
			transform.localScale = new Vector3 (1, 1, 1);
		}
		*/

		if (this.GetComponent<SpriteRenderer>().enabled && mouseOn
            && ((theFly.draggingObject != null) && theFly.draggingObject.Equals(this)))
        {
            if (Input.GetMouseButton(0))
            {
				if(!isDragged){
					theFly.audio.Play();
				}
				isDragged = true;
                var pos = Input.mousePosition;
                pos.z = 2f;
                pos = Camera.main.ScreenToWorldPoint(pos);
                transform.position = pos;
            }
            else
            {
                
            }
        }

        if (!Input.GetMouseButton(0) && isDragged)
        {
			//theFly.GetComponent("legs").audio.Play();
			//theFly.GetComponentInChildren<AudioClip>();
			TV.audio.Play();
            isDragged = false;
            Canal tvChannel = TV.getChannel();
            tvChannel.putDraggable(objectType);
            if (currentChannel != tvChannel)
            {
                Hide();
                currentChannel = tvChannel;
                currentState = tvChannel.getState();
                used = true;
                TV.searchToShow(currentChannel);
            }
        }
	}

    public void Show()
    {
        if (!used)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void Hide()
    {
        Debug.Log("used:"+used);
        Debug.Log("drag:" + isDragged);
        if (!isDragged) //&& (!used)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
