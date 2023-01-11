using UnityEngine;

public class CreateCubeMesh : MonoBehaviour
{
    public int width;
    public int depth;
    public GameObject cube;


    void Start()
    {
        for (int x = 0; x < width; x++)
            for (int z = 0; z < depth; z++)
            {
                Vector3 initPos = new Vector3(gameObject.transform.position.x + x,
                                          Mathf.PerlinNoise((gameObject.transform.position.x + x) * 0.2f, (gameObject.transform.position.z + z) * 0.3f),
                                          gameObject.transform.position.z + z);
                GameObject landScape = Instantiate(cube, initPos,  Quaternion.identity, gameObject.transform);
                landScape.transform.position = initPos;
            }
    }    
}
