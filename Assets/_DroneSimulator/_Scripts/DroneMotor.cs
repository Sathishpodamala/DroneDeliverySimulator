using UnityEngine;


namespace Alpha
{
    public class DroneMotor : MonoBehaviour, IMotor
    {

        #region Variables
        [Header("Motor Properties")]
        [SerializeField] private float maxPower = 4f;
        [SerializeField] private int motorCount = 4;

        [Header("Propeller Properties")]
        [SerializeField] private Transform propeller;
        [SerializeField] private float propSpinSpeed = 100f;

        [Tooltip("how fast the propellers slow down")]
        [HideInInspector]
        [Range(0f, 1f)]
        public float propStopSpeed = 1f;
        private float calPropSpeed;
        #endregion


        #region Interface Methods
        public void Init(float maxPower, int motorCount)
        {
            this.maxPower = maxPower;
            this.motorCount = motorCount;
        }

        public void UpdateMotor(Rigidbody rb, float throttle)
        {
            Vector3 upVector = transform.up;
            upVector.x = 0;
            upVector.z = 0;

            float difference = 1 - upVector.magnitude;
            float finalDifference = Physics.gravity.magnitude * difference;

            Vector3 motorForce = Vector3.zero;
            motorForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDifference) + (maxPower * throttle)) / motorCount;
            Debug.Log("Force: " + motorForce);

            rb.AddForce(motorForce, ForceMode.Force);

            HanldePropeller(rb,throttle);
        }


        #endregion
        #region Private Methods
        private void HanldePropeller(Rigidbody rb,float throttle)
        {
            calPropSpeed = ( rb.velocity!=Vector3.zero? propSpinSpeed : (calPropSpeed * (1f - propStopSpeed / 2f)));
            propeller.Rotate(Vector3.up, calPropSpeed);
        }
        #endregion
    }
}
