using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSelecionarDificuldade : MonoBehaviour
{
    public Palavras palavras;
    public Pontuašao pontuašao;
    public GameObject menuDificuldade, menuInicial;
    public void Voltar()
    {
        menuDificuldade.SetActive(false);
        menuInicial.SetActive(true);
    }
    public void Facil()
    {
        palavras.CarregarPalavrasFaceis(); ;
        CarregarJogo();
    }
    public void Medio()
    {
        palavras.CarregarPalavrasMedias(); ;
        CarregarJogo();
    }
    public void Dificil()
    {
        palavras.CarregarPalavrasDificeis();
        CarregarJogo();
    }

    //Talvez usar isso se adicionar mais coisa pra comešar o jogo
    private void CarregarJogo()
    {
        pontuašao.ZerarPlacar();
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
