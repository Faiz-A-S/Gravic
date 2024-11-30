using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CSVReader))]
public class CSVDataReaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CSVReader csvDataReader = (CSVReader)target;

        if (GUILayout.Button("Read CSV"))
        {
            csvDataReader.ReadCSV();
        }
    }
}