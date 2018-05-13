using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinFootBallManager : MonoBehaviour {

    public static PinFootBallManager instance;
    public TextMeshProUGUI scoreTeamAField, scoreTeamBField;
    private int scoreTeamA, scoreTeamB = 0;


    private void Awake()
    {
        if (instance == null) //Se a variável estática estiver nula,
        {
            instance = this; //Atribui o OBJETO GameManager a variável estática.
            DontDestroyOnLoad(gameObject);//Define que o objeto não deve ser destruído nas cargas
        }else if (instance != this) //Se a variável for diferente de this, já foi criada antes
            Destroy(gameObject);//Destrói o objeto    
    }

    public void onGoal(GameObject target)
    {
        Debug.Log(target.name);
        if (target.tag == "TeamA")
            scoreTeamAField.text = (++scoreTeamA).ToString();
        else if (target.tag == "TeamB")
            scoreTeamBField.text = (++scoreTeamB).ToString();
    }
}
