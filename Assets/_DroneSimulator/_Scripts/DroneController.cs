using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Alpha
{
    [RequireComponent(typeof(Rigidbody), typeof(DroneInputManager))]
    public class DroneController : MonoBehaviour
    {
        #region Variables

        [Header("Drone Speeds")]

        public float forwardSpeed = 7f;
        public float backwardSpeed = 5f;


        public float rightSpeed = 5f;
        public float leftSpeed = 5f;

        public float riseSpeed = 5f;
        public float lowerSpeed = 5f;


        [Header("Drone Adjustments")]
        [Range(0f, 1f)]
        public float acceleration = 0.5f;
        [Range(0f, 1f)]
        public float deceleration = 0.2f;

        [Tooltip("how eaisly the drone is affected by outside forces")]
        [Range(0f, 1f)]
        public float stability = 0.1f;
        [Tooltip("how fast the drone rotates")]
        [Range(0.1f, 5f)]
        public float turnSensitivty = 2f;

        public LayerMask groundsMask;


        public bool motorOn = false;


        [Space()]
        [Header("Propeller")]
        public float propSpinSpeed = 50f;
        [Range(0f, 1f)]
        public float propStopSpeed = 1f;
        public List<GameObject> propellers;

        [Header("Tilt Gameobjects")]
        public Transform frontTilt;
        public Transform backTilt;
        public Transform rightTilt;
        public Transform leftTilt;

        [Space()]
        [Header("Crash")]
        public bool fallAfterCollision = true;
        public float fallMinimumForce = 6f;
        public float sparkMinimumForce = 1f;
        public GameObject sparkPrefab;

        [Header("Audio")]
        public AudioSource flyingSound;
        public AudioSource sparkSound;


        [Space(20f)]
        [Header("Read Only")]
        public float liftForce;
        public float driveForce;
        public float strafeForce;
        public float turnForce;

        public float collisionMagnitude;
        public float groundDistance = float.PositiveInfinity;
        public float uprightAngleDistance;
        public float calPropSpeed;

        private float driveInput;
        private float strafeInput;
        private float liftInput;
        private float _drag;
        private float _angularDrag;
        private bool _gravity;

        private Vector3 startPosition;
        private Quaternion startRotation;

        private Collider coll;
        private RaycastHit hit;
        private Rigidbody rigidBody;
        private DroneInputManager droneInputManager;

        #endregion

        #region Unity Methods
        void Awake()
        {
            coll = GetComponent<Collider>();
            rigidBody = GetComponent<Rigidbody>();
            droneInputManager = GetComponent<DroneInputManager>();
            startPosition = base.transform.position;
            startRotation = base.transform.rotation;
            _gravity = rigidBody.useGravity;
            _drag = rigidBody.drag;
            _angularDrag = rigidBody.angularDrag;
        }



        void Update()
        {
            uprightAngleDistance = (1f - base.transform.up.y) * 0.5f;
            uprightAngleDistance = (((double)uprightAngleDistance < 0.001) ? 0f : uprightAngleDistance);
            if (Physics.Raycast(base.transform.position, Vector3.down, out hit, float.PositiveInfinity, groundsMask))
            {
                groundDistance = hit.distance;
                Debug.DrawLine(transform.position, hit.point, Color.blue);
            }

            calPropSpeed = (motorOn ? propSpinSpeed : (calPropSpeed * (1f - propStopSpeed / 2f)));
            foreach (GameObject propeller in propellers)
            {
                propeller.transform.Rotate(0f, calPropSpeed, 0f);
            }

            if ((bool)flyingSound)
            {
                flyingSound.volume = calPropSpeed / propSpinSpeed;
                flyingSound.pitch = 1f + liftForce * 0.02f;
            }

            HandleInput();
        }

        void FixedUpdate()
        {
            if (motorOn)
            {
                rigidBody.useGravity = false;
                rigidBody.drag = 0f;
                rigidBody.angularDrag = 0f;

                if (groundDistance > 0.2f)
                {
                    if (driveInput > 0f)
                    {
                        rigidBody.AddForceAtPosition(Vector3.down * (Mathf.Abs(driveInput) * 0.3f), frontTilt.position, ForceMode.Acceleration);
                    }

                    if (driveInput < 0f)
                    {
                        rigidBody.AddForceAtPosition(Vector3.down * (Mathf.Abs(driveInput) * 0.3f), backTilt.position, ForceMode.Acceleration);
                    }

                    if (strafeInput > 0f)
                    {
                        rigidBody.AddForceAtPosition(Vector3.down * (Mathf.Abs(strafeInput) * 0.3f), rightTilt.position, ForceMode.Acceleration);
                    }

                    if (strafeInput < 0f)
                    {
                        rigidBody.AddForceAtPosition(Vector3.down * (Mathf.Abs(strafeInput) * 0.3f), leftTilt.position, ForceMode.Acceleration);
                    }
                }

                Vector3 direction2 = base.transform.InverseTransformDirection(rigidBody.velocity);
                direction2.z = ((driveInput != 0f) ? Mathf.Lerp(direction2.z, driveInput, acceleration * 0.3f) : Mathf.Lerp(direction2.z, driveInput, deceleration * 0.2f));
                driveForce = ((Mathf.Abs(direction2.z) > 0.01f) ? direction2.z : 0f);
                direction2.x = ((strafeInput != 0f) ? Mathf.Lerp(direction2.x, strafeInput, acceleration * 0.3f) : Mathf.Lerp(direction2.x, strafeInput, deceleration * 0.2f));
                strafeForce = ((Mathf.Abs(direction2.x) > 0.01f) ? direction2.x : 0f);
                rigidBody.velocity = base.transform.TransformDirection(direction2);


                liftForce = ((liftInput != 0f) ? Mathf.Lerp(liftForce, liftInput, acceleration * 0.2f) : Mathf.Lerp(liftForce, liftInput, deceleration * 0.3f));
                liftForce = ((Mathf.Abs(liftForce) > 0.01f) ? liftForce : 0f);
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, liftForce, rigidBody.velocity.z);
                rigidBody.angularVelocity *= 1f - Mathf.Clamp(InputMagnitude(), 0.2f, 1f) * stability;
                Quaternion quaternion = Quaternion.FromToRotation(base.transform.up, Vector3.up);
                rigidBody.AddTorque(new Vector3(quaternion.x, 0f, quaternion.z) * 100f, ForceMode.Acceleration);
                rigidBody.angularVelocity = new Vector3(rigidBody.angularVelocity.x, turnForce, rigidBody.angularVelocity.z);
            }
            else
            {
                rigidBody.useGravity = _gravity;
                rigidBody.drag = _drag;
                rigidBody.angularDrag = _angularDrag;
            }
        }

        void OnCollisionEnter(Collision newObject)
        {
            collisionMagnitude = newObject.relativeVelocity.magnitude;

            if (collisionMagnitude > fallMinimumForce && fallAfterCollision)
            {
                motorOn = false;
            }
        }

        void OnCollisionStay(Collision newObject)
        {
            if (groundDistance < coll.bounds.extents.y + 0.15f)
            {
                liftForce = Mathf.Clamp(liftForce, 0f, float.PositiveInfinity);
            }
        }

        #endregion



        #region Private Methods
        private void HandleInput()
        {
            DriveInput(droneInputManager.verticalInput);
            StrafeInput(droneInputManager.horizontalInput);
            LiftInput(droneInputManager.upDownInput);
            TurnInput(droneInputManager.leftRightInput);
        }


        private void DriveInput(float input)
        {
            if (input > 0f)
            {
                driveInput = input * forwardSpeed;
            }
            else if (input < 0f)
            {
                driveInput = input * backwardSpeed;
            }
            else
            {
                driveInput = 0f;
            }
        }

        private void StrafeInput(float input)
        {
            if (input > 0f)
            {
                strafeInput = input * rightSpeed;
            }
            else if (input < 0f)
            {
                strafeInput = input * leftSpeed;
            }
            else
            {
                strafeInput = 0f;
            }
        }

        private void LiftInput(float input)
        {
            if (input > 0f)
            {
                liftInput = input * riseSpeed;
                motorOn = true;
            }
            else if (input < 0f)
            {
                liftInput = input * lowerSpeed;
            }
            else
            {
                liftInput = 0f;
            }
        }

        private void TurnInput(float input)
        {
            turnForce = input * turnSensitivty;
        }

        private float InputMagnitude()
        {
            return (Mathf.Abs(driveInput) + Mathf.Abs(strafeInput) + Mathf.Abs(liftInput)) / 3f;
        }

        private void ResetDronePosition()
        {
            rigidBody.position = startPosition;
            rigidBody.rotation = startRotation;
            rigidBody.velocity = Vector3.zero;
        }


        private void AdjustLift(float value)
        {
            riseSpeed = value;
            lowerSpeed = value;
        }

        private void AdjustSpeed(float value)
        {
            forwardSpeed = value;
            backwardSpeed = value;
        }

        private void AdjustStrafe(float value)
        {
            rightSpeed = value;
            leftSpeed = value;
        }

        private void AdjustTurn(float value)
        {
            turnSensitivty = value;
        }

        private void AdjustAccel(float value)
        {
            acceleration = value;
        }

        private void AdjustDecel(float value)
        {
            deceleration = value;
        }

        private void AdjustStable(float value)
        {
            stability = value;
        }

        private void ToggleFall(bool state)
        {
            fallAfterCollision = !fallAfterCollision;
        }
        private void ToggleMotor()
        {
            motorOn = !motorOn;
        }

        #endregion
    }
}
