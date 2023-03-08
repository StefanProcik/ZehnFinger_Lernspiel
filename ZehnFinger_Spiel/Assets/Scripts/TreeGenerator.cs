using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject tree;

    private List<GameObject> trees = new List<GameObject>();

    public int treeAmount = 10;

    /// <summary>
    /// Creates and randomly places a set number of trees.
    /// </summary>
    /// <param name="vertices">The vertices of the mesh on which the trees shall be placed</param>
    /// <param name="meshSize">Size of the mesh</param>
    /// <param name="pathWidth">Width of the path on which no trees shall be placed</param>
    public void CreateTrees(Vector3[] vertices, int meshSize, int pathWidth, Transform terrainTransform) {

        for (int i = 0; i < treeAmount; i++) {

            Vector3 vert;
            if(i % 2 == 0) {
                int x = Random.Range(0, meshSize / 2 - pathWidth);
                int z = Random.Range(0, meshSize - 1);
                vert = vertices[z * (meshSize + 1) + x];
            } else {
                int x = Random.Range(meshSize / 2 + pathWidth, meshSize - 1);
                int z = Random.Range(0, meshSize - 1);
                vert = vertices[z * (meshSize + 1) + x];
            }

            trees.Add(Instantiate(tree, terrainTransform));

            trees.ElementAt(i).transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
            trees.ElementAt(i).transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            trees.ElementAt(i).transform.localPosition = vert;



        }
    }
}
