using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KeysPanel_UI : MonoBehaviour
{
    private List<GameObject> keys;
    // Start is called before the first frame update
    void Start()
    {
        keys = new List<GameObject>();
        keys.Add(transform.GetChild(0).gameObject);
        keys.Add(transform.GetChild(1).gameObject);
        keys.Add(transform.GetChild(2).gameObject);
    }

    private void Update()
    {
        ////~~~~~~~~~~~~~TEST~~~~~~~~~~~~
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    AddKeyUI();
        //}
    }

    public void AddKeyUI()
    {
        if(keys.Count > 0)
        {
            keys.First().SetActive(true);
            keys.RemoveAt(0);
        }
    }
}
