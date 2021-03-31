#include <glad\glad.h>

#include <GLFW\glfw3.h>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include <iostream>


using namespace std;

// 键盘输入函数
void OnKeyCallBack(GLFWwindow* window, int key, int scancode, int action, int mode);

// 窗口宽度
const GLuint SCREEN_WIDTH = 800;
// 窗口高度
const GLuint SCREEN_HEIGHT = 512;


int main(int argc, char* argv[])
{
	glfwInit();
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);

	GLFWwindow* Window = glfwCreateWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "Games202", nullptr, nullptr);

	if (Window == NULL)
	{
		cout << "创建窗口失败" << endl;
		glfwTerminate();
		return -1;
	}

	// 设置当前窗口
	glfwMakeContextCurrent(Window);

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
	glfwSetKeyCallback(Window, OnKeyCallBack);

	// 记录时间变量
	GLfloat DeltaTime = 0.f;
	GLfloat LastFrame = 0.f;


	// 设置背景颜色和颜色缓冲
	glClearColor(0.1f, 0.1f, 0.1f, 0.5f);

	// 每帧渲染窗口信息
	while (!glfwWindowShouldClose(Window))
	{
		// 获取增量时间
		GLfloat CurrentFrame = (GLfloat)glfwGetTime();
		DeltaTime = CurrentFrame - LastFrame;
		LastFrame = CurrentFrame;

		glClear(GL_COLOR_BUFFER_BIT);

		glfwSwapBuffers(Window);
		glfwPollEvents();
	}

	glfwTerminate();
}

void OnKeyCallBack(GLFWwindow* window, int key, int scancode, int action, int mode)
{
	// 当用户按下Esc键时，关闭窗口
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
	{
		glfwSetWindowShouldClose(window, GL_TRUE);
	}
	if (key > 0 && key < 1024)
	{

	}
}
