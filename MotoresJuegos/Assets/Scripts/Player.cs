using UnityEngine;

public class Player : ClassCharacter
{
    public string axisName;
    public Vector3 direction;

    public override void Move()
    {
        alpha += Input.GetAxis(axisName) * Time.deltaTime * speed;
        alpha = Mathf.Clamp01(alpha);

        transform.position = Vector3.Lerp(
            origin + direction * -distance, 
            origin + direction * distance,
            alpha);
    }
}
