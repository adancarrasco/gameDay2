using UnityEngine;
using System.Collections;

public class TeleManager : MonoBehaviour {

    private bool hotToPlayComplete = false;

    public int index = 0;
    public Draggable[] draggables = new Draggable[9];
    public void searchToShow(Canal updatedChannel)
    {
        for (int i = 0; i < 9; i++)
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

    public Canal canalDeportes, canalComida, canalTerror, canalPolitica, canalNovelas, canalHowToPlay1, canalHowToPlay2;

	// Use this for initialization
	void Start () {
        
	}

    bool start = true;

    bool wPressed, sPressed;
	// Update is called once per frame
	void Update () {
        if (start)
        {
            canalHowToPlay2.Hide();
            canalDeportes.Hide();
            canalNovelas.Hide();
            canalComida.Hide();
            canalPolitica.Hide();
            canalTerror.Hide();

            currChannelIndex = -2; // Random.Range(0, 5);
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
        if (hotToPlayComplete)
        {
            if (currChannelIndex > 4)
                currChannelIndex = 0;
        }
        else
        {
            if (currChannelIndex > -1)
                currChannelIndex = -2;
        }
        setChannel(currChannelIndex);
    }

    public void channelDown()
    {
        currChannelIndex--;
        if (hotToPlayComplete)
        {
            if (currChannelIndex < 0)
                currChannelIndex = 4;
        }
        else
        {
            if (currChannelIndex < -2)
                currChannelIndex = -1;
        }
        setChannel(currChannelIndex);
    }

    private void setChannel(int channelNum)
    {
        switch (channelNum)
        {
            case -2:
                currentChannel = canalHowToPlay1;
                canalHowToPlay2.Hide();
                canalHowToPlay1.Show();
                break;
            case -1:
                currentChannel = canalHowToPlay2;
                canalHowToPlay1.Hide();
                canalHowToPlay2.Show();
                break;
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
