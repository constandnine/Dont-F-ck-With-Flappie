 using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;
        DrawDefaultInspector();

       /* if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }*/

        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}
