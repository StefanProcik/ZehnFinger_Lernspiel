using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeySpawnerScript : MonoBehaviour
{
    public GameObject keyPrefab;

    private float timer = 2;

    private List<string> wordList = new List<string>(){ "fjf", "jff", "fff" };

    private int index = -1;
    bool TimerFinished()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 2;
            index++;
            return true;
        } else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerFinished())
        {
            Debug.Log(keyPrefab.GetComponents<MonoBehaviour>()[0]);
            Debug.Log(keyPrefab.GetComponents<MonoBehaviour>()[1]);

            Vector3 spawnPosition = new Vector3(0, 0, 20);
            Instantiate(keyPrefab, spawnPosition, keyPrefab.transform.rotation);
        }
    }
}
