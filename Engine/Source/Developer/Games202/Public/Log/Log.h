#pragma once
#include <iostream>


#define GAME_LOG(CategoryName , Verbosity ,Format) \
{  \
	std::cout << Verbosity << ",  " << CategoryName << ",  " << Format<< std::endl;  \
}