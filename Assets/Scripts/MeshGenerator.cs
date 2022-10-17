using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;


    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    
    void Update()
    {
        
    }

    void CreateShape() {
        vertices = new Vector3[(xSize+1) * (zSize+1)];

        for (int i=0, z=0; z<=xSize; z++) {
            for (int x=0; x<=xSize; x++) {
                vertices[i] = new Vector3(x,0,z);
            }    
        }
    }

    void UpdateMesh() {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos() {
        if (vertices==null) {return;}

        for (int i=0; i< vertices.Length; i++) {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}
