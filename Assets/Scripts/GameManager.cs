using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject VacumBar, LevelText;
    [SerializeField] private float RubbishBar;
    [SerializeField] private int rubbishMoney;
    [SerializeField] private Text moneyText;
    private int money;
    private float LevelBar;
    public ParticleSystem finish;
    private void Start()
    {
        LevelBar = 0;
        money = 0;
        money = PlayerPrefs.GetInt("money", money);
        finish.Stop();
    }
    void FixedUpdate()
    {
        PlayerPrefs.SetInt("money", money);     
        VacumBar.transform.localScale = new Vector3(LevelBar / 100, 1, 1);  
        if (VacumBar.transform.localScale.x == 1)
        {
            finish.Play();
            StartCoroutine(NextLevel());
            LevelText.SetActive(true); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Doritos")
        {
            Destroy(other.gameObject);
            LevelBar += RubbishBar;
            money += rubbishMoney;
            moneyText.text = money.ToString();
            VacumBar.transform.localScale = new Vector2(1, 1);
        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(Application.loadedLevel + 1);
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}