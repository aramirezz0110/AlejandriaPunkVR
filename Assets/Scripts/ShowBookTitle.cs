using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBookTitle : MonoBehaviour
{
    public GameObject bookTitleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        bookTitleCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        bookTitleCanvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        bookTitleCanvas.SetActive(false);
    }
}
