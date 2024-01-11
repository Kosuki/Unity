using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIScript : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject endGameUI;

    public GameObject score;
    public GameObject lives;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject WallShield;

    private void Awake()
    {
        if (!Settings.newGame)
        {
            Camera.main.orthographicSize = 1f;
            menuUI.SetActive(false);
            StartGame();
        }
    }

    public void OnPlayClick()
    {
        menuUI.SetActive(false);
        Camera.main.DOOrthoSize(1f, 2f).onComplete = () => { StartGame(); };
    }

    public void GoToMenu()
    {
        gameManager.enabled = false;
        WallShield.SetActive(true);
        Camera.main.DOOrthoSize(2f, 2f).onComplete = () => { gameUI.SetActive(false);  };
    }

    private void StartGame()
    {

        gameManager.enabled = true;
        gameUI.SetActive(true);
        WallShield.SetActive(false);
    }



    //private void CameraShake()
    //{
    //    _collider.enabled = false;
    //    _camera.shakeMagnitude = 0.3f;
    //    _camera.desiredShakeDuration = 0.1f;
    //    _camera.TriggerShake();
    //    _camera.ResetSettings();
    //}
}
