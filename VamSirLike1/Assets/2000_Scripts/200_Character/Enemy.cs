using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStatus Status;

    public Rigidbody2D rigidBody;
    public int CurrentHp { get; private set; }

    public float HpRatio
    {
        get => (float)CurrentHp / Status.MaxHp; 
    }

    public bool isDead
    {
        get => CurrentHp <= 0;
    }

    public string Name;

    public EnemyType Type;

    #region Unity Event

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Player player = Manager.Data.Player;
        if (player == null)
        {
            return;
        }
        Vector2 direction = (player.transform.position - transform.position).normalized;

        rigidBody.linearVelocity = direction * Status.MoveSpeed;
    }
    #endregion

    public void Initialize()
    {
        gameObject.SetActive(true);

        // 데이터 테이블을 참조해서 해당 몬스터의 능력치 세팅 필요
        Status.TempStatusInit();
        GetHeal(Status.MaxHp);
    }
    public void SetPositon(Vector3 position)
    {
        transform.localPosition = position;
    }
    #region Hp 작업
    public void GetDamaged(int damage)
    {
        CurrentHp -= damage;

        if (isDead == true)
        {
            Died();
        }
#if Log
        else
        {
            Log.Message(LogType.StatHp, $"{Name} 몬스터 공격 받음 : 남은체력{CurrentHp}");
        }
#endif
    }

    public void GetHeal(int amount)
    {
        CurrentHp += amount;

        if (CurrentHp > Status.MaxHp)
        {
            CurrentHp = Status.MaxHp;

        }
        Log.Message(LogType.StatHp, $"{this.name} 치유 받음! : 현재체력{CurrentHp}");
    }
    #endregion

    private void Died()
    {
        CurrentHp = 0;
        gameObject.SetActive(false);
        Log.Message(LogType.StatHp, $"{Name} 사망!");
    }

    public void SetName(string text)
    {
        Name = Type.ToString() + text;
    }


    #region 상속 받는 함수들

    #endregion


    #region 디버그

    #endregion
}


