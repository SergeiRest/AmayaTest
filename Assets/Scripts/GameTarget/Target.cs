using System;
using UnityEngine;

namespace GameTarget
{
    public class Target
    {
        public event Action<string> OnTargetChanged;
        public string Desciption { get; private set; }
        
        public void Set(string name)
        {
            Desciption = $"Find {name.Replace("(Clone)", "")}";
            OnTargetChanged?.Invoke(Desciption);
        }
    }
}