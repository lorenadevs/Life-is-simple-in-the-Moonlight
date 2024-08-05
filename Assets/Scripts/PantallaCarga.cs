using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaCarga : MonoBehaviour
{
    // Start is called before the first frame update

    public static string escenaACargar;
    void Start()
    {
        //string nivelACargar = LoadScene("Nivel1");

        StartCoroutine(LoadScene(escenaACargar));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadScene(string nivelACargar)
    {

        //Solo para que se vea la pantalla de carga un ratito, pero lo normal es no ponerle tiempo ya que el nivel de por sí lo requerirá
        yield return new WaitForSeconds(2);

        AsyncOperation operacion = SceneManager.LoadSceneAsync(nivelACargar);

        while (!operacion.isDone)
        {
            yield return null;
        }
    }
}
