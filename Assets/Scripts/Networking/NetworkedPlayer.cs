using UnityEngine;

public class NetworkedPlayer : Photon.MonoBehaviour
{
    private PlayerAnimation _playerAnim;

    private Vector3 _correctPlayerPos = Vector3.zero;
    private Quaternion _correctPlayerRot = Quaternion.identity;

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;

    private void Awake()
    {
        if (this.photonView == null || this.photonView.observed != this)
        {
            Debug.LogWarning(this + " is not observed by this object's photonView! OnPhotonSerializeView() in this class won't be used.");
        }
    }

    private void Start()
    {
        _playerAnim = GetComponent<PlayerAnimation>();
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            
            // animation data
            int[] animStates = _playerAnim.GetAnimationBooleans();
            stream.SendNext(animStates[0]);
            stream.SendNext(animStates[1]);
            stream.SendNext(animStates[2]);
        }
        else
        {
            //Network player, receive data
            _correctPlayerPos = (Vector3)stream.ReceiveNext();
            _correctPlayerRot = (Quaternion)stream.ReceiveNext();

            // animation data
            _playerAnim.ApplyNetworkAnimations((int)stream.ReceiveNext(), (int)stream.ReceiveNext(), (int)stream.ReceiveNext());

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;
        }
    }

    private void Update()
    {
        if (!photonView.isMine)
        {
            syncTime += Time.deltaTime;
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            transform.position = Vector3.Lerp(transform.position, _correctPlayerPos, syncTime / syncDelay);
            transform.rotation = Quaternion.Lerp(transform.rotation, _correctPlayerRot, syncTime / syncDelay);
        }
    }
}