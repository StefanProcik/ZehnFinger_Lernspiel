using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{

    public GameObject terrainGeneratorPrefab;

    public int terrainCount = 1;

    // Start is called before the first frame update
    void Start() {

        for(int i = 0; i < terrainCount; i++) {
            Instantiate(terrainGeneratorPrefab, new Vector3(0, 0, 100 * i), Quaternion.identity);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
