using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    // Variables Publicas
    public GameObject[] hallways; 
    
    // Variables Privadas
    private int hallwayIndex = 0;

    //Funcion para activar nuevo pasillo
    public void LoadHallway()
    {
    //Aumentamos el index en 1
    hallwayIndex++; 

    //Activamos el siguiente pasillo
     if (hallwayIndex < (hallways.Length - 1))
        {
        hallways[hallwayIndex + 1].gameObject.SetActive(true);
        }
    }

    //Funcion para desactivar el pasillo anterior
    public void UnloadHallway()
    {
        //Llamamos a la corrutina
        StartCoroutine (UnloadHallwayCoroutine(1.5f));
    }

    //Corrutina para desactivar el pasillo
    IEnumerator UnloadHallwayCoroutine(float _time)
    {
        //Esperamos unos segundos
        yield return new WaitForSeconds(_time);

        //Desactivamos el pasillo anterior
        if (hallwayIndex > 0)
        {
            hallways[hallwayIndex - 1].gameObject.SetActive(false);
        }
    }
}
