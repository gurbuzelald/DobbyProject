using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneManager : MonoBehaviour
{
    [Header("Data")]
    public PlayerData cloneData;
    public PlayerData playerData;

    private NavMeshAgent _navmeshAgent;
    public GameObject _nameshSurface;
    [SerializeField] Transform _secondTarget;
    [SerializeField] Transform _firstTarget;
    [SerializeField] Transform _currentTarget;
    private bool _isTouchFirst;
    private bool _isTouchMain;
    // Start is called before the first frame update
    void Start()
    {
        _currentTarget.position = _firstTarget.position;
        cloneData.isDancing = false;
        _isTouchFirst = true;
        _isTouchMain = false;
        _navmeshAgent = GetComponent<NavMeshAgent>();
        _navmeshAgent.speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(gameObject.transform.position, _firstTarget.position));

        OnTarget();
        if (playerData.isTouchFinish)
        {
            _navmeshAgent.speed = 0;
            cloneData.isCloneDying = true;
            cloneData.isCloneWalking = false;
            PlayerManager.GetInstance.CreateParticle(PlayerManager.ParticleNames.Death, gameObject.transform);
            Destroy(gameObject, 3f);
        }
        else
        {
            _navmeshAgent.speed = 2;
        }
        //Debug.Log(Vector3.Distance(gameObject.transform.position, _firstTarget.position));
        if (_isTouchFirst)
        {
            _currentTarget.position = _firstTarget.position;
        }
        if (_isTouchMain)
        {
            _currentTarget.position = _secondTarget.position;

            _navmeshAgent.destination = new Vector3(_currentTarget.position.x, _currentTarget.position.y, _currentTarget.position.z);
        }
        _navmeshAgent.destination = _currentTarget.position;
    }
    void OnTarget()
    {
        if (Vector3.Distance(gameObject.transform.position, _firstTarget.position) < 0.6f)
        {
            _isTouchFirst = false;
            _isTouchMain = true;
        }
        if (Vector3.Distance(gameObject.transform.position, _secondTarget.position) < 0.6f)
        {
            _isTouchFirst = false;
            _isTouchMain = false;

            _navmeshAgent.speed = 0;

            cloneData.isDancing = true;
            cloneData.isCloneWalking = false;

            playerData.isPlayable = false;
            StartCoroutine(DelayLevelup());
        }
    }
    IEnumerator DelayLevelup()
    {
        yield return new WaitForSeconds(5f);
        SceneLoadController.GetInstance.LoadMenuScene();
    }
}
