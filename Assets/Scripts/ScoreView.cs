using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _text;

    private int _startScore = 0;

    private void Start()
    {
        _text.text = SetDisplayTemplate(_startScore);
    }

    private void OnEnable()
    {
        _scoreCounter.Changed += UpdateScore;
    }

    private void OnDisable()
    {
        _scoreCounter.Changed -= UpdateScore;
    }

    private void UpdateScore(int count)
    {
        _text.text = SetDisplayTemplate(count);
    }

    private string SetDisplayTemplate(int count)
    {
        return $"Score {count}";
    }
}
