#pragma once

#include "glad/glad.h"
#include <memory>
#include <winerror.h>

using namespace std;
using namespace glm;

struct GLFWwindow;
struct vec;

class LaunchBase
{

public:

	LaunchBase();

	virtual ~LaunchBase();

	FORCEINLINE vec2 GetWindowViewSize() { return ViewSize; };

	FORCEINLINE GLchar* GetWindowName() { return GameName; };

	FORCEINLINE vec2 GetMousePos() { return MousePos; };

public:

	int Run();

private:
	LaunchBase& operator=(LaunchBase&&) = default;
	LaunchBase& operator=(const LaunchBase&) = default;


protected:
	// 键盘输入函数
	static void KeyCallBack(GLFWwindow* Window, int Key, int Acancode, int Action, int Mods);

	// 鼠标位置响应事件
	static void MouseMove(GLFWwindow* Window, double XPos, double YPos);

	// 鼠标滚轮响应事件
	static void MouseWheel(GLFWwindow* Window, double XPos, double YPos);

	// 鼠标点击事件
	static void MouseButtonCallback(GLFWwindow* Window, int Key, int Action, int Mods);

protected:
	// 初始化
	virtual void Init() {};

	// 创建完成
	virtual void BeginPlay() {};

	// 每帧刷新
	virtual void Tick(GLfloat dt) {};

	// 自身删除
	virtual void Destroy() {};

protected:
	// 键盘输入
	virtual void OnProcessInput(int Key,int Action) {};

	// 鼠标移动
	virtual void OnMouseMove(vec2 Pos) {};

	// 鼠标滚轮
	virtual void OnMouseWheel(vec2 Pos) {};

	// 鼠标按下
	virtual void OnMouseButtonDown(vec2 Pos) {};

	// 鼠标回弹
	virtual void OnMouseButtonUp(vec2 Pos) {};

private:
	// 游戏窗口大小
	vec2 ViewSize;

	// 名称
	GLchar* GameName;

	// 窗口管理
	GLFWwindow* GWindow;

	// 记录鼠标位置
	vec2 MousePos;

};

static shared_ptr<LaunchBase> GLaunch;