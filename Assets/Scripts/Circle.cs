using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    private CustomSlider slider;

    private void Start()
    {
        slider = transform.parent.GetComponent<CustomSlider>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            GameObject.Find("Block Spawner").GetComponent<BlockSpawner>().DestroyBlocks();
            GameObject.Find("Block Spawner").GetComponent<BlockSpawner>().StopInvokes();
            string score = GameObject.Find("SessionScore").GetComponent<SessionScore>().Score; 
            GameObject.Find("Canvas").GetComponent<UIController>().SwitchUI("GameoverUI");
            GameObject.Find("GameoverScore").GetComponent<Text>().text += " " + score;
            
        }
    }

    private void OnMouseDown()
    {
        slider.EnableMoving();
    }

    private void OnMouseUp()
    {
        slider.DisableMoving();
    }
}


