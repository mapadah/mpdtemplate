using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MPDTemplate.Mods
{
    internal class MovementMods
    {
        private static GameObject leftplat;
        private static GameObject rightplat;
        private static GameObject SpawnPlat(Transform handTransform)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
            gameObject.transform.position = handTransform.position;
            gameObject.transform.rotation = handTransform.rotation;
            float num = (float)Time.frameCount / 180f % 1f;
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = (Color.gray);
            return gameObject;
        }
// lynxisnotcewl gave me this code, thank you!!!!
        public static void Platforms()
        {
            if (ControllerInputPoller.instance.leftGrab && leftplat == null)
            {
                leftplat = SpawnPlat(GorillaTagger.Instance.leftHandTransform);
            }

            if (ControllerInputPoller.instance.rightGrab && rightplat == null)
            {
                rightplat = SpawnPlat(GorillaTagger.Instance.rightHandTransform);
            }

            if (ControllerInputPoller.instance.leftGrabRelease && leftplat != null)
            {
                leftplat.Disable();
                leftplat = null;
            }

            if (ControllerInputPoller.instance.rightGrabRelease && rightplat != null)
            {
                rightplat.Disable();
                rightplat = null;
            }
        }
    }
}
