using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public GameObject characterPanel;
    public GameObject weaponPanel;
    public GameObject mainMenu;

    private int selectedPlayerIndex = 0;
    private int selectedWeaponIndex = 0;

    public void PlayGame() {
        // Save selections to PlayerPrefs
        PlayerPrefs.SetInt("SelectedPlayer", selectedPlayerIndex);
        PlayerPrefs.SetInt("SelectedWeapon", selectedWeaponIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MainGameScene"); // Replace with your game scene 
    }

    public void ExitGame() {
        Application.Quit();
        Debug.Log("Game closed."); // This only shows in editor
    }

    public void OpenCharacterPanel() {
        characterPanel.SetActive(true);
        weaponPanel.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void OpenWeaponPanel() {
        weaponPanel.SetActive(true);
        characterPanel.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void BackToMainMenu() {
        characterPanel.SetActive(false);
        weaponPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SelectPlayer(int index) {
        selectedPlayerIndex = index;
        Debug.Log("Selected Player: " + index);
    }

    public void SelectWeapon(int index) {
        selectedWeaponIndex = index;
        Debug.Log("Selected Weapon: " + index);
    }
}
