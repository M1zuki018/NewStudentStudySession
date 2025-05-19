using UnityEngine;

public class SampleScript_52 : MonoBehaviour
{
    [Header("パラメータ")]
    
    [SerializeField] private string _text = "text";
    
    #region テキスト表示のパラメータ
    
    [Header("テキストの表示")]
    
    [SerializeField, Range(1, 512)] private int _fontSize = 128;
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private TextAnchor _anchor = TextAnchor.MiddleCenter;

    #endregion
    private void OnGUI()
    { 
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
        }
}