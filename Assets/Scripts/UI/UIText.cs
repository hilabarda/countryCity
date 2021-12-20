using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    [SerializeField]
    private GameObject [] gameObjectText;
    [SerializeField]
    private bool text = false;

    private void Start()
    {
        StartCoroutine(TextShow());
    }


    private IEnumerator TextShow()
    {
        gameObjectText[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gameObjectText[0].SetActive(false);

        gameObjectText[1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gameObjectText[1].SetActive(false);

        gameObjectText[2].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gameObjectText[2].SetActive(false);

        gameObjectText[3].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gameObjectText[3].SetActive(false);

        gameObjectText[4].SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //gameObjectText[4].SetActive(false);







    }

    
}
