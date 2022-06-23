using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControladorJogo : MonoBehaviour
{
    //Singleton 
    //Favor ignorar
    private static ControladorJogo _instance;
    public static ControladorJogo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ControladorJogo)) as ControladorJogo;
                //Debug.LogError("ControladorJogo � Null / n�o existe");
            }
            return _instance;
        }
        private set { }
    }
    private void Awake()
    {
        // Deletar instancia desse script que nao seja ele mesmo (evitar duplicatas)
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //Começa aqui
    //Scriptables OBJ
    public Palavras controlarPalavras;
    public EstadoDoJogo estadoDoJogo;
    public ListaBlocosPeças listaBP;
    public Pontuaçao pontuaçao;

    //Menus
    public GameObject menuVitoria,menuGeral;


    private void Start()
    {
        ContarTempo();
        ResetarEstadosDoJogo();
        AlterarFonteTamanhoJogo();
        //controlarPalavras.CarregarPalavrasMedias();
    }
    private void Update()
    {
        VerificarBlocos();
        VerificarEstadoDoJogo();
    }
    public List<GameObject> menus = new List<GameObject>();
    public GameObject pausa;
    public Configuraçao configuraçao;
    public void AlterarFonteTamanhoJogo()
    {

        switch (configuraçao.indexFonteTamanho)
        {
            case 0:

                pausa.transform.localScale = new Vector3(0.79f, 0.79f, 1f);
                foreach (var n in menus)
                {
                    n.transform.localScale = new Vector3(0.89f, 0.89f, 1f);
                }//usar tamanho pequeno
                break;
            case 1:
                pausa.transform.localScale = new Vector3(0.89f, 0.89f, 1f);
                foreach (var n in menus)
                {
                    n.transform.localScale = new Vector3(1, 1f, 1f);
                }
                //usar tamanho médio
                break;
            case 2:
                pausa.transform.localScale = new Vector3(1f, 1f, 1f);
                foreach (var n in menus)
                {
                    n.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
                }
                //usar tamanho grande
                break;
            default:
                Debug.LogError("Index de tamanho selecionado para fonte é inválido");
                break;
        }
    }
    /*
    public void AcabarJogo()
    {
        if (estadoDoJogo.jogoAcabou)
        {
            ControladorJogo.Instance.ResetarEstadosDoJogo();
            pontuaçao.SalvarPontuaçao();
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }*/

    private void ContarTempo()
    {
        pontuaçao.t += Time.time;
        pontuaçao.tempo += Time.time;
    }

    private void VerificarEstadoDoJogo()
    {
        if (estadoDoJogo.continuarJogo)
            controlarPalavras.EscolherPalavra();
        
    }

    public void ResetarEstadosDoJogo()
    {
        estadoDoJogo.vitoria = false;
        estadoDoJogo.jogoPausado = false;
        estadoDoJogo.jogoPausado = false;
        estadoDoJogo.continuarJogo = false;
    }

    private void VerificarBlocos()
    {
        if (!estadoDoJogo.vitoria && !estadoDoJogo.continuarJogo) {
            int i = 0;
            foreach (var n in listaBP.blocoResps)
            {
                if (n.GetComponent<BlocoResposta>().blocoCorreto)
                    i++;
            }
            if (i == listaBP.blocoResps.Count)
            {
                estadoDoJogo.vitoria = true;
                menuGeral.SetActive(true);
                menuVitoria.SetActive(true);
                Debug.Log("Vitória");
            } 
        }
    }

}
