using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Block")
        {
            GameObject.Find("SessionScore").GetComponent<SessionScore>().AddOnePoint();
            Destroy(col.gameObject);
        }
    }
}
