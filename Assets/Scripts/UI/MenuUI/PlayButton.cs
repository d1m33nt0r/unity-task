using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void Click()
    {
        GameObject.Find("Canvas").GetComponent<UIController>().SwitchUI("GameplayUI");
        GameObject.Find("SessionScore").GetComponent<SessionScore>().RestartScore();
        GameObject.Find("Block Spawner").GetComponent<BlockSpawner>().StartInvokes();
    }
}
