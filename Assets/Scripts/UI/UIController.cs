using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject menuUI;

    [SerializeField] private GameObject game;

    private void Start()
    {
        SwitchUI("MenuUI");
    }

    public void SwitchUI(string ui)
    {
        switch(ui)
        {
            case "GameplayUI":
                gameplayUI.SetActive(true);
                gameoverUI.SetActive(false);
                menuUI.SetActive(false);
                game.SetActive(true);
                GameObject.Find("Block Spawner").GetComponent<BlockSpawner>().ResetSpawner();
                break;
            case "GameoverUI":
                gameplayUI.SetActive(false);
                gameoverUI.SetActive(true);
                menuUI.SetActive(false);
                GameObject.Find("Block Spawner").GetComponent<BlockSpawner>().ResetSpawner();
                game.SetActive(false);
                break;
            case "MenuUI":
                gameplayUI.SetActive(false);
                gameoverUI.SetActive(false);
                menuUI.SetActive(true);
                game.SetActive(false);
                break;
        }
    }
}
