using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (mainMenu.active == false) {
                mainMenu.SetActive(true);
            } else {
                mainMenu.SetActive(false);
            }
        }
    }

    public void ExitGame() {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void ResumeGame() {
        mainMenu.SetActive(false);
    }

    public void LoadMainScene() {
        SceneManager.LoadScene("StartingScreen");
    }
}
