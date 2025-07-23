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

        // ������ ���̺��� �����ؼ� �ش� ������ �ɷ�ġ ���� �ʿ�
        Status.TempStatusInit();
        GetHeal(Status.MaxHp);
    }
    public void SetPositon(Vector3 position)
    {
        transform.localPosition = position;
    }
    #region Hp �۾�
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
            Log.Message(LogType.StatHp, $"{Name} ���� ���� ���� : ����ü��{CurrentHp}");
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
        Log.Message(LogType.StatHp, $"{this.name} ġ�� ����! : ����ü��{CurrentHp}");
    }
    #endregion

    private void Died()
    {
        CurrentHp = 0;
        gameObject.SetActive(false);
        Log.Message(LogType.StatHp, $"{Name} ���!");
    }

    public void SetName(string text)
    {
        Name = Type.ToString() + text;
    }


    #region ��� �޴� �Լ���

    #endregion


    #region �����

    #endregion
}


