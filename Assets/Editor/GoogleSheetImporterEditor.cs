using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GoogleSheetsImporter))]
public class GoogleSheetImporterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GoogleSheetsImporter importer = (GoogleSheetsImporter)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Import"))
        {
            importer.Import();
        }
    }
}
