using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneManager : MonoBehaviour
{
    [Header("Data")]
    public PlayerData cloneData;

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
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(gameObject.transform.position, _firstTarget.position));

        if (Vector3.Distance(gameObject.transform.position, _firstTarget.position) < 0.6f)
        {
            _isTouchFirst = false;
            _isTouchMain = true;
        }
        if (Vector3.Distance(gameObject.transform.position, _secondTarget.position) < 0.6f)
        {
            _isTouchFirst = false;
            _isTouchMain = false;

            cloneData.isDancing = true;
            cloneData.isCloneWalking = false;
            StartCoroutine(DelayLevelup());
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.FirstTarget.ToString()))
        {
            //gameObject.transform.eulerAngles = new Vector3(270, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
            //_isTouchFirst = false;
            //_isTouchMain = true;
        }
        if (other.CompareTag(SceneLoadController.Tags.MainTarget.ToString()))
        {
        }
    }
    IEnumerator DelayLevelup()
    {
        yield return new WaitForSeconds(5f);
        SceneLoadController.GetInstance.LoadMenuScene();

    }
}
