using UnityEditor;
 
[CustomEditor(typeof(PortalScript)), CanEditMultipleObjects]
public class PortalEditor : Editor
{
    public enum DisplayCategory
    {
        Gamemode, Speed, gravity
    }
    public DisplayCategory categoryToDisplay;
 
    bool FirstTime = true;
 
    public override void OnInspectorGUI()
    {
        if (FirstTime)
        {
            switch (serializedObject.FindProperty("State").intValue)
            {
                case 0:
                    categoryToDisplay = DisplayCategory.Speed;
                    break;
                case 1:
                    categoryToDisplay = DisplayCategory.Gamemode;
                    break;
                case 2:
                    categoryToDisplay = DisplayCategory.gravity;
                    break;
            }
        }
        else
            categoryToDisplay = (DisplayCategory)EditorGUILayout.EnumPopup("Display", categoryToDisplay);
 
        EditorGUILayout.Space();
 
        switch (categoryToDisplay)
        {
            case DisplayCategory.Gamemode:
                DisplayProperty("Gamemode", 1);
                break;
 
            case DisplayCategory.Speed:
                DisplayProperty("Speed", 2);
                break;
 
            case DisplayCategory.gravity:
                DisplayProperty("gravity", 0);
                break;
 
        }
 
        FirstTime = false;
 
        serializedObject.ApplyModifiedProperties();
    }
 
    void DisplayProperty(string property, int PropNumb)
    {
        try
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(property));
        }
        catch
        { }
        serializedObject.FindProperty("State").intValue = PropNumb;
    }
}