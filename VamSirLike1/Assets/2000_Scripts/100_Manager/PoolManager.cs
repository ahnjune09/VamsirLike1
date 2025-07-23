using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<Enemy> EnemyPool = new List<Enemy>(); 
    public Enemy GetEnemy()
    {
        // Ǯ�ȿ� ����Ҽ� �ִ� ��ü�� �ִ°�?
        // �ݺ����� ����Ѵ�.
        /*for(int i = 0; i < EnemyPool.Count; i++)
        {
            if (EnemyPool[i].gameObject.activeSelf == false)
            {
                return EnemyPool[i];
            }
        }*/

        //Linq�� ����Ѵ�.
        Enemy targetEnemy = EnemyPool.FirstOrDefault(target => target.gameObject.activeSelf == false);
        if (targetEnemy != null)
        {
            return targetEnemy;
        }

        // ���� ���ٸ� Ǯ�� �߰��ϰ� ��ȯ
        Enemy refEnemy = Manager.Data.RefEnemy;
        targetEnemy = Instantiate(refEnemy);

        EnemyPool.Add(targetEnemy);
        
        return targetEnemy;
    }
}
