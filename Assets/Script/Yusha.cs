//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public Transform target; // 追従するプレイヤーのTransform
//    public float smoothness = 0.125f; // 追従の滑らかさ（小さいほどゆっくり）
//    public Vector3 offset = new Vector3(0, 0, -10); // カメラのズーム位置（Z軸は-10固定が基本）

//    void LateUpdate() // カメラの移動は通常のUpdateより後のLateUpdateで行うのが定石
//    {
//        if (target != null)
//        {
//            // プレイヤーの位置にオフセットを加えた目標地点を計算
//            Vector3 desiredPosition = target.position + offset;
//            // 現在地から目標地点へ滑らかに移動させる
//            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothness);
//            transform.position = smoothedPosition;
//        }
//    }
//}