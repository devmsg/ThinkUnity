using UnityEngine;
using System.Collections;
using System;

public abstract class BaseUI : MonoBehaviour
{

	private GameObject _cacheGameobject;
	/// <summary>
	/// 缓存游戏对象
	/// </summary>
	/// <value>The cache gameobject.</value>
	public GameObject cacheGameobject
	{
		get
		{
			if (_cacheGameobject == null)
			{
				_cacheGameobject = this.gameObject;
			}
			return _cacheGameobject;
		}
	}

	private Transform _cacheTransform;
	/// <summary>
	/// 缓存transform组件
	/// </summary>
	/// <value>The cache transform.</value>
	public Transform cacheTransform
	{
		get
		{
			if (_cacheTransform == null)
			{
				_cacheTransform = this.transform;
			}
			return _cacheTransform;
		}
	}

	#region EunmObjectState & UI type
	protected EunmObjectState _state = EunmObjectState.None;
	public event StateChangeEvent StateChanged;
	/// <summary>
	/// Gets or sets the state.
	/// </summary>
	/// <value>The state.</value>
	public EunmObjectState State
	{ 
		get {
			return this._state;
		}
		set {
			EunmObjectState oldState = this._state;
			this._state = value;
			if (StateChanged != null)
			{
				StateChanged(this,this._state,oldState);
			}
		}
	}

	/// <summary>
	/// Gets the UI Type.
	/// </summary>
	/// <returns>The UI Type.</returns>
	public abstract EunmUIType GetUIType();
	#endregion

	void Awake()
	{
		this.State = EunmObjectState.Init;
		OnAwake();
	}

	// Use this for initialization
	void Start()
	{
		OnStart();
	}




	// Update is called once per frame
	void Update()
	{
		if (this._state == EunmObjectState.Ready)
		{
			OnUpdate(Time.deltaTime);
		}
	}

	/// <summary>
	/// 释放UI对象
	/// </summary>
	void Release() {
		this.State = EunmObjectState.Closing;
		Destroy(this.cacheGameobject);
		OnRelease();
	}

	void OnDestroy() {
		this.State = EunmObjectState.None;
	}


	protected virtual void OnStart() { }
	protected virtual void OnAwake() {
		this.State = EunmObjectState.Loading;
		this.OnPlayOpenUIAudio();
	}


	protected virtual void OnUpdate(float deltaTime) { }

	protected virtual void OnRelease() { 
		this.State = EunmObjectState.None;
		this.OnPlayCloseUIAudio();
	}

	/// <summary>
	/// 打开界面播放音乐
	/// </summary>
	/// <returns>The play open UI Audio.</returns>
	protected virtual void OnPlayOpenUIAudio() { }
	/// <summary>
	/// 关闭界面播放音乐
	/// </summary>
	/// <returns>The play close UI Audio.</returns>
	protected virtual void OnPlayCloseUIAudio(){ }

	/// <summary>
	/// 通过setui方法loading 动画
	/// </summary>
	/// <returns>The user interface.</returns>
	/// <param name="UIArray">UIA rray.</param>
	protected virtual void SetUI(params object[] UIArray) {
		this.State = EunmObjectState.Loading;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <returns>The UI When opening.</returns>
	/// <param name="UIArray">UI Array.</param>
	public void SetUIWhenOpening(params object[] UIArray) {
		SetUI(UIArray);
		StartCoroutine(LoadDataAsyn());
	}

	IEnumerator LoadDataAsyn() {
		yield return new WaitForSeconds(0);
		if (this.State == EunmObjectState.Loading)
		{
			this.OnLoadData();
			this.State = EunmObjectState.Ready;
		}
	}

	/// <summary>
	/// 加载数据的逻辑处理方法
	/// </summary>
	/// <returns>The load data.</returns>
	protected virtual void OnLoadData() { }
	 

}



