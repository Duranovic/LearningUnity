using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    public Animator animator;    
    // Start is called before the first frame update    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateInOut()
    {
        animator.SetBool("MenuOut", true);
    }
    public void GoBack()
    {
        animator.SetBool("MenuOut", false);
    }
}
