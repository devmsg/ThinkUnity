using UnityEngine;
using System.Collections;
using System;

public delegate void StateChangeEvent(object ui,EunmObjectState NewState, EunmObjectState oldState);

public enum EunmObjectState {
	None, //未知状态
	Init, //初始化
	Loading, // 加载中
	Ready, // 加载完毕
	Disabled, // 清除
	Closing  // 关闭
}

public enum EunmUIType{
	None = -1,
	TextOne = 0,
	TextTwo = 1
}

public class Defines
{
}
