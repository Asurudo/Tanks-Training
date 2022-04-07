using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    //»ñÈ¡Ö÷¿Ø
    private GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider collider)
    {
        if (this.gameObject == null)
            return;
        
        if (collider.tag == "player")
        {
            GM.SendMessage("freezefunc", SendMessageOptions.DontRequireReceiver);
            GameObject.Destroy(this.gameObject);
        }

    }
}
