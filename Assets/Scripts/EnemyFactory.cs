using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private float _respawnIntervalSecond;
    [SerializeField] private GameObject _enemy;

    private List<Transform> _respawns = new List<Transform>();
    private float _currentTime = 0;

    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            _respawns.Add(transform.GetChild(i));
        }
    }

    private void Update()
    {
        if(_currentTime < _respawnIntervalSecond)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            Transform pointForCreateEnemy = _respawns[Random.Range(0, _respawns.Count)];
            Instantiate(_enemy, pointForCreateEnemy);
            _currentTime = 0;
        }
    }

}
