//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_DroneSimulator/Input/DroneInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Alpha
{
    public partial class @DroneInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DroneInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DroneInput"",
    ""maps"": [
        {
            ""name"": ""Drone"",
            ""id"": ""f633e1e9-c26e-43a5-8b9f-53214e1f53a5"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Value"",
                    ""id"": ""6f0ba9bb-6c9f-42c5-a466-2079541b59c7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ARROWS"",
                    ""type"": ""Value"",
                    ""id"": ""c8afb97f-4888-4086-9e11-bccdb744174f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DROP"",
                    ""type"": ""Button"",
                    ""id"": ""edaff5d2-a146-455d-ad22-89084c3c1e25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""30f621c3-8de5-4031-a3e7-c75fc5c4a987"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a894b0bf-8387-4faa-abf5-35411b07e5fe"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1800e575-c762-474c-accf-b75e8a17bc13"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4a720599-76f1-4588-a47d-02199856eb88"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""417e1be4-3837-4b2d-ab89-42b8d2553823"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7f5284db-24ad-489a-8377-90284d3cc699"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""41a1b968-968a-4ec6-9c0a-47a1743fa3c8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ARROWS"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""33f4adf9-5a33-42c6-b461-ca915030ad40"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ARROWS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f8343ed3-3de3-4d56-bcc1-f44410260308"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ARROWS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""47fd77d5-dadb-4821-9464-3bd3c5cd7227"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ARROWS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""13a7cbe6-c07f-4e14-8ba7-81b4d38db2ce"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ARROWS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fbc8eef7-1f10-4f7f-a327-80f4e4d2a440"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ARROWS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d481d3-6f75-4f3c-8a8c-f21c83ef5ae8"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DROP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efc2c47d-a402-4a42-b1f1-76218d4be465"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DROP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Drone
            m_Drone = asset.FindActionMap("Drone", throwIfNotFound: true);
            m_Drone_WASD = m_Drone.FindAction("WASD", throwIfNotFound: true);
            m_Drone_ARROWS = m_Drone.FindAction("ARROWS", throwIfNotFound: true);
            m_Drone_DROP = m_Drone.FindAction("DROP", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Drone
        private readonly InputActionMap m_Drone;
        private IDroneActions m_DroneActionsCallbackInterface;
        private readonly InputAction m_Drone_WASD;
        private readonly InputAction m_Drone_ARROWS;
        private readonly InputAction m_Drone_DROP;
        public struct DroneActions
        {
            private @DroneInput m_Wrapper;
            public DroneActions(@DroneInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @WASD => m_Wrapper.m_Drone_WASD;
            public InputAction @ARROWS => m_Wrapper.m_Drone_ARROWS;
            public InputAction @DROP => m_Wrapper.m_Drone_DROP;
            public InputActionMap Get() { return m_Wrapper.m_Drone; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DroneActions set) { return set.Get(); }
            public void SetCallbacks(IDroneActions instance)
            {
                if (m_Wrapper.m_DroneActionsCallbackInterface != null)
                {
                    @WASD.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnWASD;
                    @WASD.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnWASD;
                    @WASD.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnWASD;
                    @ARROWS.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnARROWS;
                    @ARROWS.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnARROWS;
                    @ARROWS.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnARROWS;
                    @DROP.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnDROP;
                    @DROP.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnDROP;
                    @DROP.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnDROP;
                }
                m_Wrapper.m_DroneActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @WASD.started += instance.OnWASD;
                    @WASD.performed += instance.OnWASD;
                    @WASD.canceled += instance.OnWASD;
                    @ARROWS.started += instance.OnARROWS;
                    @ARROWS.performed += instance.OnARROWS;
                    @ARROWS.canceled += instance.OnARROWS;
                    @DROP.started += instance.OnDROP;
                    @DROP.performed += instance.OnDROP;
                    @DROP.canceled += instance.OnDROP;
                }
            }
        }
        public DroneActions @Drone => new DroneActions(this);
        public interface IDroneActions
        {
            void OnWASD(InputAction.CallbackContext context);
            void OnARROWS(InputAction.CallbackContext context);
            void OnDROP(InputAction.CallbackContext context);
        }
    }
}
