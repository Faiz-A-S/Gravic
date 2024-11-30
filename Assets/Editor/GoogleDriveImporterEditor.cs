using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GoogleDriveImporter))]
public class GoogleDriveImporterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GoogleDriveImporter importer = (GoogleDriveImporter)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Import"))
        {
            importer.Import();
        }
    }
}
