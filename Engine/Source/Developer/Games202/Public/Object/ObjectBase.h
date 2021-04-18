#pragma once

#include "glad/glad.h"
#include <memory>

class UObjectBase
{
	friend std::shared_ptr<UObjectBase>;

public:

	// 创建完成
	virtual void BeginPlay();

	// 每帧刷新
	virtual void Tick(GLfloat dt);

	// 自身删除
	virtual void Destroy();

private: 
	UObjectBase& operator=(UObjectBase&&) = default;
	UObjectBase& operator=(const UObjectBase&) = default;

protected:
	UObjectBase() {};

	virtual ~UObjectBase() {};

};