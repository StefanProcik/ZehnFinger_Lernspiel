using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    //Color[] colors;
    Vector2[] uvs;

    public int xSize = 100;
    public int zSize = 100;

    public int pathWidth = 25;

    public float noiseScale = 2.0f;
    public float noiseAmplifier = 0.3f;

    public Gradient gradient;

    float minTerrainHeight = float.MaxValue;
    float maxTerrainHeight = float.MinValue;

    public TreeGenerator treeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;

        CreateMesh();
        UpdateMesh();
    }

    void CreateMesh() {

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        uvs = new Vector2[vertices.Length];

        for(int z = 0, i = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {

                float widthAmplifier = (x - xSize / 2.0f) / (xSize / 2.0f);
                widthAmplifier = Mathf.Abs(widthAmplifier);

                float y = Mathf.PerlinNoise(x * noiseAmplifier,
                    z * noiseAmplifier) * noiseScale * widthAmplifier;

                vertices[i] = new Vector3(x, y, z);

                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);

                if(y > maxTerrainHeight) {
                    maxTerrainHeight = y;
                }

                if(y < minTerrainHeight) {
                    minTerrainHeight = y;
                }

                i++;
            }
        }

        treeSpawner.CreateTrees(vertices, xSize, pathWidth);

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        //colors = new Color[vertices.Length];

        /*for (int z = 0, i = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {

                //float height = Mathf.InverseLerp(minTerrainHeight,
                //    maxTerrainHeight, vertices[i].y);

                //colors[i] = gradient.Evaluate(height);
               
                if(x > (xSize / 2) - pathWidth && x < (xSize / 2) + pathWidth) {
                    colors[i] = new Color(0.7f, 0.5f, 0.2f);  
                } else {
                    colors[i] = new Color(0.1f, 0.8f, 0.0f);
                }   
                i++;
            }
        }*/

    }

    void UpdateMesh() {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.colors = colors;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
    }
}
