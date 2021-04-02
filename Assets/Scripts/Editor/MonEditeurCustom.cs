using UnityEditor;
using UnityEngine;

public class MonEditeurCustom : EditorWindow {
    [MenuItem("Window/MonEditeur")]
    private static void Init() {
        MonEditeurCustom monEditeurCustom
            = GetWindow<MonEditeurCustom>("Mon Editeur");
        monEditeurCustom.Show();
    }
    
    private void OnGUI() {
        if (GUILayout.Button("Supprimer sauvegarde")) {
            SaveManager.DeleteSave();
        }
    }
}