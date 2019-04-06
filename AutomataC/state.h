#pragma once

#include <string>
#include <map>

struct State
{
	std::string name;
	bool isEnd;
	bool isStart;
	std::map<char, std::string> conditions;
};
