using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [SerializeField] PlayerMovement player;
    [SerializeField] Health _playerHealth;
    private float playerHealth =5;
    public float PlayerHealth() => playerHealth;
    private float playerMaxHealth = 100f;
    private float playerSpeed = 3f;
    public float PlayerSpeed() => playerSpeed;
    private float playerMaxSpeed = 20f;
    private float speedBuffDuration = 2f;
    public float lastSpeed;
    private Coroutine speedBuffCoroutine;
    void Awake()
    {
        UpdatePlayerSpeed();
        lastSpeed = playerSpeed;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void HealthBuff(float val)
    {
        playerHealth = Mathf.Min(playerMaxHealth, playerHealth + val);
        UpdatePlayerHealth();
        Debug.Log("Player health: " + playerHealth);
    }

    public void SpeedBuff(float val)
    {
        if (speedBuffCoroutine != null)
        {
            playerSpeed = lastSpeed;
            StopCoroutine(speedBuffCoroutine);
        }
        speedBuffCoroutine = StartCoroutine(SpeedBuffCoroutine(val));
    }

    IEnumerator SpeedBuffCoroutine(float val)
    {
        lastSpeed = playerSpeed;
        playerSpeed = Mathf.Min(playerMaxSpeed, playerSpeed + val);
        UpdatePlayerSpeed();
        yield return new WaitForSeconds(speedBuffDuration);
        playerSpeed = lastSpeed;
        UpdatePlayerSpeed();
        speedBuffCoroutine = null;
    }
    private void UpdatePlayerSpeed()
    {
        player.UpdateSpeed(playerSpeed);
        Debug.Log("Current speed: " + playerSpeed);
    }
    private void UpdatePlayerHealth()
    {
        _playerHealth.UpdateHealth(playerHealth);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }
}
