using UnityEngine;

[CreateAssetMenu(fileName = "CustomLogSettings", menuName = "CustomLog/Settings", order = 1)]
public class CustomLogScriptable : ScriptableObject
{
    [Header("General Settings")]
    [Tooltip("Toggle to enable or disable logging.")]
    public bool LogOn = true;

    [Header("Default Appearance")]
    [Tooltip("Select the default color for logs.")]
    public ColorCode DefaultColor = ColorCode.White;

    [Header("Advanced Options")]
    [Tooltip("If enabled, logs will also include a timestamp.")]
    public bool IncludeTimestamp = false;

    [Tooltip("If enabled, logs will show the caller's file and line number.")]
    public bool ShowCallerInfo = false;

    /// <summary>
    /// Returns whether logging is currently active.
    /// </summary>
    public string GetLogStatus()
    {
        return LogOn ? "Logging is currently ENABLED." : "Logging is currently DISABLED.";
    }
}
