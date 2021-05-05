using System.Collections.Generic;
using UnityEngine;

namespace Inreal
{
    [DefaultExecutionOrder(-100)]
    public class Interscenic : MonoBehaviour
    {
        static HashSet<string> loadedNames = new HashSet<string>();

        void Awake() {
            if (loadedNames.Contains(name)) {
                DestroyImmediate(gameObject);
                return;
            }
            loadedNames.Add(name);
            DontDestroyOnLoad(gameObject);
        }
    }
}
