using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string word = "Empty";
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private EnemyData data;
    [SerializeField]
    private ScoreScript scoreScript;

    private GameObject player;
    private GameObject floatingWord;

    // Start is called before the first frame update
    void Start()
    {
        // Das GameObject wird nach 3 Sekunden zerstört
        Invoke("EnemyDefeated", 4f);
        damage = data.word.Length;
        word = data.word;

        player = GameObject.FindGameObjectWithTag("Player");
        floatingWord = GameObject.FindGameObjectWithTag("FloatingWord");
        floatingWord.GetComponent<TextMeshPro>().text = word; 
        Debug.Log(message: floatingWord.GetComponent<TextMeshPro>().text);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);

        if (Input.anyKeyDown)
        {
            KeyInputTrigger();
        }
    }
    public void KeyInputTrigger()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                if (this.word.Length > 0 && char.ToUpper(this.word[0]) == char.ToUpper((char)key))
                {
                    this.rightKeyPressed();
                    this.scoreScript.AddScore(1);
                    break;
                } else
                {
                    this.scoreScript.SubtractScore(1);
                }
                if (this.word.Length == 0)
                {
                    this.EnemyDefeated();
                }
            }
        }
    }

    public void EnemyDefeated()
    {
        this.scoreScript.AddScore(damage * 2);
        Destroy(gameObject);
    }

    private void rightKeyPressed()
    {
        this.word = this.word.Remove(0, 1);
        this.floatingWord.GetComponent<TextMeshPro>().text = this.word;
    }
}
