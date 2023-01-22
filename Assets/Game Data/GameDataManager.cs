// Add System.IO to work with files!
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private static GameDataManager _instance;
    public static GameDataManager Instance { get { return _instance; } }

    // Create a field for the save file.
    string saveFile;

    // Create a GameData field.
    public GameData gameData = new GameData();

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/gamedata.json";
        Debug.Log("save file is stored at " + saveFile);
        readFile();
    }

    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            Debug.Log("gameData set to " + fileContents);
            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            gameData = JsonUtility.FromJson<GameData>(fileContents);
        } else
        {
            Debug.Log("No save data was found, leaving Game Data object as default");
        }
    }

    public void saveGame()
    {
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData, true);
          

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Quitting");
        saveGame();
    }
}