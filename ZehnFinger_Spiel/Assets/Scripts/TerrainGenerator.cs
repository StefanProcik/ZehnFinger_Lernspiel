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

    Vector2[] uvs;

    public int xSize = 100;
    public int zSize = 100;

    public int pathWidth = 25;

    public float noiseScale = 2.0f;
    public float noiseAmplifier = 0.3f;

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

    public void CreateMesh() {

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        uvs = new Vector2[vertices.Length];

        for(int z = 0, i = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {

                float widthAmplifier = (x - xSize / 2.0f) / (xSize / 2.0f);
                widthAmplifier = Mathf.Abs(widthAmplifier);

                float lengthAmplifier = Mathf.Abs((z - zSize / 2.0f) / (zSize / 2.0f)) - 1.0f;

                float y = Mathf.PerlinNoise(x * noiseAmplifier,
                    z * noiseAmplifier) * noiseScale * widthAmplifier * lengthAmplifier;

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

        treeSpawner.CreateTrees(vertices, xSize, pathWidth, transform);

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

    }

    public void UpdateMesh() {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
    }
}
