using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroBoy : MonoBehaviour {

    public GameObject astroPrefab;
    public GameObject[] astroCubes;
    public GameObject astroBoy;

    Transform pos;
    Mesh mesh;
    Vector3[] vertices;
    Rigidbody rb;

    bool createBPushed;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        Debug.Log(vertices.Length);
        rb = astroPrefab.GetComponent<Rigidbody>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.C) && createBPushed == false)
        {
            cubeCreation();
            
        }
        if (Input.GetKeyDown(KeyCode.D) && createBPushed == true)
        {
            destroyCube();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void cubeCreation()
    {
        for (int i = 0; i < vertices.Length; ++i)
        {

            Instantiate(rb, vertices[i].x*astroBoy.transform.position, Quaternion.identity);
            
        }
        createBPushed = true;
    }

    void destroyCube()
    {
        astroCubes = GameObject.FindGameObjectsWithTag("astroP");
        for(int i = 0; i < vertices.Length; ++i)
        {
            Destroy(astroCubes[i]);
        }

        createBPushed = false;
    }
}
