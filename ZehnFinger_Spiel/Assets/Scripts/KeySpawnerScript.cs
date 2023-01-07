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

    private static readonly List<string> words = new List<string> { "able", "bake", "cake", "dare", "fear", "gaze", "haze", "joke", "lake", "make" };

    private List<GameObject> instantiatedObjects = new List<GameObject>() { };

    private float xMin = -0.5f, xMax = 0.5f;

    private int index = -1;
    bool TimerFinished()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 2;
            index++;
            return true;
        }
        else
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
            TextMeshPro textMeshPro = keyPrefab.GetComponent<TextMeshPro>();
            textMeshPro.text = GetRandomWord();
            float x = Random.Range(-1f, 14f);
            float y = Random.Range(-5f, 4f);

            x = Mathf.Clamp(x, -1f, 14f);
            y = Mathf.Clamp(y, -5f, 4f);
            Vector3 spawnPosition = new Vector3(x, y, 20);
            GameObject obj = (Instantiate(keyPrefab, spawnPosition, keyPrefab.transform.rotation));
            instantiatedObjects.Add(obj);
        }
        if (Input.anyKeyDown && instantiatedObjects.Count > 0)
        {
            Debug.Log("if input");
            GameObject wordObject = instantiatedObjects[0];
            TextMeshPro word = wordObject.GetComponent<TextMeshPro>();
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key) && char.ToUpper((char)key) == char.ToUpper(word.text[0]))
                {
                    if (word.text.Length > 1)
                    {
                        word.text = word.text.Substring(1);
                    }
                    else
                    {
                        instantiatedObjects.RemoveAt(0);
                        Destroy(wordObject);
                    }
                }
            }
        }
    }

    string GetRandomWord()
    {
        int index = Random.Range(0, words.Count);
        return words[index];
    }
}
