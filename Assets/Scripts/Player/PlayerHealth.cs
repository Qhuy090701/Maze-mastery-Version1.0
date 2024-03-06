using UnityEngine;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour {
  [SerializeField] private Player player;

  private void OnValidate() {
    if (player == null) {
      player = GetComponent<Player>();
    }
  }

  private void Start() {
    LoadHealth();
    UpdateHealth();
  }

  public void UpdateHealth() {
    player.maxHealth = player.playerData.maxHealth;
    player.healthText.text = "Health: " + player.maxHealth;
  }

  public void CheckHealth() {
    RfHolder.Ins.cameraFollow.isFollowing = false;
    if (player.playerData.maxHealth > 0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ) {
      player.playerData.maxHealth--;
      SaveHealth(player.playerData.maxHealth);
    }
    else {
      //ResetHealth();
      Debug.Log("Health = 0");
    }
    UpdateHealth();
    DOVirtual.DelayedCall(1, () => { Instantiate(player.loseUi, RfHolder.Ins.canvas.transform); });
  }

  public void SaveHealth(int health) {
    player.playerData.maxHealth = health;
    PlayerPrefs.SetInt(Constants.PrefsKey_PlayerHealth, player.playerData.maxHealth);
  }

  public void LoadHealth() {
    if (PlayerPrefs.HasKey(Constants.PrefsKey_PlayerHealth)) {
      player.playerData.maxHealth = PlayerPrefs.GetInt(Constants.PrefsKey_PlayerHealth);
    }
  }

  public void ResetHealth() {
    player.playerData.maxHealth = 5;
    SaveHealth(player.playerData.maxHealth);
    UpdateHealth();
  }
}