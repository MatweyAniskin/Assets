using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayerCamera
{
    public class SkillsCameraFocus : MonoBehaviour
    {
        [SerializeField] CameraController controller;
        [SerializeField] FocusBehaviourProfile[] focusBehaviourProfiles;
        void Start()
        {
            PlayerBehaviour.OnChangeActionType += ChangeBehaviourActionType;
        }
        private void OnDestroy()
        {
            PlayerBehaviour.OnChangeActionType -= ChangeBehaviourActionType;
        }
        void ChangeBehaviourActionType(PlayerBehaviour.Type type)
        {
            var profile = focusBehaviourProfiles.FirstOrDefault(i => i == type) ?? null;
            if (profile is null) return;
            controller.SetFov(profile.Fov);
        }

    }
}
