using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3; // el ideal


public class StarData2Game : MonoBehaviour
{
    public StarScriptableObject estrella;


    private void Start()
    {
        //transform.position = Vector3.zero;
        //transform.localScale = new Vector3(-0.01f, -0.01f, -0.01f);
        transform.localScale += new Vector3(1, 1, 1) * estrella.StarRadius;





        // -------------- Tipo de Estrella ---------------------
        // hacer un switch statement, para que con el tipo de estrella
        // se tome el material
        // M, K, G, F, A, B, O
        Renderer rend = GetComponent<Renderer>();
        switch (estrella.StarTypeColor)
        {
            case StarScriptableObject.StarType.M: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/M");
                break;
            case StarScriptableObject.StarType.K: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/K");
                break;
            case StarScriptableObject.StarType.G: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/G");
                break;
            case StarScriptableObject.StarType.F: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/F");
                break;
            case StarScriptableObject.StarType.A: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/A");
                break;
            case StarScriptableObject.StarType.B: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/B");
                break;
            case StarScriptableObject.StarType.O: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/O");
                break;
            case StarScriptableObject.StarType.WhiteDwarf: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/WhiteDwarf");
                break;
            case StarScriptableObject.StarType.BH: //estrella roja
                rend.material = Resources.Load<Material>("Materials/Stars Materials/BH");
                break;
            default:
                rend.material = Resources.Load<Material>("Materials/Stars Materials/BaseGlow");
                break;
        }
        // --------------___________________---------------------









        /*
        {
        // Codigo basura que no resultó, modifcar el color directamente
        // Unity al modificar materiales crea instancias, las isntancias 
        // no funcionan bien con shaders

        // toma el material aplicado sobre la estrella
        Material mymat = GetComponent<Renderer>().material;
        mymat.EnableKeyword("_EMISSION"); // se asegura de activar emisiones
        mymat.SetColor("_EmissionColor", estrella.StarColor ); //aqui lee data
        }
         */


    }

}
