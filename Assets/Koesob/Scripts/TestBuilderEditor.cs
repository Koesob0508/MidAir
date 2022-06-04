using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestBuilder))]
public class TestBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TestBuilder testBuilder = (TestBuilder)target;

        if(GUILayout.Button("Build Turret"))
        {
            testBuilder.BuildTurret(testBuilder.tileNumber);
        }

        if (GUILayout.Button("Build House"))
        {
            testBuilder.BuildHouse(testBuilder.tileNumber);
        }

        if (GUILayout.Button("Build Wall"))
        {
            testBuilder.BuildWall(testBuilder.tileNumber);
        }

        if (GUILayout.Button("Build Mast"))
        {
            testBuilder.BuildMast(testBuilder.tileNumber);
        }

        if(GUILayout.Button("Build Core"))
        {
            testBuilder.BuildCore(testBuilder.tileNumber);
        }
    }
}
