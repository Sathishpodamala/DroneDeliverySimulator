using Alpha;
using UnityEngine;
using System.Collections.Generic;

namespace Deftouch
{
    public class DroneCamera : MonoBehaviour
    {

        public DroneController target;


        [Range(0.03f, 0.5f)]
        public float followSmoothing = 0.1f;

        [Range(0f, 7f)]
        public float xSensivity = 2f;

        [Range(0f, 7f)]
        public float ySensivity;

        public float height = 0.5f;

        public float distance = 1.5f;

        public float angle = 19f;

        public bool findTarget = true;

        public bool autoPosition = true;


        public bool gyroscopeEnabled;

        public bool invertYAxis;


        private Vector3 velocity;


        private float angleV;


        private float turnForce;

        private float liftForce;

        private float targetRot;
        private bool freeLook;

        private void Start()
        {
         

            if (autoPosition && (bool)target)
            {
                float num = Mathf.Abs(target.transform.position.x - base.transform.position.x);
                float num2 = Mathf.Abs(target.transform.position.z - base.transform.position.z);
                distance = ((num > num2) ? num : num2);
                height = Mathf.Abs(target.transform.position.y - base.transform.position.y);
                angle = base.transform.eulerAngles.x;
            }

        }


        private void LateUpdate()
        {


            if ((bool)target)
            {
                height += ((angle > -60f && angle < 60f) ? (liftForce * 0.03f) : 0f);
                angle = Mathf.Clamp(angle + liftForce, -60f, 60f);
                targetRot = (freeLook ? (targetRot + turnForce * xSensivity) : target.transform.eulerAngles.y);
                base.transform.position = target.transform.position - Quaternion.Euler(0f, targetRot, 0f) * Vector3.forward * distance + new Vector3(0f, height, 0f);
                base.transform.rotation = Quaternion.Euler(angle, targetRot, 0f);
            }

            
        }

        private void FixedUpdate()
        {


            height += ((angle > -60f && angle < 60f) ? (liftForce * 0.03f) : 0f);
            angle = Mathf.Clamp(angle + liftForce, -60f, 60f);
            targetRot = (freeLook ? (targetRot + turnForce * xSensivity) : target.transform.eulerAngles.y);
            float y = Mathf.SmoothDampAngle(base.transform.eulerAngles.y, targetRot, ref angleV, followSmoothing * Time.fixedDeltaTime * 60f);
            Vector3 vector = target.transform.position - Quaternion.Euler(0f, y, 0f) * Vector3.forward * distance + new Vector3(0f, height, 0f);
            base.transform.position = Vector3.SmoothDamp(base.transform.position, vector, ref velocity, followSmoothing * Time.fixedDeltaTime * 60f);
            base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(angle, targetRot, 0f), followSmoothing * Time.fixedDeltaTime * 60f);

        }


        public void ChangeGyroscope()
        {
            gyroscopeEnabled = !gyroscopeEnabled;
        }

        public void LiftInput(float input)
        {
            liftForce = ((!invertYAxis) ? (input * ySensivity) : ((0f - input) * ySensivity));
        }

        public void TurnInput(float input)
        {
            turnForce = input * xSensivity;
        }



        public void XSensitivity(float value)
        {
            xSensivity = value;
        }

        public void YSensitivity(float value)
        {
            ySensivity = value;
        }

        public void InvertYAxis(bool state)
        {
            invertYAxis = state;
        }
    }


}
