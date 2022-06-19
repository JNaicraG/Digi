using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ListaBlocosPeças",menuName ="ScriptableObjects/ListaBP")]
public class ListaBlocosPeças : ScriptableObject
{
    public List<GameObject> blocoResps = new List<GameObject>();
    public List<GameObject> peças = new List<GameObject>();

    public void LimparListas()
    {
        foreach (var n in blocoResps)
            Destroy(n);
        foreach (var n in peças)
            Destroy(n);
        blocoResps.Clear();
        peças.Clear();
    }
    public void LimparPeças()
    {
        foreach (var n in peças)
            Destroy(n);
        peças.Clear();
    }

    public void LimparBlocos()
    {
        foreach (var n in blocoResps)
            Destroy(n);
        blocoResps.Clear();
    }
}
