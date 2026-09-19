
namespace UnityEditor.UI
{
    using UnityEngine;
    using UnityEditor;
    using ScrollingImage = UnityEngine.UI.ScrollingImage;

    [CustomEditor(typeof(ScrollingImage))]
    public class ScrollingImageEditor : Editor
    {
        [MenuItem("GameObject/UI/Scrolling Image")]
        private static void CreateGradient(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/Create Empty");
            var gameObject = Selection.activeGameObject;

            if (menuCommand.context is GameObject parent)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }

            gameObject.name = "Scrolling Image";
            
            gameObject.AddComponent<ScrollingImage>();

            Undo.RegisterCreatedObjectUndo(gameObject, "Create Scrolling Image");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var textureProperty = serializedObject.FindProperty("_texture");
            EditorGUILayout.PropertyField(textureProperty);
            var texture = textureProperty.objectReferenceValue;
            if (texture != null && ((Texture2D)texture).wrapMode != TextureWrapMode.Repeat)
            {
                EditorGUILayout.HelpBox("The assigned texture's wrap mode is not set to \"repeat\".", MessageType.Warning);
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Color"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Material"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_RaycastTarget"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_RaycastPadding"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Maskable"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("pixelsPerUnit"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("scrollSpeed"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
