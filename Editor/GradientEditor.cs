
namespace UnityEditor.UI
{
    using UnityEngine;
    using UnityEditor;
    using Gradient = UnityEngine.UI.Gradient;

    [CustomEditor(typeof(Gradient))]
    public class GradientEditor : Editor
    {
        [MenuItem("GameObject/UI/Gradient")]
        private static void CreateGradient(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/Create Empty");
            var gameObject = Selection.activeGameObject;

            if (menuCommand.context is GameObject parent)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }

            gameObject.name = "Gradient";

            gameObject.AddComponent<Gradient>();

            Undo.RegisterCreatedObjectUndo(gameObject, "Create Gradient");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Color"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("colorB"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("direction"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Material"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_RaycastTarget"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_RaycastPadding"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Maskable"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
