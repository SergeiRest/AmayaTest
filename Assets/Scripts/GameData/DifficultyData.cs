using System;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Difficulty", menuName = "Data/Difficulty")]
    public class DifficultyData : ScriptableObject
    {
        [field: SerializeField] public Difficulty[] Difficulties { get; private set; }
    }

    [Serializable]
    public struct Difficulty
    {
        public int CellsCount;
    }
}