using UnityEngine;

public class ClassCharacter : MonoBehaviour
{
    public float alpha = 0f;
    public float speed = 2f;
    public float distance = 5f;
    public Vector3 origin;

    private void Start()
    {
        alpha = 0.5f;
        origin = transform.position;
    }

    private void Update()
    {
        Move();
    }

    public virtual void Move(){}
}
