using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class QuizGameDataManager : MonoBehaviour
{
    private QuestionList loadedGameData;

    [SerializeField]
    protected string gameDataFileName;

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
            loadedGameData = JsonUtility.FromJson<QuestionList>(dataAsJson);
            for (int i = 0; i < loadedGameData.questions.Length; i++)
            {
                Debug.Log("Description " + loadedGameData.questions[i].description);
                for (int j = 0; j < loadedGameData.questions[i].answers.Length; j++)
                    Debug.Log("Answers " + loadedGameData.questions[i].answers[j]);

            }
        }else
            Debug.LogError("Cannot load game data!");
    }

    [System.Serializable]
    public class QuestionList
    {
        public QuizGameData[] questions;
    }

    [System.Serializable]
    public class QuizGameData
    {
        public string description;
        public string[] answers;
        public int correct;
        public string image;
    }
}
