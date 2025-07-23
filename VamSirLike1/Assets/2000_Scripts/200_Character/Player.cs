using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerStatus Status;
    public int CurrentHp { get; private set; }

    public float HpRatio 
    { 
        get => (float)CurrentHp / Status.MaxHp; 
    }

    public bool isDead
    {
        get => CurrentHp <= 0;
    }

    

    private void Update()
    {
        PlayerMoveInput();

        AttackNearPlayerSquare();
    }

    private void PlayerMoveInput()
    {
        // Ű �Է�
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.position += (Vector3.up * Time.deltaTime) * Status.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.position += Vector3.down * Time.deltaTime * Status.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.position += Vector3.left * Time.deltaTime * Status.MoveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position += Vector3.right * Time.deltaTime * Status.MoveSpeed;
        }
    }
    public void Initialize()
    {
        Status.TempStatusInit();
        SetPosition(Vector3.zero);
    }
    public void SetPosition(Vector3 position)
    {
        transform.localPosition = position;
    }

    public void GetDamaged(int damage)
    {
        CurrentHp -= damage;

        if (isDead == true)
        {
            CurrentHp = 0;
            Log.Message(LogType.StatHp, $"{this.name} ���!");
        }
#if Log
        else
        {
            Log.Message(LogType.StatHp, $"{this.name} ���� ���� : ����ü��{CurrentHp}");
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
        Log.Message(LogType.StatHp, $"{this.name} ġ�� ���� : ���� ü��{CurrentHp}");
    }



    public void AttackNearPlayerSquare()
    {
        SkillAreaInfo skillAreaData = new SkillAreaInfo();
        skillAreaData.TargetPosition = transform.position;
        skillAreaData.Size = new Vector3(3, 3, 0);
        skillAreaData.Rotation = Vector3.zero;

        List<Enemy> targetEnemyList = GetEnemyInBox(skillAreaData);
        
        foreach (Enemy enemy in targetEnemyList)
        {
            enemy.GetDamaged(Status.Atk);
        }
    }

    private List<Enemy> GetEnemyInBox(SkillAreaInfo skillAreaInfo)
    {
        Vector3 targetPosition = skillAreaInfo.TargetPosition;
        Vector3 targetBoxSize = skillAreaInfo.Size;
        Collider2D[] results = new Collider2D[10];
        Quaternion searchRotation = Quaternion.Euler(skillAreaInfo.Rotation);

        results = Physics2D.OverlapBoxAll(targetPosition, targetBoxSize, 0f);

        List<Enemy> targetEnemyList = new List<Enemy>();
        foreach (var collider2D in results)
        {
            if (collider2D == null)
            {
                break;
            }

            Enemy targetEnemy = collider2D.GetComponent<Enemy>();
            if (targetEnemy == null)
            {
                continue;
            }

            targetEnemyList.Add(targetEnemy);
        }

        return targetEnemyList;
    }
}
