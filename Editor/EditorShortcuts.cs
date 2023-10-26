using UnityEditor;
using UnityEngine;

namespace Kuroneko.UtilityDelivery.Editor
{
    public static class EditorShortcuts
    {
        [MenuItem("Shortcuts/Toggle Maximise Window %#&l")]
        public static void ToggleMaximiseWindow()
        {
            EditorWindow window = EditorWindow.focusedWindow;
            if (window == null)
                return;
            window.maximized = !window.maximized;
        }
    }
}
