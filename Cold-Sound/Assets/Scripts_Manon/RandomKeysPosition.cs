using UnityEngine;
using System.Collections.Generic;

public class RandomKeysPosition : MonoBehaviour
{
    [SerializeField] List<GameObject> keysPrefab = new List<GameObject>();
    List<GameObject> keysInstances = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i <= 2; i++)
        {
            ChoseLocation(i);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChoseLocation(int indexChild)
    {
        int index = Random.Range(0, 3);
        Vector3 pos = transform.GetChild(indexChild).GetChild(index).transform.position;

        keysInstances.Add(Instantiate(keysPrefab[indexChild], pos, Quaternion.identity));
        keysInstances[indexChild].transform.SetParent(transform.GetChild(indexChild).GetChild(1).transform);
        keysInstances[indexChild].name = "Key " + (indexChild + 1);
    }
}
