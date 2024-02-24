using Code.Logic;
using UnityEngine;

namespace Code.UI.Elements.HUD.DesctopHUD
{
    public class MobileHud : HudBase
    {
        [SerializeField] private RectTransform cameraRotationZone;

        public RectTransform CameraRotationZone => cameraRotationZone; 
    }
}