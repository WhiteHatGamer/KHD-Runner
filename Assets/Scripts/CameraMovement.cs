using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public GameObject player;
    //private Vector3 offset; //For distance between objects

    [SerializeField] private float _sensitivity;
    private float _rotaionX;
    private float _rotaionY;
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;
    private Vector3 _currentRotation;
    private Vector3 _smooth=Vector3.zero;

    [SerializeField] private float _smoothtime;

    //void Start()
    //{
        ////calculating distance b/w camera and players position
        //offset = transform.position - player.transform.position;
    //}
    void Update()
    {
        //Mouse Free Look
        float xx = Input.GetAxis("Mouse X") * _sensitivity;
        float yy = Input.GetAxis("Mouse Y") * _sensitivity;
        //transform.Rotate((yy*-1),xx,0);
        yy *= -1;
        //transform.eulerAngles += new Vector3(x:yy*-1,y:xx,z:0);
        _rotaionX += yy;
        _rotaionY += xx;

        _rotaionX = Mathf.Clamp(_rotaionX, -2, 45);
        //transform.Rotate(0,Input.GetAxis("Horizontal"),0);
        //Quaternion sett=new Quaternion();
        //sett.Set(transform.rotation.x,player.transform.rotation.y,transform.rotation.y,1);
        //transform.rotation = sett;
        Vector3 nextRotation = new Vector3(_rotaionX, _rotaionY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smooth, _smoothtime);
        transform.localEulerAngles = _currentRotation;
        
        transform.position = _target.position - transform.forward * _distance;
        //setting position of camera as same as player+offset
        //transform.position = player.transform.position + offset;
    }
}
