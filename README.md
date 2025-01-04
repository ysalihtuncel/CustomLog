# Custom Log System

The Custom Log System for Unity allows you to log messages in the Unity console with enhanced formatting capabilities. You can control the log output color, make the text bold or italic, and enable/disable logging at runtime using a ScriptableObject. This system provides flexibility to easily manage how messages are displayed, especially useful for debugging and runtime logs.

## Features
- **Customizable Log Formatting:** You can change the text color, make it bold or italic.
- **ScriptableObject Configuration:** Logs can be turned on/off, and a default color can be set via a `ScriptableObject`.
- **Support for Different Message Types:** Accepts various types of messages (strings, ints, floats, etc.).
- **Timestamp & Caller Info:** Optionally include timestamps and method/caller information in the logs.

## Installation
1. Download the project or clone the repository.
2. Add the Custom Log Script to your Unity project.
3. Create a CustomLogSettings ScriptableObject by right-clicking in your project window and selecting `Create > CustomLogSettings`.
4. Configure the CustomLogSettings by setting the default log color and whether logging is enabled.

## CustomLogScriptable Configuration
![Scriptable Object Image](https://raw.githubusercontent.com/ysalihtuncel/CustomLog/Resources/cover-image.png)

The `CustomLogScriptable` is a `ScriptableObject` that holds the configuration for the *Custom Log System*. This object allows you to manage the log settings globally across your Unity project. The settings it contains determine the behavior of the logging system, including whether logs are shown, their appearance, and additional information like timestamps or caller info.

### General Settings
- **LogOn**:
    - **Description:** This boolean field controls whether logging is enabled or disabled throughout the application.
    - **Default Value:** `true` (Enabled)
    - **Usage:** Toggle this value to disable or enable the logging system. If set to `false`, no logs will be printed, regardless of other settings.

### Default Appearance
- **DefaultColor:**
    - **Description:** This field allows you to set the default color for log messages.
    - **Default Value:** `White`
    - **Usage:** You can choose the default color for your log messages from the available `ColorCode` enum (e.g., White, Red, Green, Blue, Yellow). If no color is specified when logging a message, this default color will be used.

### Advanced Options
- **IncludeTimestamp:**
    - **Description:** When enabled, this option adds a timestamp to every log message, indicating when the log was printed.
    - **Default Value:** `false`
    - **Usage:** Enable this option to include a timestamp in the logs. This is particularly useful for tracking events over time.
- **ShowCallerInfo:**
    - **Description:** This option, when enabled, adds the caller's file name and line number to the log messages. This can be useful for debugging, as it helps you trace where the log was triggered in the code.
    - **Default Value:** `false`
    - **Usage:** Enable this setting if you want the logs to include information about the calling method's file and line number. This will be shown in the Unity Console and can be helpful for tracking down errors or understanding the source of log messages.
## Example of Using the CustomLogScriptable
1. **Create the** `CustomLogScriptable` **Asset:**
To use the `CustomLogScriptable` in your project, right-click in your Project window, then navigate to `Create > CustomLog > Settings`. This will create a new asset where you can configure the log settings.

2. **Access and Modify the Settings:**
After creating the asset, you can configure the values for **LogOn**, **DefaultColor**, **IncludeTimestamp**, and **ShowCallerInfo** directly in the Unity Editor. The values you set in this asset will automatically be applied to the `CustomLog` system, affecting how logs are displayed.

## Usage
### Basic Logging
To log messages, use the `CustomLog.Log()` method, specifying the message and optional parameters such as color, bold, and italic formatting.

```
CustomLog.Log("This is a regular message.");
CustomLog.Log("This is an error message.", ColorCode.Red, true);
CustomLog.Log("This message is italicized.", null, false, true);
```
### Example with Dynamic Color
`CustomLog.Log("This message will be green.", ColorCode.Green);`

##
This README provides detailed instructions for setting up and using your custom logging system, including how to format logs, configure settings, and customize it for different purposes.


