### ThinkUnity

更多偏向UI的构建工程

基础UI架构设计，持续迭代更新。。

---

Assects目录结构：

```
|-- Resources                                   /资源目录
|-- Scenes                                      /场景目录
|-- Scripts                                     /脚本目录
    |-- Framework                               /框架入口目录
        |-- BaseObj                                /基类的目录
        |-- Common                                 /公共基类的目录
            |-- Singleton                              /用于存放单例基类的目录
        |-- Defines                                /定义状态目录
        |-- Manager                                /管理目录
    |-- Logic                                   /游戏逻辑模块
```

### UPDATE

X1.1.0

* BaseUI UI界面的基类，定义了统一的UI功能接口\(事件，开关，动画，声音...\)
* UIManager 管理UI的管理器，管理是否缓存UI对象，是否需要互斥UI对象，管理一些通用UI
* ResourceManager 资源管理器，资源加载统一管理，资源加载方式选择\(同步，异步，本地，AB，ObjPool...\)，资源缓存，资源释放
* Singleton 通用单例类的基类
* BaseModule 逻辑模块基类，定义模块的通用功能，处理不同系统的数据逻辑
* ModuleManager 逻辑模块管理器，管理游戏内所有逻辑的注册注销等
* 自定义事件系统 不同模块直接的通信，模块内界面和数据逻辑分离
* BaseScene 场景逻辑基类
* SceneManager 管理项目所有场景切换，加载。。
* CommonUI 项目中一些通用UI，继承BaseUI可重用UI，一个按钮，两个按钮，模态UI。。。。
* NetWork 如何在我们的框架中添加网络模块
* 属性系统设计，防作弊设计（内存修改）。

X1.0.0

* 规范Assets架构
* JsonBase基类的构建
* 基于HttpWebRequest类构建Get、Post请求服务端数据类RequestStoreBase
* C++Scoket网络基础类
* 构建siblings动态类
