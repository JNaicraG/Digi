using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Estado do Jogo", menuName ="ScriptableObjects/EstadoDoJogo")]
public class EstadoDoJogo : ScriptableObject
{
    public bool jogoPausado;
    public bool vitoria;
    public bool jogoAcabou;
    public bool continuarJogo;

}
