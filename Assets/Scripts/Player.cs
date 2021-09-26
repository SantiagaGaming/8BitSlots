using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _getScore;
    private int _score;
   private void Start()
    {
        _scoreText.text = _score.ToString();
    }
   public void UpdateScore(int value)
    {
        _score += value;
        _scoreText.text = _score.ToString();
        StartCoroutine(ShowScore(value));
    }

    private IEnumerator ShowScore(int score)
    {
        _getScore.SetActive(true);
        _getScore.GetComponent<Text>().text = "+" + score.ToString();
        yield return new WaitForSeconds(2f);
        _getScore.SetActive(false) ;
    }

}
