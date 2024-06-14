# CursorExtensions
This project focuses on restoring the mouse pointer functionality when hovering over clickable events on a Windows machine.

It also contains custom pointer functionality for the other platforms, but this is largely incomplete and untested.

This implementation is not my own and largely came from https://vladislavantonyuk.github.io/articles/Setting-a-cursor-for-.NET-MAUI-VisualElement/

## Focus files
- **CursorBehaviour.cs** - This is the main file that contains the logic for setting the cursor on the different platforms.
- **PlatformCursorExtensions.cs** - These files are present in each of the supported platforms, and contain the platform-specific logic for setting the cursor.