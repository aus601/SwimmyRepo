using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Serialization;

namespace Normal.Realtime
{
    [RequireComponent(typeof(Realtime))]
    public class SwimmyAvatarManager : MonoBehaviour
    {
#pragma warning disable 0649 // Disable variable is never assigned to warning.
        [FormerlySerializedAs("_avatarPrefab")]
        [SerializeField] private GameObject _localAvatarPrefab;
        [SerializeField] private SwimmyAvatar.LocalPlayer _localPlayer;
#pragma warning restore 0649

        public GameObject localAvatarPrefab { get { return _localAvatarPrefab; } set { SetLocalAvatarPrefab(value); } }

        public SwimmyAvatar localAvatar { get; private set; }
        public Dictionary<int, SwimmyAvatar> avatars { get; private set; }

        public delegate void AvatarCreatedDestroyed(SwimmyAvatarManager avatarManager, SwimmyAvatar avatar, bool isLocalAvatar);
        public event AvatarCreatedDestroyed avatarCreated;
        public event AvatarCreatedDestroyed avatarDestroyed;

        private Realtime _realtime;

        void Awake()
        {
            _realtime = GetComponent<Realtime>();
            _realtime.didConnectToRoom += DidConnectToRoom;

<<<<<<< Updated upstream
            if (_localPlayer == null)
                _localPlayer = new SwimmyAvatar.LocalPlayer();

            avatars = new Dictionary<int, SwimmyAvatar>();

        }

        private void Start()
        {
            //Hook up local avatar prefab with Pico components
=======
            //CUSTOM
            //Hook up local avatar prefab 
>>>>>>> Stashed changes
            _localPlayer.root = VRRigReference.instance.root;
            _localPlayer.head = VRRigReference.instance.head;
            _localPlayer.leftHand = VRRigReference.instance.leftHand;
            _localPlayer.rightHand = VRRigReference.instance.rightHand;

            if (_localPlayer == null)
                _localPlayer = new SwimmyAvatar.LocalPlayer();

            avatars = new Dictionary<int, SwimmyAvatar>();
          
        }

        private void OnEnable()
        {
            // Create avatar if we're already connected
            if (_realtime.connected)
                CreateAvatarIfNeeded();
        }

        private void OnDisable()
        {
            // Destroy avatar if needed
            DestroyAvatarIfNeeded();
        }

        void OnDestroy()
        {
            _realtime.didConnectToRoom -= DidConnectToRoom;
        }

        void DidConnectToRoom(Realtime room)
        {
            if (!gameObject.activeInHierarchy || !enabled)
                return;

            // Create avatar
            CreateAvatarIfNeeded();
        }

        public static SwimmyAvatar.DeviceType GetRealtimeAvatarDeviceTypeForLocalPlayer()
        {
            switch (XRSettings.loadedDeviceName)
            {
                case "OpenVR":
                    return SwimmyAvatar.DeviceType.OpenVR;
                case "Oculus":
                    return SwimmyAvatar.DeviceType.Oculus;
                default:
                    return SwimmyAvatar.DeviceType.Unknown;
            }
        }

        public void _RegisterAvatar(int clientID, SwimmyAvatar avatar)
        {
            if (avatars.ContainsKey(clientID))
            {
                Debug.LogError("RealtimeAvatar registered more than once for the same clientID (" + clientID + "). This is a bug!");
            }
            avatars[clientID] = avatar;
            Debug.Log("Client ID: " + clientID);

            // Fire event
            if (avatarCreated != null)
            {
                try
                {
                    avatarCreated(this, avatar, clientID == _realtime.clientID);
                    Debug.Log("Realtime Client ID: " + _realtime.clientID);
                }
                catch (System.Exception exception)
                {
                    Debug.LogException(exception);
                }
            }
        }

        public void _UnregisterAvatar(SwimmyAvatar avatar)
        {
            bool isLocalAvatar = false;

            List<KeyValuePair<int, SwimmyAvatar>> matchingAvatars = avatars.Where(keyValuePair => keyValuePair.Value == avatar).ToList();
            foreach (KeyValuePair<int, SwimmyAvatar> matchingAvatar in matchingAvatars)
            {
                int avatarClientID = matchingAvatar.Key;
                avatars.Remove(avatarClientID);

                isLocalAvatar = isLocalAvatar || avatarClientID == _realtime.clientID;
            }

            // Fire event
            if (avatarDestroyed != null)
            {
                try
                {
                    avatarDestroyed(this, avatar, isLocalAvatar);
                }
                catch (System.Exception exception)
                {
                    Debug.LogException(exception);
                }
            }
        }

        private void SetLocalAvatarPrefab(GameObject localAvatarPrefab)
        {
            if (localAvatarPrefab == _localAvatarPrefab)
                return;

            _localAvatarPrefab = localAvatarPrefab;

            // Replace the existing avatar if we've already instantiated the old prefab.
            if (localAvatar != null)
            {
                DestroyAvatarIfNeeded();
                CreateAvatarIfNeeded();
            }
        }

        public void CreateAvatarIfNeeded()
        {
            if (!_realtime.connected)
            {
                Debug.LogError("RealtimeAvatarManager: Unable to create avatar. Realtime is not connected to a room.");
                return;
            }

            if (localAvatar != null)
                return;

            if (_localAvatarPrefab == null)
            {
                Debug.LogWarning("Realtime Avatars local avatar prefab is null. No avatar prefab will be instantiated for the local player.");
                return;
            }

            // spawning avatar here on instantiating
            GameObject avatarGameObject = Realtime.Instantiate(_localAvatarPrefab.name, true, true, true, _realtime);

            if (avatarGameObject == null)
            {
                Debug.LogError("RealtimeAvatarManager: Failed to instantiate RealtimeAvatar prefab for the local player.");
                return;
            }

            localAvatar = avatarGameObject.GetComponent<SwimmyAvatar>();
            if (localAvatar == null)
            {
                Debug.LogError("RealtimeAvatarManager: Successfully instantiated avatar prefab, but could not find the RealtimeAvatar component.");
                return;
            }

            localAvatar.localPlayer = _localPlayer;
            localAvatar.deviceType = GetRealtimeAvatarDeviceTypeForLocalPlayer();
            localAvatar.deviceModel = XRDevice.model;

            // CUSTOM
            
            localAvatar._player = localAvatar.gameObject.GetComponent<Player>();
        }

        public void DestroyAvatarIfNeeded()
        {
            if (localAvatar == null)
                return;

            Realtime.Destroy(localAvatar.gameObject);

            localAvatar = null;
        }
    }
}
