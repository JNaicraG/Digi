using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MenuConfiguraçao : MonoBehaviour
{
    public GameObject menuConfiguraçao, menuInicial;
    public AudioMixer audioMixer;
    public Configuraçao configuraçao;
    private bool dadosAlterados;
    public void Voltar()
    {
        if (dadosAlterados)
        {
            if (configuraçao.indexFonteTamanho < 0 || configuraçao.indexFonteTamanho>0)
                configuraçao.indexFonteTamanho = 1;
            if (configuraçao.volume < -80 || configuraçao.volume > 0)
                configuraçao.volume = 0;
            if (configuraçao.nomeJogador == null)
                configuraçao.nomeJogador = "Nome do Jogador";
            configuraçao.SalvarDados();
        }
        menuConfiguraçao.SetActive(false);
        menuInicial.SetActive(true);
    }

    public void SetAudio(float volume)
    {
        audioMixer.SetFloat("volume", volume); //deixa o audio conforme volume selecionado
        dadosAlterados = true;
        //config.volume = volume; //altera o volume guardado
        configuraçao.volume = volume;
    }
    public void SetFonteTamanho(int index)
    {
        configuraçao.indexFonteTamanho = index;
        dadosAlterados = true;
        configuraçao.AlterarFonteTamanhoInicio();
    }
    public void SetNomeJogador(string nome)
    {
        configuraçao.nomeJogador = nome;
        dadosAlterados = true;
    }


}
