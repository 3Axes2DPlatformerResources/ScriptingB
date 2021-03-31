using System.IO;
using UnityEngine;

public static class SaveManager {
    public static SaveData LoadedSaveData { get; private set; }
    private static string savePath;

    static SaveManager() {
        savePath = $"{Application.persistentDataPath}/save.json";
    }

    public static void DoSave(string sceneName, int coins, int lives) {
        // Initialiser contenu sauvegarde
        SaveData saveData = new SaveData();
        saveData.sceneName = sceneName;
        saveData.numberOfCoins = coins;
        saveData.numberOfLives = lives;

        // Convertir objet en json
        string json = JsonUtility.ToJson(saveData);
        // json = "{"scene": "Niveau1","coins": 3,"lives": 3}"
        
        // Sauvegarder json dans un fichier
        File.WriteAllText(savePath, json);
    }

    public static void ReadSave() {
        if (File.Exists(savePath)) {
            // Lire json dans fichier
            string json = File.ReadAllText(savePath);

            // Convertir json en objet
            LoadedSaveData = JsonUtility.FromJson<SaveData>(json);
        }
    }

    public static void DeleteSave() {
        if (File.Exists(savePath))
            File.Delete(savePath);
    }
}