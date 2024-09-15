using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _cameraObjects;
    private GameObject cameraObjects;

    public Camera cameraObject;


    public MeshRenderer[] meshRenderers;

    [SerializeField] LevelData levelData;
    [SerializeField] PlayerData playerData;



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
        if (meshRenderers == null || meshRenderers.Length == 0) return; // Early exit if there are no mesh renderers

        // Calculate the camera frustum planes once per frame
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cameraObject);

        // Loop through all cached MeshRenderers
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            // Skip null entries to avoid errors
            if (meshRenderer == null) continue;

            // Check if the object's bounds intersect the camera frustum
            bool isVisible = GeometryUtility.TestPlanesAABB(planes, meshRenderer.bounds);

            // Directly skip objects that should always be visible
            if (meshRenderer.name == "Arrow" || meshRenderer.gameObject.name == "SM_Pistol_Trigger")
            {
                meshRenderer.enabled = true;
                continue;
            }

            // Enable/disable the MeshRenderer based on visibility
            meshRenderer.enabled = isVisible;
        }
    }

}

