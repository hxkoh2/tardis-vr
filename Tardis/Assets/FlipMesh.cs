﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class FlipMesh : MonoBehaviour {

// Use this for initialization
void Start () {
    var mesh = (transform.GetComponent("MeshFilter") as MeshFilter).mesh;
    mesh.uv = mesh.uv.Select(o => new Vector2(1 - o.x, o.y)).ToArray();
    mesh.triangles = mesh.triangles.Reverse().ToArray();
    mesh.normals = mesh.normals.Select(o => -o).ToArray();
}
	
// Update is called once per frame
void Update () {
	    
}
}
