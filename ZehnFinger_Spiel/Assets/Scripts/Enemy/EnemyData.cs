using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Erstellt einen Eintrag im "Create"-Tab zur einfachen Auswahl von "Enemy"
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public string word;
    public int originalWordLength;
    public int lifeTime;
}
