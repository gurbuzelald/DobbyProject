using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _cameraObjects;
    private GameObject cameraObjects;

    public Camera cameraObject;


    public MeshRenderer[] meshRenderers;



    private void Start()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        for (int i = 0; i < _cameraObjects.Length; i++)
        {
            cameraObjects = Instantiate(_cameraObjects[i], gameObject.transform);
        }
        //cameraObject = cameraObjects.GetComponent<Camera>();
        cameraObject = GameObject.Find("MiniMapCamera(Clone)").GetComponent<Camera>();


        meshRenderers = FindObjectsOfType<MeshRenderer>();  
    }
    void Update()
    {
        meshRenderers = FindObjectsOfType<MeshRenderer>();

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cameraObject);
            if (GeometryUtility.TestPlanesAABB(planes, meshRenderers[i].bounds))    
            {
                meshRenderers[i].enabled = true;
            }
            else
            {
                if (meshRenderers[i].name != "Arrow")
                {
                    meshRenderers[i].enabled = false;
                }
            }
        }
    }
    
}

