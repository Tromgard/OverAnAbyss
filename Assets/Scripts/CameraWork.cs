using UnityEngine;



    public class CameraWork : MonoBehaviour
    {
       public Transform target;
      
        private void LateUpdate()
        {
            transform.position = new Vector3(target.position.x, target.position.y+10, target.position.z-10);
           
        }
      
    }
