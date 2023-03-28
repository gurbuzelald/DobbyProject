using UnityEngine;
using UnityEngine.UI;
using Cinemachine;



public abstract class AbstractSingleton<T> : MonoBehaviour, IPlayer where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }

    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            DontDestroyOnLoad(gameObject);
        }
    }
    public void SayHello(string value)
    {
        Debug.Log(value);
    }


    #region //Start

    #endregion

    #region //Shoot
    public virtual void Fire(PlayerData _playerData)
    {
        if (_playerData.isPlayable && PlayerManager.GetInstance._playerController.fire && !_playerData.isWinning)
        {
            //PlayerData
            if (_playerData.bulletAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);

                _playerData.isFireNonWalk = false;

                _playerData.isFireWalk = false;
            }
            else if (_playerData.bulletAmount <= _playerData.bulletPack / 2f && !_playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireNonWalk = true;

            }
            else if (_playerData.bulletAmount > _playerData.bulletPack / 2f && !_playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireNonWalk = true;

            }
            else if (_playerData.bulletAmount <= _playerData.bulletPack / 2f && _playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireWalk = true;

            }
            else if (_playerData.bulletAmount > _playerData.bulletPack / 2f && _playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireWalk = true;
            }


            //SetFalseBullet
            StartCoroutine(PlayerManager.GetInstance.DelayShowingCrosshairAlpha(2f));
            PlayerManager.GetInstance.BulletPackGrow();
        }
        else
        {
            _playerData.isFireNonWalk = false;
            StartCoroutine(PlayerManager.GetInstance.delayFireWalkDisactivity(4f));
        }
    }
    public virtual void Sword(PlayerData _playerData)
    {
        if (_playerData.isPlayable)
        {
            if (PlayerManager.GetInstance._playerController.sword && _playerData.isSwordTime)
            {
                //PlayerData
                _playerData.isSwording = true;

                //SetFalseBullet
                StartCoroutine(PlayerManager.GetInstance.DelayShowingCrosshairAlpha(2f));
            }
            else
            {
                _playerData.isSwording = false;
            }
        }
        else
        {
            _playerData.isFireNonWalk = false;
        }
    }

    #endregion


    #region //Camera


    public virtual void ChangeCamera()
    {
        if (PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 
            && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToFarCamera(PlayerManager.GetInstance.cameraSpawner);
        }
        else if (PlayerManager.GetInstance._zValue != 0 && PlayerManager.GetInstance._xValue == 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(PlayerManager.GetInstance.cameraSpawner);
        }
        else if (PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue != 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(PlayerManager.GetInstance.cameraSpawner);
        }
        else if (PlayerManager.GetInstance._zValue != 0 && PlayerManager.GetInstance._xValue != 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(PlayerManager.GetInstance.cameraSpawner);
        }
    }
    public virtual void ConvertToCloseCamera(GameObject cameraSpawner)
    {
        cameraSpawner.transform.GetChild(0).gameObject.transform.position = cameraSpawner.transform.GetChild(1).gameObject.transform.position;
        cameraSpawner.transform.GetChild(0).gameObject.transform.rotation = cameraSpawner.transform.GetChild(1).gameObject.transform.rotation;

        cameraSpawner.transform.GetChild(1).gameObject.SetActive(false);
        cameraSpawner.transform.GetChild(0).gameObject.SetActive(true);
        PlayerManager.GetInstance._currentCamera = cameraSpawner.transform.GetChild(0).gameObject.GetComponent<CinemachineVirtualCamera>();
        PlayerManager.GetInstance._currentCamera.m_Follow = gameObject.transform;
        PlayerManager.GetInstance._currentCamera.m_LookAt = gameObject.transform;
    }
    public virtual void ConvertToFarCamera(GameObject cameraSpawner)
    {
        cameraSpawner.transform.GetChild(1).gameObject.transform.position = cameraSpawner.transform.GetChild(0).gameObject.transform.position;
        cameraSpawner.transform.GetChild(1).gameObject.transform.rotation = cameraSpawner.transform.GetChild(0).gameObject.transform.rotation;

        cameraSpawner.transform.GetChild(0).gameObject.SetActive(false);
        cameraSpawner.transform.GetChild(1).gameObject.SetActive(true);

        PlayerManager.GetInstance._currentCamera = cameraSpawner.transform.GetChild(1).gameObject.GetComponent<CinemachineVirtualCamera>();

        PlayerManager.GetInstance._currentCamera.m_Follow = gameObject.transform;
        PlayerManager.GetInstance._currentCamera.m_LookAt = gameObject.transform;
    }

    public virtual void CheckCameraEulerX(PlayerData _playerData, Transform _currentCameraTransform)
    {
        if (_currentCameraTransform.transform.eulerAngles.x > 74 && _currentCameraTransform.transform.eulerAngles.x <= 80)
        {
            //PlayerData
            _playerData.isLookingUp = false;

            //CinemachineVirtualCamera
            _currentCameraTransform.transform.eulerAngles = new Vector3(0f, _currentCameraTransform.transform.eulerAngles.y, _currentCameraTransform.transform.eulerAngles.z);
        }
        else if (_currentCameraTransform.transform.eulerAngles.x > 355)
        {
            //PlayerData
            _playerData.isLookingUp = false;

            //CinemachineVirtualCamera
            _currentCameraTransform.transform.eulerAngles = new Vector3(0f, _currentCameraTransform.transform.eulerAngles.y, _currentCameraTransform.transform.eulerAngles.z);
        }
        else if (_currentCameraTransform.transform.eulerAngles.x < 0)
        {
            //PlayerData
            _playerData.isLookingUp = true;

            //CinemachineVirtualCamera
            _currentCameraTransform.transform.eulerAngles = new Vector3(0f, _currentCameraTransform.transform.eulerAngles.y, _currentCameraTransform.transform.eulerAngles.z);
        }
        else if (_currentCameraTransform.transform.eulerAngles.x > 270 && _currentCameraTransform.transform.eulerAngles.x <= 360)
        {
            //PlayerData
            _playerData.isLookingUp = true;
            //_currentCamera = _upCamera;
        }
        else
        {
            _playerData.isLookingUp = false;
        }
    }

    #endregion
}