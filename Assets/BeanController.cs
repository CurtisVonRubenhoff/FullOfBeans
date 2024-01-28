using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeanController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    [ContextMenu("surprised")]
    public void BeSurprised()
    {
        _animator.Play("surprised");
    }

    [ContextMenu("blush")]
    public void BeBlushing()
    {
        _animator.Play("blushing");
    }

    [ContextMenu("Default")]
    public void BeDefault()
    {
        _animator.Play("default");
    }

    public void SetMood(string mood)
    {
        switch (mood)
        {
            case "surprised":
                BeSurprised();
                break;
            case "blushing":
                BeBlushing();
                break;
            default:
                BeDefault();
                break;
        }
    }
}