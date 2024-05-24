using UnityEngine;
public class AnimateAxe : MonoBehaviour
{
    Animator anim;
    public AnimationClip[] axeSwing;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
        
    }
}
