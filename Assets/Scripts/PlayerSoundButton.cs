using UnityEngine;
using UnityEngine.UI;

public class PlayerSoundButton : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        _sound.Play();
    }
}
