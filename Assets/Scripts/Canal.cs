using UnityEngine;
using System.Collections;

public class Canal : MonoBehaviour {

    public int resState_zidane, resState_scream, resState_oropeza, resState_gaviota, resState_pena, resState_cuchillo, resState_hamburguesa, resState_balon, resState_nieve;

    public SpriteRenderer state0, state1, state2, state3, state4, state5, state6, state7;

    private int state = 0;
    public int getState()
    {
        return state;
    }

    public void putDraggable(Draggable.ID obj)
    {
        Debug.Log("state: "+state);
        Debug.Log("obj: " + obj);
        if (state == 0)
        {
            switch (obj)
            {
                case Draggable.ID.zidane:
                    SetState(resState_zidane);
                    break;
                case Draggable.ID.scream:
                    SetState(resState_scream);
                    break;
                case Draggable.ID.oropeza:
                    SetState(resState_oropeza);
                    break;
                case Draggable.ID.gaviota:
                    SetState(resState_gaviota);
                    break;
                case Draggable.ID.pena:
                    SetState(resState_pena);
                    break;
                case Draggable.ID.cuchillo:
                    SetState(resState_cuchillo);
                    break;
                case Draggable.ID.hamburguesa:
                    SetState(resState_hamburguesa);
                    break;
                case Draggable.ID.balon:
                    SetState(resState_balon);
                    break;
                case Draggable.ID.nieve:
                    SetState(resState_nieve);
                    break;
            }
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Show()
    {
        SetState(state);
    }

    public void Hide()
    {
        SpriteRenderer[] arrend = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rend in arrend)
        {
            rend.enabled = false;
        }
        //SetState(state);
    }

    public void SetState(int newState)
    {
        Debug.Log("newState: " + newState);
        switch (state)
        {
            case 0: state0.enabled = false; break;
            case 1: state1.enabled = false; break;
            case 2: state2.enabled = false; break;
            case 3: state3.enabled = false; break;
            case 4: state4.enabled = false; break;
            case 5: state5.enabled = false; break;
            case 6: state6.enabled = false; break;
            case 7: state7.enabled = false; break;
        }
        state = newState;
        switch (state)
        {
            case 0: state0.enabled = true; break;
            case 1: state1.enabled = true; break;
            case 2: state2.enabled = true; break;
            case 3: state3.enabled = true; break;
            case 4: state4.enabled = true; break;
            case 5: state5.enabled = true; break;
            case 6: state6.enabled = true; break;
            case 7: state7.enabled = true; break;
        }
    }
}
