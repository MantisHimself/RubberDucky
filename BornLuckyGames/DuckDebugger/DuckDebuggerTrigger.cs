using System;
using UnityEditor;
using UnityEngine;

public class DuckDebuggerTrigger
{
    public static DuckDebuggerData ddd;
    private void Awake()
    {
        ddd = Resources.Load<DuckDebuggerData>("ddd");
        Menu.SetChecked("Window/Rubber Duck/Audio Toggle", ddd.audioToggle);
    }

    [MenuItem(itemName:"Window/Rubber Duck/Audio Toggle")]
    public static void ToggleAudio()
    {
        ddd = Resources.Load<DuckDebuggerData>("ddd");
        ddd.audioToggle = !ddd.audioToggle;
        Menu.SetChecked("Window/Rubber Duck/Audio Toggle", ddd.audioToggle);
    }
}
