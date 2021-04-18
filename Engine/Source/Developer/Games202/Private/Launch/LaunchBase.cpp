
#include <iostream>
#include <glad\glad.h>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
#include "GLFW/glfw3.h"

#include "Launch/LaunchBase.h"
#include "Log/Log.h"


LaunchBase::~LaunchBase()
{
	Destroy();
}

int LaunchBase::Run()
{
	glfwInit();
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);


	GWindow = glfwCreateWindow(ViewSize.x, ViewSize.y, GameName, nullptr, nullptr);


	if (GWindow == nullptr)
	{
		cout << "创建窗口失败" << endl;
		glfwTerminate();
		return -1;
	}

	// 设置当前窗口
	glfwMakeContextCurrent(GWindow);


	// 初始化GLAD
	if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
	{
		std::cout << "无法初始化GLAD" << std::endl;
		return -1;
	}


	glEnable(GL_DEPTH_TEST);
	/*glDepthFunc(GL_LESS);
	glEnable(GL_STENCIL_TEST);
	glStencilFunc(GL_NOTEQUAL, 1, 0xFF);
	glStencilOp(GL_KEEP, GL_KEEP, GL_REPLACE);*/

	// 注册键盘回调函数
	glfwSetKeyCallback(GWindow, KeyCallBack);

	// 注册鼠标移动回调函数
	glfwSetCursorPosCallback(GWindow, MouseMove);

	// 注册鼠标滚轮回调函数
	glfwSetScrollCallback(GWindow, MouseWheel);

	// 注册鼠标点击回调函数
	glfwSetMouseButtonCallback(GWindow, MouseButtonCallback);

	// 记录时间变量
	GLfloat DeltaTime = 0.f;
	GLfloat LastFrame = 0.f;

	BeginPlay();

	// 设置背景颜色和颜色缓冲
	glClearColor(0.1f, 0.1f, 0.1f, 0.5f);


	// 每帧渲染窗口信息
	while (!glfwWindowShouldClose(GWindow))
	{
		// 获取增量时间
		GLfloat CurrentFrame = (GLfloat)glfwGetTime();
		DeltaTime = CurrentFrame - LastFrame;
		LastFrame = CurrentFrame;

		Tick(DeltaTime);

		glClear(GL_COLOR_BUFFER_BIT);

		glfwSwapBuffers(GWindow);
		glfwPollEvents();
	}

	Destroy();

	glfwTerminate();

	return 0;
}

LaunchBase::LaunchBase()
	: ViewSize(vec2(800,512))
	, GameName("Games202")
	, MousePos(vec2(0.f))
{
	Init();
}


void LaunchBase::KeyCallBack(GLFWwindow* Window, int Key, int Acancode, int Action, int Mods)
{

	// 当用户按下Esc键时，关闭窗口
	if (Key == GLFW_KEY_ESCAPE && Acancode == GLFW_PRESS)
	{
		glfwSetWindowShouldClose(Window, GL_TRUE);
	}
	if (Key > 0 && Key < 1024)
	{
		if (!GLaunch)
		{
			GAME_LOG("LaunchBase", "Erorr", "没有获取到静态全局变量GLaunch");
			return;
		}
		GLaunch->OnProcessInput(Key, Action);
	}
}

void LaunchBase::MouseMove(GLFWwindow* Window, double XPos, double YPos)
{
	if (!GLaunch)
	{
		GAME_LOG("LaunchBase", "Erorr", "没有获取到静态全局变量GLaunch");
		return;
	}
	GLaunch->MousePos = vec2(XPos, YPos);
	GLaunch->OnMouseMove(vec2(XPos, YPos));
}

void LaunchBase::MouseWheel(GLFWwindow* Window, double XPos, double YPos)
{
	if (!GLaunch)
	{
		GAME_LOG("LaunchBase", "Erorr", "没有获取到静态全局变量GLaunch");
		return;
	}
	GLaunch->OnMouseWheel(vec2(XPos, YPos));
}

void LaunchBase::MouseButtonCallback(GLFWwindow* Window, int Key, int Action, int Mods)
{
	if (Action == GLFW_PRESS)
	{
		if (GLaunch)
		{
			GLaunch->OnMouseButtonDown(GLaunch->GetMousePos());
		}
	}
	else 
	{
		if (GLaunch)
		{
			GLaunch->OnMouseButtonUp(GLaunch->GetMousePos());
		}
	}
}

