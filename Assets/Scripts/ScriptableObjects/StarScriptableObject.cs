using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Estrella", menuName = "Nueva Estrella")]
public class StarScriptableObject : ScriptableObject
{
    /*
     un scriptable object es una blueprint de data
     */

    // componentes principales de jugabilidad
    public string StarName;
    public float StarRadius;
    public int SolarMass;
    public int HydrogenFuel;

    // utilziadas para estados especiales de la estrella
    public bool Gravity;
    public bool Expanding;
    public bool Contracting;

    // el color de la estrella y el tipo
    public Color StarColor = Color.white;

    public enum StarType 
    {
        // M, K, G, F, A, B, O classic stars
        // Black Hole -> BH
        M, K, G, F, A, B, O, WhiteDwarf, BH 
    }

    public StarType StarTypeColor; // se usa para elegir el material correcto





    //daño que hace al impactar contra enemigos, elevado con la masa
    public int PhysicalDamage;
    // daño que hacen sus ataques a distancia
    public int MagicDamage;

    // utilizando estos datos se consigue la velocidad de orbita
    public int OrbitRadius;
    public int OrbitPeriod;
    // velocidad en que gira sobre si misma
    public float AngularSpeed;



}
