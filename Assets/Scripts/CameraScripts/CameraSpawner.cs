using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _cameraObjects;
    private GameObject cameraObjects;

    public Camera camera;

    private GameObject trees;
    private MeshRenderer[] treesMesh;
    private MeshRenderer[] treesMesh1;

    private GameObject stones;
    private MeshRenderer[] stonesMesh;
    private MeshRenderer[] stonesMesh1;

    private GameObject grasses;
    private MeshRenderer[] grassesMesh;
    private MeshRenderer[] grassesMesh1;

    private GameObject grounds;
    private MeshRenderer groundMesh;
    private MeshRenderer groundMesh1;


    public MeshRenderer[] meshRenderers;


    private GameObject mapControllerObject;

    private void Start()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        for (int i = 0; i < _cameraObjects.Length; i++)
        {
            cameraObjects = Instantiate(_cameraObjects[i], gameObject.transform);
        }
        camera = cameraObjects.GetComponent<Camera>();


        meshRenderers = FindObjectsOfType<MeshRenderer>();  




        //ObjecFinder();
    }
    void Update()
    {

        
        if (trees && stones)
        {
            //TreeMeshState();
            //StoneMeshState();
            //GrassMeshState();
            //GroundMeshState();
        }
        meshRenderers = FindObjectsOfType<MeshRenderer>();

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
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
            if (Vector3.Distance(PlayerManager.GetInstance.gameObject.transform.position, meshRenderers[i].transform.position) > 3 && meshRenderers[i].tag != "Ground")
            {
                //meshRenderers[i].enabled = false;
            }
        }

    }
    void ObjecFinder()
    {
        trees = GameObject.Find("Trees");
        if (trees)
        {
            treesMesh = new MeshRenderer[trees.transform.GetChild(0).childCount];
            treesMesh1 = new MeshRenderer[trees.transform.GetChild(1).childCount];

            for (int i = 0; i < trees.transform.GetChild(0).childCount; i++)
            {
                treesMesh[i] = trees.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>();
            }
            for (int i = 0; i < trees.transform.GetChild(1).childCount; i++)
            {
                treesMesh1[i] = trees.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>();
            }

        }
        if (stones)
        {
            stones = GameObject.Find("Stones");
            stonesMesh = new MeshRenderer[stones.transform.GetChild(0).childCount];
            stonesMesh1 = new MeshRenderer[stones.transform.GetChild(1).childCount];

            for (int i = 0; i < stones.transform.GetChild(0).childCount; i++)
            {
                stonesMesh[i] = stones.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>();
            }
            for (int i = 0; i < stones.transform.GetChild(1).childCount; i++)
            {
                stonesMesh1[i] = stones.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>();
            }
        }

        if (grasses)
        {
            grasses = GameObject.Find("Grasses");
            grassesMesh = new MeshRenderer[grasses.transform.GetChild(0).childCount];
            grassesMesh1 = new MeshRenderer[grasses.transform.GetChild(1).childCount];

            for (int i = 0; i < grasses.transform.GetChild(0).childCount; i++)
            {
                grassesMesh[i] = grasses.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>();
            }
            for (int i = 0; i < grasses.transform.GetChild(1).childCount; i++)
            {
                grassesMesh1[i] = grasses.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>();
            }
        }


        if (grounds)
        {
            grounds = GameObject.Find("Grounds");

            groundMesh = grounds.transform.GetChild(0).GetComponent<MeshRenderer>();
            groundMesh1 = grounds.transform.GetChild(1).GetComponent<MeshRenderer>();

        }

    }
    void TreeMeshState()
    {
        if (camera)
        {
            for (int i = 0; i < trees.transform.GetChild(0).childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, treesMesh[i].bounds))
                {
                    treesMesh[i].enabled = true;
                }
                else
                {
                    treesMesh[i].enabled = false;
                }
            }

            for (int i = 0; i < trees.transform.GetChild(1).childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, treesMesh1[i].bounds))
                {
                    treesMesh1[i].enabled = true;
                }
                else
                {
                    treesMesh1[i].enabled = false;
                }
            }

        }
    }

    void StoneMeshState()
    {
        if (camera)
        {
            for (int i = 0; i < stones.transform.GetChild(0).childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, stonesMesh[i].bounds))
                {
                    stonesMesh[i].enabled = true;
                }
                else
                {
                    stonesMesh[i].enabled = false;
                }
            }

            for (int i = 0; i < stones.transform.GetChild(1).childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, stonesMesh1[i].bounds))
                {
                    stonesMesh1[i].enabled = true;
                }
                else
                {
                    stonesMesh1[i].enabled = false;
                }
            }

        }
    }

    void GrassMeshState()
    {
        if (camera)
        {
            for (int i = 0; i < grasses.transform.GetChild(0).childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, grassesMesh[i].bounds))
                {
                    grassesMesh[i].enabled = true;
                }
                else
                {
                    grassesMesh[i].enabled = false;
                }
            }

            for (int i = 0; i < grasses.transform.GetChild(1).childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, grassesMesh1[i].bounds))
                {
                    grassesMesh1[i].enabled = true;
                }
                else
                {
                    grassesMesh1[i].enabled = false;
                }
            }

        }
    }

    void GroundMeshState()
    {
        if (camera)
        {
            for (int i = 0; i < grounds.transform.childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, groundMesh.bounds))
                {
                    groundMesh.enabled = true;
                }
                else
                {
                    groundMesh.enabled = false;
                }
            }

            for (int i = 0; i < grounds.transform.childCount; i++)
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
                if (GeometryUtility.TestPlanesAABB(planes, groundMesh1.bounds))
                {
                    groundMesh1.enabled = true;
                }
                else
                {
                    groundMesh1.enabled = false;
                }
            }

        }
    }


}

