using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
	public static AnimatorPlayer instance;

	private void Awake()
	{
		instance = this;
	}

	public void PlayAnimation(Animator _anim, string _animationName)
	{
		_anim.Play(_animationName);
	}

	public void SetAnimationBool(Animator _anim, string _boolName, bool _isActive)
	{
		_anim.SetBool(_boolName, _isActive);
	}	
}