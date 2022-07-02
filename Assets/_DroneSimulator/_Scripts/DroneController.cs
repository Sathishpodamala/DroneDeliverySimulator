using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Baracuda.Monitoring.API;
using Baracuda.Monitoring;

namespace Alpha
{
    [RequireComponent(typeof(Rigidbody),typeof(DroneInputManager))]
    public class DroneController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 4f;
        [SerializeField] private float lerpSpeed = 2f;

        [Header("Motor Properties")]
        [SerializeField] private float maxPower = 4f;


        private float finalPitch;
        private float finalRoll;
        private float finalYaw;
        private float yaw;


        private List<IMotor> droneMotors = new List<IMotor>();
        private Rigidbody rb;
        private DroneInputManager inputManager;
        #endregion

        #region Monitor
        [Monitor]
        public Vector3 rbVelocity;

        [Monitor]
        public Vector3 eular;

        [Monitor]
        public Quaternion rot;
        #endregion


        #region UnityMethods
        void Awake()
        {
            Init();
            MonitoringManager.RegisterTarget(this);
        }
        private void OnDestroy()
        {
            MonitoringManager.UnregisterTarget(this);
        }

        void FixedUpdate()
        {
            rot = transform.rotation;
            eular = transform.eulerAngles;

            if(rb)
            {
                HandleControls();
                HandleMotors();

                rbVelocity = rb.velocity;
            }
        }
        #endregion

        #region PublicMethods

        #endregion

        #region PrivateMethods
        private void Init()
        {
            rb = GetComponent<Rigidbody>();
            inputManager = GetComponent<DroneInputManager>();
            droneMotors = GetComponentsInChildren<IMotor>().ToList<IMotor>();


            foreach(IMotor motor in droneMotors)
            {
                motor.Init(maxPower);
            }
        }


        private void HandleControls()
        {
            float pitch = inputManager.verticalInput * minMaxPitch;
            float roll = -inputManager.horizontalInput * minMaxRoll;
            yaw += inputManager.leftRightInput * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

            Quaternion finalRotation = Quaternion.Euler(finalPitch, finalYaw, finalRoll);

            rb.MoveRotation(finalRotation);
        }

        private void HandleMotors()
        {
            foreach (IMotor motor in droneMotors)
            {
                motor.UpdateMotor(rb, inputManager.upDownInput);
            }
        }
        #endregion

        #region GameEventListeners

        #endregion
    }
}
