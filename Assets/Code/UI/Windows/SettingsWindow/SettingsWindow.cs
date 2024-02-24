using Audio;
using Code.Data;
using Code.Services.SaveService;
using Code.UI.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.SettingsWindow
{
    public class SettingsWindow : WindowBase
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;

        private IWindowService _windowService;
        private IProgressModel _progress;
        private ISaveService _saveService;
        private MusicPlayer _musicPlayer;
        
        [Inject]
        private void Construct(IWindowService windowService, IProgressModel progress,
            ISaveService saveService, MusicPlayer musicPlayer)
        {
            _windowService = windowService;
            _progress = progress;
            _musicPlayer = musicPlayer;
            _saveService = saveService;
        }

        private void Awake()
        {
            musicVolumeSlider.value = _progress.Progress.Settings.MusicVolume;
            sfxVolumeSlider.value = _progress.Progress.Settings.SfxVolume;
        }

        private void OnEnable()
        {
            closeButton.onClick.AddListener(Close);
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderValueChanged);
            sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeSliderValueChanged);
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(Close);
            musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeSliderValueChanged);
            sfxVolumeSlider.onValueChanged.RemoveListener(OnSfxVolumeSliderValueChanged);
        }

        private void Close()
        {
            _windowService.Close(WindowType.Settings);
            _saveService.Save();
        }

        private void OnMusicVolumeSliderValueChanged(float value)
        {
            _progress.Progress.Settings.MusicVolume = value;
            _musicPlayer.ChangeVolume(value);
        }
        
        private void OnSfxVolumeSliderValueChanged(float value)
        {
            _progress.Progress.Settings.SfxVolume = value;
        }
        
        private void OnSensitivitySliderValueChanged(float value)
        {
            _progress.Progress.Settings.Sensitivity = value;
        }
    }
}