using UnityEngine;
using UnityEngine.InputSystem;


namespace Alpha
{
    public class DroneInputManager : MonoBehaviour
    {
        #region Variables
        public float horizontalInput;
        public float verticalInput;
        public float leftRightInput;
        public float upDownInput;

        private Vector2 horizontalVerticalInput;
        private Vector2 arrowsInput;
        private DroneInput droneInput;
        #endregion

        #region UnityMethods
        void Awake()
        {
            droneInput = new DroneInput();
        }

        void OnEnable()
        {
            droneInput.Drone.Enable();
            droneInput.Drone.WASD.performed += Get_WASD_Input;
            droneInput.Drone.WASD.canceled += Get_WASD_Input;

            droneInput.Drone.ARROWS.performed += Get_ARROWS_Input;
            droneInput.Drone.ARROWS.canceled += Get_ARROWS_Input;
        }

      
        void OnDisable()
        {
            droneInput.Drone.WASD.performed -= Get_WASD_Input;
            droneInput.Drone.WASD.canceled -= Get_WASD_Input;

            droneInput.Drone.ARROWS.performed -= Get_ARROWS_Input;
            droneInput.Drone.ARROWS.canceled -= Get_ARROWS_Input;
            droneInput.Drone.Enable();
        }
        #endregion

        #region PublicMethods

        #endregion

        #region PrivateMethods
        private void Get_ARROWS_Input(InputAction.CallbackContext obj)
        {
            arrowsInput = obj.ReadValue<Vector2>();
            leftRightInput = arrowsInput.x;
            upDownInput = arrowsInput.y;
        }

        private void Get_WASD_Input(InputAction.CallbackContext obj)
        {
            horizontalVerticalInput = obj.ReadValue<Vector2>();
            horizontalInput = horizontalVerticalInput.x;
            verticalInput = horizontalVerticalInput.y;
        }

        #endregion

        #region GameEventListeners

        #endregion
    }
}
