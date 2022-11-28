using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Carta", menuName ="Nueva Carta")]
public class StarCardSO : ScriptableObject
{
    /*
     Las estrellas tienen la opción de poder leer sus cartas,
    son coleccionables que se consiguen al derrotar a X cantidad de enemigos
    con dada estrella o tipo de estrella

    por tanto hay cartas para cada fase
     */

    public string StarName; // randomly generated?
    public string Description; // se habla sobre la fase en la que esta

    public Sprite Arte;
}
