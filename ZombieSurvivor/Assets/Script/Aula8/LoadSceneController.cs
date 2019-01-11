using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    //Parametros da interface
    //Nome da cena a ser carregada !!!DEVE ESTAR ADICIONADA NO BUILD SETTINGS!!!
    [SerializeField] private string mainSceneName;
    [Space]
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject loadbarBase;
    [SerializeField] private Image fillImage;
    [SerializeField] private Text percentageText;
    [Space]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Image loadingCircle;

    //Função executada quando pressionar o botão de loading
    public void LoadScene()
    {
        StartCoroutine(StartLoadScene());
    }

    private IEnumerator StartLoadScene()
    {
        //Desativa o botão de carregar o jogo e começa a carregar o jogo
        startGameButton.SetActive(false);
        loadbarBase.SetActive(true);
        fillImage.fillAmount = 0;
        percentageText.text = "0%";
        loadingCircle.gameObject.SetActive(true);
        float progress = 0;


        //Começa a carregar a cena
        var request = SceneManager.LoadSceneAsync(mainSceneName);
        //Chama corotina de dentro da corotina, mas sem esperar por ela
        StartCoroutine(RotateLoadingCircle());
        while(!request.isDone)
        {
            //Como o carregamento do unity é 90%, e os ultimos 10% é a ativação
            //Fazemos com que esses 90% variem de 0 a 100% dividindo pelo valor maximo 
            progress = request.progress / 0.9f;
            fillImage.fillAmount = progress;
            //Arredondamos para não mostrarmos numeros quebrados
            percentageText.text = Mathf.Round(progress) + "%";
            yield return new WaitForEndOfFrame();
        }

    }

    //Realiza o giro do circulo de loading
    private IEnumerator RotateLoadingCircle()
    {
        //Apesar de ser um loop infinito, a corotina é terminada pelo StartLoadScene quando a cena foi carregada
        while(true)
        {
            //Roda no eixo z (utiliza back para rotacionar no sentido horario)
            loadingCircle.transform.eulerAngles += Vector3.back * Time.deltaTime * rotationSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
}
