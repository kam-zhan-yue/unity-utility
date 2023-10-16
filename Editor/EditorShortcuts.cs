using UnityEditor;
using UnityEngine;

namespace Kuroneko.EditorUtility.Editor
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
