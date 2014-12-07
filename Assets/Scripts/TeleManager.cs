using UnityEngine;
using System.Collections;

public class TeleManager : MonoBehaviour {

    public int index = 0;
    public Draggable[] draggables = new Draggable[8];
    public void searchToShow(Canal updatedChannel)
    {
        for (int i = 0; i < 8; i++)
        {
            Draggable d = draggables[i];
            Debug.Log(">>" + d.currentChannel.name + " - " + updatedChannel.name);
            Debug.Log(">>" + d.currentState + " - " + updatedChannel.getState());
            if ((d.currentChannel.name.Equals(updatedChannel.name)) && (d.currentState.Equals(updatedChannel.getState())))
            {
                Debug.Log("show:" + d.objectType);
                d.Show();
            }
            else
            {
                Debug.Log("hide:" + d.objectType);
                d.Hide();
            }
        }
    }


    private int currChannelIndex;
    private Canal currentChannel;

    public Canal canalDeportes, canalComida, canalTerror, canalPolitica, canalNovelas;

	// Use this for initialization
	void Start () {
        
	}

    bool start = true;

    bool wPressed, sPressed;
	// Update is called once per frame
	void Update () {
        if (start)
        {
            canalDeportes.Hide();
            canalNovelas.Hide();
            canalComida.Hide();
            canalPolitica.Hide();
            canalTerror.Hide();

            currChannelIndex = Random.Range(0, 5);
            setChannel(currChannelIndex);
            start = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if(!wPressed)
            {
                wPressed = true;
                channelUp();
            }
        }
        else
        {
            wPressed = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!sPressed)
            {
                sPressed = true;
                channelDown();
            }
        }
        else
        {
            sPressed = false;
        }
	}

    public void channelUp()
    {
        currChannelIndex++;
        if (currChannelIndex > 4)
            currChannelIndex = 0;
        setChannel(currChannelIndex);
    }

    public void channelDown()
    {
        currChannelIndex--;
        if (currChannelIndex < 0)
            currChannelIndex = 4;
        setChannel(currChannelIndex);
    }

    private void setChannel(int channelNum)
    {
        switch (channelNum)
        {
            case 0:
                currentChannel = canalDeportes;
                canalNovelas.Hide();
                canalComida.Hide();
                canalDeportes.Show();
                break;
            case 1:
                currentChannel = canalComida;
                canalDeportes.Hide();
                canalTerror.Hide();
                canalComida.Show();
                break;
            case 2:
                currentChannel = canalTerror;
                canalComida.Hide();
                canalPolitica.Hide();
                canalTerror.Show();
                break;
            case 3:
                currentChannel = canalPolitica;
                canalTerror.Hide();
                canalNovelas.Hide();
                canalPolitica.Show();
                break;
            case 4:
                currentChannel = canalNovelas;
                canalPolitica.Hide();
                canalDeportes.Hide();
                canalNovelas.Show();
                break;
        }
        searchToShow(currentChannel);
    }

    public Canal getChannel()
    {
        return currentChannel;
    }
}
