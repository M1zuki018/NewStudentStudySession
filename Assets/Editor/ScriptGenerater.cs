using UnityEditor;
using UnityEngine;
using System.IO;

public class ScriptGenerator : EditorWindow
{
    string _numberOfPeople  = "60";

    [MenuItem("Tools/Script Generator")]
    public static void ShowWindow()
    {
        GetWindow<ScriptGenerator>("Script Generator");
    }

    void OnGUI()
    {
        GUILayout.Label("MonoBehaviourスクリプトを作成できます", EditorStyles.boldLabel);
        _numberOfPeople= EditorGUILayout.TextField("何人分のスクリプトを作成しますか？", _numberOfPeople);
        if (GUILayout.Button("スクリプトを作成します"))
        {
            GenerateScript(_numberOfPeople);
        }
    }
    void GenerateScript(string numberOfPeople)
    {
        int count = int.Parse(numberOfPeople);
        for (int i = 0; i < count; i++)
        {
            string filename = "Number_" + (i + 1).ToString();
            string classname = "SampleScript_" + (i + 1).ToString();
            string folderPath = "Assets/Student/" + filename;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string scriptPath = Path.Combine(folderPath, classname + ".cs");
            if (File.Exists(scriptPath))
            {
                File.Delete(scriptPath);
            }
string classTemplate = 
$@"using UnityEngine;

/// <summary>
///     これはサンプルスクリプトの{i + 1}
/// </summary>
public class {classname} : MonoBehaviour
{{
    [Header(""パラメータ"")]
    
    [SerializeField] private string _text = ""text"";
    
    #region テキスト表示のパラメータ
    
    [Header(""テキストの表示"")]
    
    [SerializeField, Range(1, 512)] private int _fontSize = 128;
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private TextAnchor _anchor = TextAnchor.MiddleCenter;

    #endregion
    private void OnGUI()
    {{ 
            // フォントサイズなどのスタイルを設定
            GUIStyle style = new(GUI.skin.label);
            style.fontSize = _fontSize;
            style.normal.textColor = _color;
            style.alignment = _anchor;

            // 画面の中央に配置するRect
            Rect rect = new Rect(
                position: Vector2.zero,
                size: new Vector2(Screen.width, Screen.height)
            );

            // テキストを描画
            GUI.Label(rect, _text, style);
        }}
}}";
        File.WriteAllText(scriptPath, classTemplate);
        AssetDatabase.Refresh();
        }
    }
}