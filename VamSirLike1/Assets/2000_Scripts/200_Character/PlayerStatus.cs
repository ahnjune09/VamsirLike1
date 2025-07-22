using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public Dictionary<HpReason, int> HpReasonDictionary = new Dictionary<HpReason, int>();
    private int mHp;
    public int Hp
    {
        get
        {
            mHp = 0;
            foreach (var hpValue in HpReasonDictionary)
            {
                mHp += hpValue.Value;
            }

            return mHp;
        }
    }

    public Dictionary<AtkReason, int> AtkReasonDictionary = new Dictionary<AtkReason, int>();
    private int mAtk;
    public int Atk
    {
        get
        {
            mAtk = 0;
            foreach (var atkValue in AtkReasonDictionary)
            {
                mAtk += atkValue.Value;
            }

            return mAtk;
        }
    }

    public Dictionary<MoveSpeedReason, int> MoveSpeedReasonDictionary = new Dictionary<MoveSpeedReason, int>();
    private int mMoveSpeed;
    public int MoveSpeed
    {
        get
        {
            mMoveSpeed = 0;
            foreach (var moveValue in MoveSpeedReasonDictionary)
            {
                mMoveSpeed += moveValue.Value;
            }

            return mMoveSpeed;
        }
    }
    public void AddHpReason(HpReason reason, int value)
    {
        if (HpReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            HpReasonDictionary[reason] = value;

        }

#if Log
        Log.Message(LogType.StatHp, $"Hp ��ġ ��ȭ {value}");
#endif
    }
    public void RemoveHpReason(HpReason reason)
    {
        if (HpReasonDictionary.Remove(reason) == false)
        {
            Log.Error(LogType.StatHp, $"�ش� {reason}�� �����ϴ�!");
        }
    }

    public void AddAtkReason(AtkReason reason, int value)
    {
        if (AtkReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            AtkReasonDictionary[reason] = value;
        }

#if Log
        Log.Message(LogType.StatAtk, $"���ݷ� ��ġ ��ȭ {value}");
#endif
    }
    public void RemoveAtkReason(AtkReason reason)
    {
        if (AtkReasonDictionary.Remove(reason) == false)
        {
            Log.Error(LogType.StatAtk, $"�ش� {reason}�� �����ϴ�!");
        }
    }

    public void AddMoveSpeedReason(MoveSpeedReason reason, int value)
    {
        if (MoveSpeedReasonDictionary.TryAdd(reason, value) == false)
        {
            // Dic�� �ִ� �Ϳ� �����ߴ� => �̹� �ش� Key ���� ����
            MoveSpeedReasonDictionary[reason] = value;
        }

#if Log
        Log.Message(LogType.StatMoveSpeed, $"�̵��ӵ� ��ġ ��ȭ {value}");
#endif
    }
    public void RemoveMoveSpeedReason(MoveSpeedReason reason)
    {
        if (MoveSpeedReasonDictionary.Remove(reason) == false)
        {
            Log.Error(LogType.StatMoveSpeed, $"�ش� {reason}�� �����ϴ�!");
        }
    }
}
