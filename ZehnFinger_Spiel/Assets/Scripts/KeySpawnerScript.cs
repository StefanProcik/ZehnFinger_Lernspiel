/*using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeySpawnerScript : MonoBehaviour
{
    public EnemyScript enemy;
    public ScoreScript scoreScript;

    private float timer = 2;

    private static readonly List<string> words = new List<string> { "able", "bake", "cake", "dare", "fear", "gaze", "haze", "joke", "lake", "make" };

    private List<EnemyScript> instantiatedObjects = new List<EnemyScript>() { };

    bool TimerFinished()
    {
        this.timer -= Time.deltaTime;

        if (timer <= 0)
        {
            this.timer = 2;
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
    *//*void Update()
    {
        if (TimerFinished() && this.instantiatedObjects.Count == 0)
        {
            //Instantiate(enemy);
            //this.instantiatedObjects.Add(enemy.Spawn(this.GetRandomWord()));
        }
        if (Input.anyKeyDown && this.instantiatedObjects.Count > 0)
        {
            int currentCharCount = this.instantiatedObjects[0].word.Count();
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    if (this.enemy.KeyInputTrigger(char.ToUpper((char)key)) == 0)
                    {
                        this.instantiatedObjects.RemoveAt(0);
                        Destroy(enemy);
                        this.scoreScript.AddScore(10);
                        break;
                    }
                }
            }
           // if (currentCharCount == this.instantiatedObjects[0].word.Count())
           // {
           //     this.scoreScript.SubtractScore(5);
           // }
        }
        
    }*//*

    string GetRandomWord()
    {
        int index = Random.Range(0, words.Count);
        return words[index];
    }
}
*/