using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Database : MonoBehaviour
{
    public static Database Instance;

    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDatabase();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
    }

    public void SaveDatabase()
    {
        File.WriteAllText(
            Application.persistentDataPath + "/savefile.json",
            JsonUtility.ToJson(new SaveData
            {
                HighScore = HighScore
            })
        );
    }

    public void LoadDatabase()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));

            HighScore = data.HighScore;
        }
    }
}
