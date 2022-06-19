using System.Collections;
using System.Collections.Generic;
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

    //Menus
    public GameObject menuVitoria,menuGeral;

    private void Start()
    {
        ResetarEstadosDoJogo();
        controlarPalavras.CarregarPalavrasMedias();
    }

    private void Update()
    {
        VerificarBlocos();
        VerificarEstadoDoJogo();
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
