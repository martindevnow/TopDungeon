using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        // Prevent creating multiple GameManager instances when the main scene reloads
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    // public Weapon weapon ...
    public FloatingTextManager floatingTextManager;

    // Logic
    public int coins;
    public int experience;

    // Floating Text
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    // State Management
    /**
     * INT preferredSkin
     * INT coins
     * INT experience
     * INT weaponLevel
     */
    public void SaveState()
    {
        Debug.Log("save state");
        string s = "";
        s += "0" + "|";
        s += coins.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("load state");

        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // TODO: Change player skin
        coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // TODO: Set weapon level

    }
}
