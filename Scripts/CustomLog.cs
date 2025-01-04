using UnityEngine;
using System.Runtime.CompilerServices;

public static class CustomLog
{
    private static CustomLogScriptable _settings;

    // Scriptable Object'i yükle
    static CustomLog()
    {
        _settings = Resources.Load<CustomLogScriptable>("CustomLogSettings");
        if (_settings == null)
        {
            Debug.LogWarning("CustomLogSettings ScriptableObject not found in Resources!");
        }
    }

    /// <summary>
    /// Performs the logging operation
    /// </summary>
    /// <typeparam name="T">Type of the message</typeparam>
    /// <param name="msg">Message to be logged</param>
    /// <param name="color">Color code (optional)</param>
    /// <param name="isBold">Bold text</param>
    /// <param name="isItalic">Italic text</param>
    /// <param name="callerFilePath">File path of the calling script (automatically provided)</param>
    /// <param name="callerName">Name of the calling method (automatically provided)</param>
    public static void Log<T>(T msg, ColorCode? color = null, bool isBold = false, bool isItalic = false, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerName = "")
    {
        if (_settings == null || !_settings.LogOn)
            return;

        // Renk belirle (Gönderilen veya varsayılan renk)
        ColorCode finalColor = color ?? _settings.DefaultColor;
        string colorHex = ColorHelper.GetHex(finalColor);

        // Mesaj formatı
        string formattedMessage = $"<color={colorHex}>{msg}</color>";
        if (isBold)
            formattedMessage = $"<b>{formattedMessage}</b>";
        if (isItalic)
            formattedMessage = $"<i>{formattedMessage}</i>";

        // Zaman damgası ekle
        if (_settings.IncludeTimestamp)
        {
            string timestamp = $"<b>[{System.DateTime.Now:HH:mm:ss}]</b> ";
            formattedMessage = timestamp + formattedMessage;
        }

        // Çağıran bilgisi ekle
        if (_settings.ShowCallerInfo)
        {
            string callerInfo = $" <i>(Caller: {callerFilePath} {callerName})</i>";
            formattedMessage += callerInfo;
        }

        Debug.Log(formattedMessage);
    }
}

public enum ColorCode
{
    White,
    Red,
    Green,
    Blue,
    Yellow
}

public static class ColorHelper
{
    public static string GetHex(ColorCode colorCode)
    {
        return colorCode switch
        {
            ColorCode.White => "#FFFFFF",
            ColorCode.Red => "#FF0000",
            ColorCode.Green => "#00FF00",
            ColorCode.Blue => "#0000FF",
            ColorCode.Yellow => "#FFFF00",
            _ => "#FFFFFF" // Varsayılan renk
        };
    }
}
