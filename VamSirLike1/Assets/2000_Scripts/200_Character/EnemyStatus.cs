using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private Dictionary<HpReason, int> mHpReasonDictionary = new Dictionary<HpReason, int>();
    private int mMaxHp;
    public int MaxHp
    {
        get
        {
            mMaxHp = 0;
            foreach (var hpValue in mHpReasonDictionary)
            {
                mMaxHp += hpValue.Value;
            }

            return mMaxHp;
        }
    }
    private Dictionary<AtkReason, int> mAtkReasonDictionary = new Dictionary<AtkReason, int>();
    private int mAtk;
    public int Atk
    {
        get
        {
            mAtk = 0;
            foreach (var atkValue in mAtkReasonDictionary)
            {
                mAtk += atkValue.Value;
            }

            return mAtk;
        }
    }
    private Dictionary<MoveSpeedReason, int> mMoveSpeedReasonDictionary = new Dictionary<MoveSpeedReason, int>();
    private int mMoveSpeed;
    public int MoveSpeed
    {
        get
        {
            mMoveSpeed = 0;
            foreach (var MoveSpeedValue in mMoveSpeedReasonDictionary)
            {
                mMoveSpeed += MoveSpeedValue.Value;
            }

            return mMoveSpeed;
        }
    }
    public void AddHpReason(HpReason reason, int value)
    {
        if (mHpReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            mHpReasonDictionary[reason] = value;

        }

#if Log
        Log.Message(LogType.StatHp, $"MaxHp ��ġ ��ȭ {value}");
#endif
    }
    public void RemoveHpReason(HpReason reason)
    {
        if (mHpReasonDictionary.Remove(reason) == false)
        {
            Log.Error(LogType.StatHp, $"�ش� {reason}�� �����ϴ�!");
        }
    }

    public void AddAtkReason(AtkReason reason, int value)
    {
        if (mAtkReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            mAtkReasonDictionary[reason] = value;
        }

#if Log
        Log.Message(LogType.StatAtk, $"���ݷ� ��ġ ��ȭ {value}");
#endif
    }
    public void RemoveAtkReason(AtkReason reason)
    {
        if (mAtkReasonDictionary.Remove(reason) == false)
        {
            Log.Error(LogType.StatAtk, $"�ش� {reason}�� �����ϴ�!");
        }
    }

    public void AddMoveSpeedReason(MoveSpeedReason reason, int value)
    {
        if (mMoveSpeedReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            mMoveSpeedReasonDictionary[reason] = value;
        }

#if Log
        Log.Message(LogType.StatMoveSpeed, $"�̵��ӵ� ��ġ ��ȭ {value}");
#endif
    }
    public void RemoveMoveSpeedReason(MoveSpeedReason reason)
    {
        if (mMoveSpeedReasonDictionary.Remove(reason) == false)
        {
            Log.Error(LogType.StatMoveSpeed, $"�ش� {reason}�� �����ϴ�!");
        }
    }
    #region Editor
    public void TempStatusInit()
    {
        AddHpReason(HpReason.Level, 10);
        AddAtkReason(AtkReason.Level, 10);
        AddMoveSpeedReason(MoveSpeedReason.Level, 10);
    }
    #endregion
}
