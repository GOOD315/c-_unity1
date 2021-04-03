using System;
using System.Collections;
using System.Collections.Generic;
using Code.Buffs;
using UnityEngine;

namespace Code.SaveData
{
    [Serializable]
    public sealed class SavedData
    {
        public string Name;
        public Vector3Serializable Position;
        public CurrentActiveTrapsList currentActiveTrapsList;
        public List<TrapBuff> playerBuffs;
        private BuffData _buffData;

        public SavedData()
        {
            _buffData = Reference.BuffData;
            currentActiveTrapsList = new CurrentActiveTrapsList();
        }

        public override string ToString() =>
            $"Name - {Name}, Pos - {Position} \ncurrent traps: \n{currentActiveTrapsList} \ncurrent buffs: \n{playerBuffs}";

        public void AddBuff(string name, string timer)
        {
            float _timer;

            if (float.TryParse(timer, out _timer))
            {
                foreach (TrapBuff buff in _buffData)
                {
                    if (name == buff.BuffType.ToString())
                    {
                        var thisBuff = buff;
                        thisBuff.Timer = _timer;
                    }
                }
            }
        }
    }

    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;

        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public override string ToString() => $"({X},{Y},{Z})";
    }
}