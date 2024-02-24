using System;
using Code.UI.Services;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Services.PauseService
{
    public class PauseService : IPauseService
    {
        public bool Paused => _paused;

        private IWindowService _windowService;
        private bool _paused;

        public PauseService(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Pause(PauseType type)
        {
            switch (type)
            {
                case PauseType.PauseTimeScaleOnly:
                    PauseTimeScaleOnly();
                    break;
                case PauseType.PauseTimeScaleAndShowWindow:
                    PauseTimeScaleAndShowWindow();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            _paused = true;
        }

        public void Unpause(PauseType type)
        {
            switch (type)
            {
                case PauseType.PauseTimeScaleOnly:
                    UnpauseTimeScaleOnly();
                    break;
                case PauseType.PauseTimeScaleAndShowWindow:
                    UnpauseTimeScaleAndShowWindow();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            _paused = false;
        }

        private void PauseTimeScaleOnly()
            => Time.timeScale = 0;

        private void UnpauseTimeScaleOnly()
            => Time.timeScale = 1;

        private void PauseTimeScaleAndShowWindow()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            _windowService.Open(WindowType.Pause);
        }

        private void UnpauseTimeScaleAndShowWindow()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            _windowService.Close(WindowType.Pause);
        }
    }
}