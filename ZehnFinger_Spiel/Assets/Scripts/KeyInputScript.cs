using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Destroy(gameObject);
        }

        Vector3 movement = (Vector3.back * Time.deltaTime);
        transform.Translate(movement);

    }
}
