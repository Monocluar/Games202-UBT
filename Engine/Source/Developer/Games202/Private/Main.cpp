
#include "Launch/LaunchBase.h"


class Launch : public LaunchBase
{
public:
	Launch() :LaunchBase()
	{};

	virtual ~Launch() override
	{
	};


protected:
	virtual void BeginPlay() override
	{
	}


	virtual void Tick(GLfloat dt) override
	{
	}


	virtual void Destroy() override
	{
	}

};


int main(int argc, char* argv[])
{

	std::shared_ptr<Launch> LaunchPtr = std::make_shared<Launch>();

	GLaunch = LaunchPtr;


	return LaunchPtr->Run();
}
