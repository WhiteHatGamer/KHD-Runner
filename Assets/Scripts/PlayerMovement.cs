using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed=5.0f;
    //float smooth = 5.0f;
    float tiltAngle;
    [SerializeField] GameObject Wheell;
    [SerializeField] GameObject Wheelr;
    [SerializeField] public bool jetpack;
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float j = Input.GetAxis("Jump");
        float h = Input.GetAxis("Horizontal");

        //transform.Translate(h * Time.deltaTime * speed ,0,0, Space.World);
        transform.Translate( 0, 0, v * Time.deltaTime * speed, Space.World);
        Vector3 pos = transform.position;
        tiltAngle += h;
        tiltAngle = Mathf.Clamp(tiltAngle, -40,40);
        Vector3 _WheelRot = new Vector3(0,tiltAngle,-90);
        //rot = Quaternion.Slerp(Quaternion.Euler(-90, 0, h * tiltAngle), rot, Time.deltaTime * smooth);;
        //transform.Rotate(0,0,h*tiltAngle); - For Car Rotation
        Wheell.transform.localEulerAngles = _WheelRot;
        Wheelr.transform.localEulerAngles = _WheelRot;
        //transform.rotation=Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * smooth);
        if (jetpack)
        {
            pos.y += j * 10 * Time.deltaTime;
        }
        else
        {
            pos.y += j * 5 * Time.deltaTime;
        }
        
        transform.position=pos;
    }
}