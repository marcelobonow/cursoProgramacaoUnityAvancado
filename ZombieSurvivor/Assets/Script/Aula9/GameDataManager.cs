using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameDataManager : MonoBehaviour
{
    private GameData loadedGameData;

    private string gameDataFileName = "GameData.json";

    private void Start()
    {
        LoadGameData();
    }

    private void LoadGameData()
    {
        // Path.Combine monta o caminho do arquivo 
        // Application.StreamingAssets aponta para Assets/StreamingAssets no Editor, e StreamingAssets ao criar uma build
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            // Lê o json do arquivo para uma string
            string dataAsJson = File.ReadAllText(filePath);
            //Através da API JsonUtility Serializa o conteúdo String em um objeto do tipo GameData. 
            //Aqui, claramente, as estrutura precisam ser compatíveis
            loadedGameData = JsonUtility.FromJson<GameData>(dataAsJson);
            Debug.Log(loadedGameData.playerName);
            for (int i = 0; i < loadedGameData.ammo.Length; i++)
                Debug.Log(loadedGameData.ammo[i]);
        }
        else
             Debug.LogError("Cannot load game data!");
    }

    [System.Serializable]
    public class GameData
    {
        public int level;
        public float timeElapsed;
        public string playerName;
        public int[] ammo;
    }
}
