using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneLoad : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Transform ProxPosCamera;
    [SerializeField] Transform AntPosCamera;
    private bool _cenaFoiCarregada;
    private bool _entrou;
    private GameObject mainCam;

    private void Start()
    {
        mainCam = Camera.main.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_cenaFoiCarregada)
        {
            LoadScene(sceneName);
        }
        setCamera();
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        _cenaFoiCarregada = true;
    }
    void setCamera()
    {
        _entrou = !_entrou;

        if (!_entrou)
        {
            mainCam.transform.position = AntPosCamera.position;
        }
        else
        {
            mainCam.transform.position = ProxPosCamera.position;
        }
    }
}
