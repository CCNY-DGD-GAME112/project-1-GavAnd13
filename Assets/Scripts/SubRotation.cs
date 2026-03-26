using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SubRotation : MonoBehaviour
{
    public Transform sub;
    public float rotationBound;
    public float speed;

    void Update()
    {
        if (rotationBound < sub.rotation.z || -rotationBound > sub.rotation.z)
        {
            speed *= -1;
            Debug.Log(":)");
        }
        sub.Rotate(0, 0, speed);
    }
}
