

using Normal.Utility;
using System;
using UnityEngine;

namespace Normal.Realtime
{
    [ExecutionOrder(-95)]
    public class SwimmyAvatar : RealtimeComponent<RealtimeAvatarModel>
    {
        // Local Player
        [Serializable]
        public class LocalPlayer
        {
            public Transform root;
            public Transform head;
            public Transform leftHand;
            public Transform rightHand;
        }

        public DeviceType deviceType { get; set; }
        public string deviceModel { get; set; }
        public LocalPlayer localPlayer { get { return _localPlayer; } set { SetLocalPlayer(value); } }
#pragma warning disable 0649 // Disable variable is never assigned to warning.
        private LocalPlayer _localPlayer;
#pragma warning restore 0649
        // Prefab
        public Transform head { get { return _head; } }
        public Transform leftHand { get { return _leftHand; } }
        public Transform rightHand { get { return _rightHand; } }
#pragma warning disable 0649 // Disable variable is never assigned to warning.
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _leftHand;
        [SerializeField] private Transform _rightHand;

        public Player _player;

#pragma warning restore 0649
        private SwimmyAvatarManager _realtimeAvatarManager;
        void Start()
        {
            if (GetComponent<Player>() != null)
            {
                _player = GetComponent<Player>();
                Debug.Log("ID assigned to player in SwimmyAvatar is: " + realtimeView.ownerID);
            }
            else
            {
                Debug.Log("Player component null on SwimmyAvatar");
            }

            // Register with RealtimeAvatarManager
            try
            {
                _realtimeAvatarManager = realtime.GetComponent<SwimmyAvatarManager>();
                _realtimeAvatarManager._RegisterAvatar(realtimeView.ownerID, this);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("RealtimeAvatar failed to register with RealtimeAvatarManager component. Was this avatar prefab instantiated by RealtimeAvatarManager?");
            }
        }
        public enum DeviceType : uint
        {
            Unknown = 0,
            OpenVR = 1,
            Oculus = 2
        }

        void OnDestroy()
        {
            // Unregister with RealtimeAvatarManager
            if (_realtimeAvatarManager != null)
                _realtimeAvatarManager._UnregisterAvatar(this);
            // Unregister for events
            localPlayer = null;
        }
        void FixedUpdate()
        {
            UpdateAvatarTransformsForLocalPlayer();
        }
        void Update()
        {
            UpdateAvatarTransformsForLocalPlayer();
        }
        void LateUpdate()
        {
            UpdateAvatarTransformsForLocalPlayer();
        }
        protected override void OnRealtimeModelReplaced(RealtimeAvatarModel previousModel, RealtimeAvatarModel currentModel)
        {
            if (previousModel != null)
            {
                previousModel.headActiveDidChange -= ActiveStateChanged;
                previousModel.leftHandActiveDidChange -= ActiveStateChanged;
                previousModel.rightHandActiveDidChange -= ActiveStateChanged;
            }
            if (currentModel != null)
            {
                currentModel.headActiveDidChange += ActiveStateChanged;
                currentModel.leftHandActiveDidChange += ActiveStateChanged;
                currentModel.rightHandActiveDidChange += ActiveStateChanged;
            }
        }
        void SetLocalPlayer(LocalPlayer localPlayer)
        {
            if (localPlayer == _localPlayer)
                return;
            _localPlayer = localPlayer;
            if (_localPlayer != null)
            {
                RealtimeTransform rootRealtimeTransform = GetComponent<RealtimeTransform>();
                RealtimeTransform headRealtimeTransform = _head != null ? _head.GetComponent<RealtimeTransform>() : null;
                RealtimeTransform leftHandRealtimeTransform = _leftHand != null ? _leftHand.GetComponent<RealtimeTransform>() : null;
                RealtimeTransform rightHandRealtimeTransform = _rightHand != null ? _rightHand.GetComponent<RealtimeTransform>() : null;
                if (rootRealtimeTransform != null) rootRealtimeTransform.RequestOwnership();
                if (headRealtimeTransform != null) headRealtimeTransform.RequestOwnership();
                if (leftHandRealtimeTransform != null) leftHandRealtimeTransform.RequestOwnership();
                if (rightHandRealtimeTransform != null) rightHandRealtimeTransform.RequestOwnership();

<<<<<<< Updated upstream
                //Get player name
                if (GetComponentInParent<Player>() != null)
                {
                    GameObject currentAvatar = _realtimeAvatarManager.localAvatar.gameObject;
                    _player = currentAvatar.GetComponent<Player>();
                }
                else
                {
                    Debug.Log("No player component found");
                }
=======
>>>>>>> Stashed changes
            }
        }
        void ActiveStateChanged(RealtimeAvatarModel model, bool nodeIsActive)
        {
            // Leave the head active so RealtimeAvatarVoice runs even when the head isn't tracking.
            if (_leftHand != null) _leftHand.gameObject.SetActive(model.leftHandActive);
            if (_rightHand != null) _rightHand.gameObject.SetActive(model.rightHandActive);
        }
        void UpdateAvatarTransformsForLocalPlayer()
        {
            // Make sure this avatar is a local player
            if (_localPlayer == null)
                return;
            // Root
            if (_localPlayer.root != null)
            {
                transform.position = _localPlayer.root.position;
                transform.rotation = _localPlayer.root.rotation;
                transform.localScale = _localPlayer.root.localScale;
            }
            // Head
            if (_localPlayer.head != null)
            {
                model.headActive = _localPlayer.head.gameObject.activeSelf;
                _head.position = _localPlayer.head.position;
                _head.rotation = _localPlayer.head.rotation;
            }
            else
            {
            }
            // Left Hand
            if (_leftHand != null)
            {
                if (_localPlayer.leftHand != null)
                {
                    model.leftHandActive = _localPlayer.leftHand.gameObject.activeSelf;
                    _leftHand.position = _localPlayer.leftHand.position;
                    _leftHand.rotation = _localPlayer.leftHand.rotation;
                }
                else
                {
                }
            }
            // Right Hand
            if (_rightHand != null)
            {
                if (_localPlayer.rightHand != null)
                {
                    model.rightHandActive = _localPlayer.rightHand.gameObject.activeSelf;
                    _rightHand.position = _localPlayer.rightHand.position;
                    _rightHand.rotation = _localPlayer.rightHand.rotation;
                }
                else
                {
                }
            }
        }
    }
}