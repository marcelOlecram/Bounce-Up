using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
[CanEditMultipleObjects]
public class TransformEditor : Editor {
    Transform _transform;
    public override void OnInspectorGUI()
    {
        _transform = (Transform)target;
        //Recrear el anterior Inspector
        ShowDefaultTransform();
        // mostrar quaterniones
        ShowQuaternion();
        // mostrar espacio
        EditorGUILayout.Space();
        // mostrar coordenadas globales
        ShowGlobalCoordinates();
        // boton para resetear
        ShowResetButton();

    }

    private void ShowDefaultTransform()
    {
        EditorGUILayout.BeginHorizontal();
        //_transform.localPosition = EditorGUILayout.Vector3Field("Position", _transform.localPosition);
        _transform.localPosition = EditorGUILayout.Vector3Field(new GUIContent("Position","The local position of this Game Object relative to the parent."), _transform.localPosition);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();        
        _transform.localEulerAngles = EditorGUILayout.Vector3Field("Rotation", _transform.localEulerAngles);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        //_transform.localScale = EditorGUILayout.Vector3Field("Scale", _transform.localScale);
        _transform.localScale = EditorGUILayout.Vector3Field(new GUIContent("Scale","The local scaling of this Game Object relative to the parent."), _transform.localScale);
        EditorGUILayout.EndHorizontal();
    }

    private void ShowQuaternion()
    {
        EditorGUILayout.LabelField("Quaternion Rotation:    " + _transform.localRotation.ToString("F3"));
    }

    private void ShowGlobalCoordinates()
    {
        EditorGUILayout.LabelField("Global Coord", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        _transform.position = EditorGUILayout.Vector3Field("Global Position", _transform.position);
        EditorGUILayout.EndHorizontal();
        /*
        EditorGUILayout.BeginHorizontal();
        _transform.eulerAngles = EditorGUILayout.Vector3Field("Global Rotation", _transform.eulerAngles);
        EditorGUILayout.EndHorizontal();
        */
    }

    private void ShowResetButton()
    {
        float buttonWidth = 125f;
        float buttonHeigth = 60f;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        //if (GUILayout.Button("Reset Transform",GUILayout.Width(buttonWidth),GUILayout.Height(buttonHeigth)))
        if (GUILayout.Button(new GUIContent("Reset Transform","Resets Position, Rotation and Scale"),GUILayout.Width(buttonWidth),GUILayout.Height(buttonHeigth)))
        {
            _transform.position = Vector3.zero;
            //_transform.localPosition = Vector3.zero;
            _transform.eulerAngles = Vector3.zero;
            _transform.localScale = Vector3.one;
        }
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        if (GUILayout.Button("Reset Position", GUILayout.Width(buttonWidth)))
        {
            _transform.position = Vector3.zero;
        }
        if (GUILayout.Button("Reset Rotation", GUILayout.Width(buttonWidth)))
        {
            _transform.eulerAngles = Vector3.zero;            
        }
        if (GUILayout.Button("Reset Scale", GUILayout.Width(buttonWidth)))
        {
            _transform.localScale = Vector3.one;
        }
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}
