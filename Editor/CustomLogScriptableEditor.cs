using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomLogScriptable))]
public class CustomLogScriptableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Scriptable Object referansı
        CustomLogScriptable settings = (CustomLogScriptable)target;

        GUILayout.Space(10);

        // Başlık
        EditorGUILayout.LabelField("Custom Log Settings", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("Manage your logging preferences. Use the options below to customize the behavior.", MessageType.Info);

        GUILayout.Space(10);

        // Log On Toggle
        settings.LogOn = EditorGUILayout.Toggle(new GUIContent("Enable Logging", "Toggle to enable or disable logging globally."), settings.LogOn);

        // Log On açıklama
        if (settings.LogOn)
        {
            EditorGUILayout.HelpBox("Logging is enabled. Messages will be displayed in the Unity Console.", MessageType.Info);
        }
        else
        {
            EditorGUILayout.HelpBox("Logging is disabled. No messages will appear in the Unity Console.", MessageType.Warning);
        }

        GUILayout.Space(10);

        // Varsayılan Renk
        settings.DefaultColor = (ColorCode)EditorGUILayout.EnumPopup(new GUIContent("Default Log Color", "Select the default color for log messages."), settings.DefaultColor);

        // Zaman damgası seçeneği
        settings.IncludeTimestamp = EditorGUILayout.Toggle(new GUIContent("Include Timestamp", "If enabled, logs will include a timestamp."), settings.IncludeTimestamp);

        // Çağıran dosya ve satır bilgisi
        settings.ShowCallerInfo = EditorGUILayout.Toggle(new GUIContent("Show Caller Info", "If enabled, logs will include file name and line number."), settings.ShowCallerInfo);

        GUILayout.Space(10);

        // Log Status
        EditorGUILayout.LabelField("Log Status:", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(settings.GetLogStatus(), MessageType.None);

        // Değişiklikleri kaydet
        if (GUI.changed)
        {
            EditorUtility.SetDirty(settings);
        }
    }
}
