using UnityEngine.UI;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void Click()
    {
        GameObject.Find("GameoverScore").GetComponent<Text>().text = "Score";
        GameObject.Find("Canvas").GetComponent<UIController>().SwitchUI("MenuUI");
    }
}
