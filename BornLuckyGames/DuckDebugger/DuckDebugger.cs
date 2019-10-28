using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class DuckDebugger : EditorWindow 
{
    [MenuItem ("Window/Rubber Duck/Rubber Duck Debugger")]

    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(DuckDebugger));
    }

    private Texture duck1;
    private Texture duck2;
    private Texture currentDuck;
    private AudioClip quack;
    private GameObject audiosource;
    private void OnEnable()
    {
        duck1 = Resources.Load<Texture>("duck1");
        duck2 = Resources.Load<Texture>("duck2");
        currentDuck = duck1;
        quack = Resources.Load<AudioClip>("quack");

        audiosource = new GameObject();
        audiosource.AddComponent<AudioSource>();
        audiosource.hideFlags = HideFlags.HideInInspector | HideFlags.HideAndDontSave;


    }

    void OnDisable()
    {
    //    EditorApplication.update -= Update;
    }
     
    void Update()
    {
        if (timeWhenNormal < (float)EditorApplication.timeSinceStartup)
        {
            currentDuck = duck1;
        }
        Repaint();

    }
    private float timeWhenNormal = 0;

    private void OnGUI () {
        
        var size = position.width;

        float offsetX = 0, offsetY = 0;
        if (size > position.height)
        {
            size = position.height;
            offsetX = position.width - size;
            offsetX /= 2;
        }
        else
        {
            size = position.width;
            offsetY = position.height - size;
            offsetY /= 2;
        }

        if (GUI.Button(new Rect(offsetX, offsetY, size, size), currentDuck))
        {
            currentDuck = duck2;
            timeWhenNormal = (float)EditorApplication.timeSinceStartup + 0.25f;
            if (Resources.Load<DuckDebuggerData>("ddd").audioToggle)
            {
                audiosource.GetComponent<AudioSource>().clip = quack;
                audiosource.GetComponent<AudioSource>().Play();
            }
        }
        

    }

}
