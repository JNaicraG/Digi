using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConfiguraçaoData
{
    public string nomeJogador;
    public float volume;
    public int indexFonteTamanho; //0 - pequeno, 1 - medio, 2 - grande

    public ConfiguraçaoData() { }
    public ConfiguraçaoData(string nome, float volume, int index)
    {
        this.nomeJogador = nome;
        this.volume = volume;
        this.indexFonteTamanho = index;
    }
}
