using System;
using UnityEngine;

namespace GameTarget
{
    public class Target
    {
        public event Action<string> OnTargetChanged;
        public event Action TargetCleared;
        public event Action OnTargetShown;

        
        public string Desciption { get; private set; }

        public void Set(string name)
        {
            Desciption = $"Find {name.Replace("(Clone)", "")}";
            OnTargetChanged?.Invoke(Desciption);
        }

        public void Clear()
            => TargetCleared?.Invoke();

        public void Show()
            => OnTargetShown?.Invoke();
    }
}