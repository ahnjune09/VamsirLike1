using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<Enemy> EnemyPool = new List<Enemy>(); 
    public Enemy GetEnemy()
    {
        // 풀안에 사용할수 있는 객체가 있는가?
        // 반복문을 사용한다.
        /*for(int i = 0; i < EnemyPool.Count; i++)
        {
            if (EnemyPool[i].gameObject.activeSelf == false)
            {
                return EnemyPool[i];
            }
        }*/

        //Linq를 사용한다.
        Enemy targetEnemy = EnemyPool.FirstOrDefault(target => target.gameObject.activeSelf == false);
        if (targetEnemy != null)
        {
            return targetEnemy;
        }

        // 만약 없다면 풀에 추가하고 반환
        Enemy refEnemy = Manager.Data.RefEnemy;
        targetEnemy = Instantiate(refEnemy);

        EnemyPool.Add(targetEnemy);
        
        return targetEnemy;
    }
}
