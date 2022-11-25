using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private NavMeshAgent _navmeshAgent;
    [SerializeField] Transform _targetObject;
    [SerializeField] float _cloneSpeed = 0.1f;
    [SerializeField] GameObject _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(_targetObject.position);
        gameObject.transform.Translate(0f, 0f, _cloneSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Bullet.ToString()))
        {
            if (_healthBar.transform.localScale.x < 0.125f)
            {
                Destroy(_healthBar);
                if (_healthBar != null)
                {
                    ScoreController.GetInstance.SetScore(20);
                }
                Destroy(gameObject, 2f);
            }
            else
            {
                _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
            }
        }
    }

}
