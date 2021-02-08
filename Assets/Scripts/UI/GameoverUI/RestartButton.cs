using UnityEngine.UI;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void Click()
    {
        GameObject.Find("GameoverScore").GetComponent<Text>().text = "Score";
        GameObject.Find("Canvas").GetComponent<UIController>().SwitchUI("GameplayUI");
        GameObject.Find("SessionScore").GetComponent<SessionScore>().RestartScore();
        GameObject.Find("Block Spawner").GetComponent<BlockSpawner>().StartInvokes();
    }
}
