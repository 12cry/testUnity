using Cry.Common;
using UnityEngine;

namespace testUnity {
    public class CameraRig : Singleton<CameraRig> {
        public Camera cacheCamera;
        public float screenEdgeThreshold;
        public float panSpeed = 4;
        public float minCameraX = 0;
        public float maxCameraX = 12;
        public float minCameraZ = 0;
        public float maxCameraZ = 5;

        protected override void Awake () {
            base.Awake ();
            cacheCamera = GetComponent<Camera> ();
            Debug.Log (cacheCamera.pixelWidth);
            Debug.Log (Screen.width);
        }

        public void init (int maxX, int maxZ) {
            cacheCamera.transform.position = new Vector3 (maxX / 2, cacheCamera.transform.position.y, maxZ / 2);
        }

        void Update () {
            // move();
        }

        void move () {
            Vector3 cameraPosition = cacheCamera.transform.position;
            Vector3 mousePosition = Input.mousePosition;
            Vector3 offset = Vector3.zero;
            if (cameraPosition.x >= minCameraX && mousePosition.x > -screenEdgeThreshold && mousePosition.x < screenEdgeThreshold) {
                offset = Vector3.left * Time.deltaTime * panSpeed;
            }

            if (cameraPosition.x <= maxCameraX && mousePosition.x > cacheCamera.pixelWidth - screenEdgeThreshold &&
                mousePosition.x < cacheCamera.pixelWidth + screenEdgeThreshold) {
                offset = Vector3.right * Time.deltaTime * panSpeed;
            }

            if (cameraPosition.z >= minCameraZ && mousePosition.y > -screenEdgeThreshold && mousePosition.y < screenEdgeThreshold) {
                offset = Vector3.back * Time.deltaTime * panSpeed;
            }

            if (cameraPosition.z <= maxCameraZ && mousePosition.y > cacheCamera.pixelHeight - screenEdgeThreshold &&
                mousePosition.y < cacheCamera.pixelHeight + screenEdgeThreshold) {
                offset = Vector3.forward * Time.deltaTime * panSpeed;
            }

            cacheCamera.transform.position = cameraPosition += offset;
        }
    }
}