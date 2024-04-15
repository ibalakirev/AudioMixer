using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetingsSounds : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _sliderAllVolumeSounds;
    [SerializeField] private Slider _sliderBackGroundVolumeMusic;
    [SerializeField] private Slider _sliderButtonsVolumeSounds;
    [SerializeField] private Toggle _toggle;

    private float _minValueVolumeSounds = -80f;
    private float _maxValueVolumeSounds = 0f;

    private void OnEnable()
    {
        _sliderAllVolumeSounds.onValueChanged.AddListener(ChangeAllVolumeEffects);
        _sliderBackGroundVolumeMusic.onValueChanged.AddListener(ChangeVolumeMusic);
        _sliderButtonsVolumeSounds.onValueChanged.AddListener(ChangeVolumeEffectsSounds);
 
        _toggle.onValueChanged.AddListener(SwitchVolumeAllSounds);
    }

    private void OnDisable()
    {
        _sliderAllVolumeSounds.onValueChanged.RemoveListener(ChangeAllVolumeEffects);
        _sliderBackGroundVolumeMusic.onValueChanged.RemoveListener(ChangeVolumeMusic);
        _sliderButtonsVolumeSounds.onValueChanged.RemoveListener(ChangeVolumeEffectsSounds);

        _toggle.onValueChanged.RemoveListener(SwitchVolumeAllSounds);
    }

    private void ChangeAllVolumeEffects(float volume)
    {
        ChangeSound(MasterVolume, volume);
    }

    private void ChangeVolumeMusic(float volume)
    {
        ChangeSound(MusicVolume, volume);
    }

    private void ChangeVolumeEffectsSounds(float volume)
    {
        ChangeSound(EffectsVolume, volume);
    }

    private void ChangeSound(string nameMixerParametr, float volume)
    {
        _mixer.audioMixer.SetFloat(nameMixerParametr, Mathf.Lerp(_minValueVolumeSounds, _maxValueVolumeSounds, volume));
    }

    private void SwitchVolumeAllSounds(bool enabled)
    {
        if (enabled == true)
        {
            SetFloatMixer(_maxValueVolumeSounds);
        }
        else
        {
            SetFloatMixer(_minValueVolumeSounds);
        }
    }

    private void SetFloatMixer(float valueVolumeSound)
    {
        _mixer.audioMixer.SetFloat(MasterVolume, valueVolumeSound);
    }
}
