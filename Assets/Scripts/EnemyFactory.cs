using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private float _respawnIntervalSecond;
    [SerializeField] private Enemy _enemy;

    private void Awake()
    {
        StartCoroutine(StartProduction(new WaitForSeconds(_respawnIntervalSecond)));
    }

    private IEnumerator StartProduction(WaitForSeconds seconds)
    {
        for(int i = 0; i < transform.childCount; i++)
        {        
            CreateEnemy(transform.GetChild(i));
            yield return seconds;
        }       
    }

    private void CreateEnemy(Transform pointForCreateEnemy)
    {        
        Vector3 enemyPosition = pointForCreateEnemy.position - transform.position;
        Instantiate(_enemy, enemyPosition, Quaternion.identity);
    }
}
