using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
           /* if (configuraçao.indexFonteTamanho < 0 || configuraçao.indexFonteTamanho>0)
                configuraçao.indexFonteTamanho = 1;
            if (configuraçao.volume < -80 || configuraçao.volume > 0)
                configuraçao.volume = 0;
            if (configuraçao.nomeJogador == null)
                configuraçao.nomeJogador = "Nome do Jogador";*/
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
        AlterarFonteTamanhoInicio();
    }
    public List<GameObject> menus = new List<GameObject>();
    public void AlterarFonteTamanhoInicio()
    {

        switch (configuraçao.indexFonteTamanho)
        {
            case 0:
                foreach (var n in menus)
                    n.transform.localScale = new Vector3(0.89f, 0.89f, 1f);
                //usar tamanho pequeno
                break;
            case 1:
                foreach (var n in menus)
                    n.transform.localScale = new Vector3(1f, 1f, 1f);
                //usar tamanho médio
                break;
            case 2:
                foreach (var n in menus)
                    n.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
                //usar tamanho grande
                break;
            default:
                Debug.LogError("Index de tamanho selecionado para fonte é inválido");
                break;
        }
    }
    public void SetNomeJogador(string nome)
    {
        configuraçao.nomeJogador = nome;
        dadosAlterados = true;
    }

    private Dropdown _dropDown;
    public Slider _slider;
    private InputField _inField;
    private void OnEnable()
    {
        _dropDown = config.GetComponent<Dropdown>();
        _inField = config.GetComponent<InputField>();
        _dropDown.value = configuraçao.indexFonteTamanho;
        _slider.value = configuraçao.volume;
        _inField.text = configuraçao.nomeJogador;
    }
    public GameObject config;
    private void Awake()
    {
        AlterarFonteTamanhoInicio();
        config.SetActive(false);
    }
    

}
