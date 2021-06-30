using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectKeys : MonoBehaviour
{
    private GameManager GM;
    private KeysPanel_UI KP_UI;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        KP_UI = FindObjectOfType<KeysPanel_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Personnage")
        {
            GM.nbKeys++;
            KP_UI.AddKeyUI();
            Destroy(gameObject);
        }
    }
}
