using UnityEngine;
public abstract class Singleton<T> where T : class,new()
{
	protected static T _Instance = null;

	public static T Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new T();
			}
			return _Instance;
		}
	}

	protected Singleton() {
		init();
	}

	public virtual void init() {

	}
}
