using UnityEngine;

public class MainGameManager : MonoBehaviour {
    public GameObject[] playerPrefabs;
    public GameObject[] weaponPrefabs;

    void Start() {
        int playerIndex = PlayerPrefs.GetInt("SelectedPlayer", 0);
        int weaponIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);
        Debug.Log(playerIndex + " " + weaponIndex);

        if (playerIndex >= playerPrefabs.Length || weaponIndex >= weaponPrefabs.Length) {
            Debug.LogWarning("Invalid player or weapon index.");
            return;
        }

        // Instantiate player
        GameObject player = Instantiate(playerPrefabs[playerIndex], Vector3.zero, Quaternion.identity);

        // Find WeaponPos transform inside the instantiated player
        Transform weaponPos = player.transform.Find("WeaponPos");
        if (weaponPos == null) {
            Debug.LogError("WeaponPos not found in player prefab.");
            return;
        }

        // Instantiate weapon at WeaponPos
        GameObject weapon = Instantiate(weaponPrefabs[weaponIndex], weaponPos.position, weaponPos.rotation);
        weapon.transform.SetParent(player.transform); // Optional: attach weapon to player
    }
}
