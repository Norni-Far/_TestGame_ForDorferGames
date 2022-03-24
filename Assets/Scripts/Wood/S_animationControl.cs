using UnityEngine;

public class S_animationControl : MonoBehaviour
{
    [SerializeField] private Animator woodAnim;
    public void SetSmallScaleForAnim() => transform.localScale = new Vector3(0.1f, 0.1f, 1);

    public void OnAnimation()
    {
        woodAnim.SetBool("onStartGame", true);
    }

    public void OffAnimation()
    {
        woodAnim.SetBool("onStartGame", false);
    }
}
