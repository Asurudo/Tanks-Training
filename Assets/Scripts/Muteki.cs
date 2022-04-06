using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muteki : MonoBehaviour
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
        if (collider.tag == "player")
        {
            GM.SendMessage("mutekifunc", SendMessageOptions.DontRequireReceiver);
            GameObject.Destroy(this.gameObject);
        }
    }
}
