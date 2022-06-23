using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Configuração", menuName = "ScriptableObjects/Configuração")]
public class Configuraçao : ScriptableObject
{
    public string nomeJogador = "Caju";
    public float volume = 50;
    public int indexFonteTamanho = 1; //0 - pequeno, 1 - medio, 2 - grande
    public AudioMixer audioMixer;


    public void SalvarDados()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "Configuracao.save";
        ConfiguraçaoData data = new ConfiguraçaoData(nomeJogador, volume, indexFonteTamanho);
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public void CarregarDados()
    {
        string path = Application.persistentDataPath + "Configuracao.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ConfiguraçaoData data = formatter.Deserialize(stream) as ConfiguraçaoData;
            stream.Close();

            nomeJogador = data.nomeJogador;
            volume = data.volume;
            indexFonteTamanho = data.indexFonteTamanho;
            AlterarFonteTamanhoInicio();
            audioMixer.SetFloat("volume", volume); //deixa o audio conforme volume selecionado

        } else
        {
            Debug.LogError("Caminho para carregar dados de Configuração não existem. Caminho: " + path);
        }
    }
    public void AlterarFonteTamanhoInicio()
    {
        switch (indexFonteTamanho)
        {
            case 0:
                //usar tamanho pequeno
                break;
            case 1:
                //usar tamanho médio
                break;
            case 2:
                //usar tamanho grande
                break;
            default:
                Debug.LogError("Index de tamanho selecionado para fonte é inválido");
                break;
        }
    
    }
    public void AlterarFonteTamanhoJogo()
    {
        switch (indexFonteTamanho)
        {
            case 0:
                //usar tamanho pequeno
                break;
            case 1:
                //usar tamanho médio
                break;
            case 2:
                //usar tamanho grande
                break;
            default:
                Debug.LogError("Index de tamanho selecionado para fonte é inválido");
                break;
        }
    }


}
