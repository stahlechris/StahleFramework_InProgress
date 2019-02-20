using UnityEditor;
using UnityEngine;

//Reads the Input Manager's Input Axes. Only works in the Editor;
public class ReadInputManager
{
    [MenuItem("Assets/ReadInputManager")]
    public static void DoRead()
    {
        ReadInputAxes();
    }

    public static void ReadInputAxes()
    {
        var inputMngr = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

        SerializedObject obj = new SerializedObject(inputMngr);

        SerializedProperty axisArray = obj.FindProperty("m_Axes");

        for(int i =0; i< axisArray.arraySize; i++)
        {
            var axis = axisArray.GetArrayElementAtIndex(i);
            var name = axis.FindPropertyRelative("m_Name").stringValue;
            var axisVal = axis.FindPropertyRelative("axis").intValue;
            var inputType = axis.FindPropertyRelative("type").intValue;
            /*
            Debug.Log(name);
            Debug.Log(axisVal);
            Debug.Log(inputType);
            */          
         }
    }
}
