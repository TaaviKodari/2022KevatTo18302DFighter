using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    public void SetCamera(GameObject p1, GameObject p2){
        GetComponent<CinemachineTargetGroup>().AddMember(p1.transform,1,0);
        GetComponent<CinemachineTargetGroup>().AddMember(p2.transform,1,0);
    }
}
