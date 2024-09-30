using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (mesh)
        {
            if (Vector3.Distance(gameObject.transform.position,
           PlayerManager.GetInstance.gameObject.transform.position) > 10)
            {
                mesh.enabled = false;
            }
            else
            {
                mesh.enabled = true;
            }
        }       
    }
}
