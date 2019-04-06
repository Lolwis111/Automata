#include "state.h"
#include <vector>
#include <string>
#include <iostream>
#include <fstream>
#include <sstream>
#include <io.h>
#include <map>

std::vector<std::string> split(std::string s, char delim);
int main(int argc, char **argv);

int main(int argc, char **argv)
{
	std::string input;

	if (argc > 1)
	{
		input = argv[1];
	}
	else
	{
		std::cout << "File: ";
		std::cin >> input;
	}

	if (_access(input.c_str(), 0) == -1)
	{
		std::cout << "File not found!" << std::endl;

		return 1;
	}

	std::ifstream file(input.c_str());
	std::string line, alphabet;
	std::vector<State> states;

	bool hasStart = false, hasEnd = false;
	register unsigned int i = 0, j = 0;

	if (std::getline(file, line) && line[0] == 'A')
	{
		size_t aStart = line.find("{");
		size_t aEnd = line.find("}");

		alphabet = line.substr(aStart + 1, aEnd - aStart - 1);
	}
	else
	{
		std::cout << "Kein Alphabet angegeben!" << std::endl;

		return 1;
	}

	while (std::getline(file, line))
	{
		char e1 = line.c_str()[line.size() - 1];
		char e2 = line.c_str()[line.size() - 2];

		size_t cStart = line.find("{");
		size_t cEnd = line.find("}");

		std::string name = line.substr(0, cStart);
		std::string args = line.substr(cStart + 1, cEnd - cStart - 1);

		std::vector<std::string> conds = split(args, ';');

		bool start = false, end = false;

		if (e1 == 'E' || e2 == 'E')
			hasEnd = end = true;

		if (e1 == 'S' || e2 == 'S')
			hasStart = start = true;

		State state;
		state.name = name;
		state.isEnd = end;
		state.isStart = start;

		std::map<char, std::string> conditions;
		for(i = 0; i < conds.size(); i++)
		{
			std::vector<std::string> segs = split(conds[i], ',');

			char character = segs[0].substr(1, 1).c_str()[0];
			std::string fName = segs[1].substr(0, segs[1].length() - 1);

			std::pair<std::map<char, std::string>::iterator, bool> ret;
			ret = conditions.insert(std::pair<char, std::string>(character, fName));

			if (ret.second == false)
			{
				std::cout << std::endl << "Automat ist kein DFA und kann nicht simuliert werden!" << std::endl;

				return 1;
			}

			state.conditions = conditions;
		}

		states.push_back(state);
	}

	file.close();

	if (!(hasEnd && hasStart))
	{
		std::cout << std::endl << "Automat ist kein DFA und kann nicht simuliert werden!";
		std::cout << std::endl << "Kein Start oder kein Ende!" << std::endl;

		return 1;
	}

	std::map<char, std::string>::iterator it;
	for (i = 0; i < states.size(); i++)
	{
		for (it = states[i].conditions.begin(); it != states[i].conditions.end(); ++it)
		{
			std::string name = it->second;

			bool found = false;
			for (j = 0; j < states.size(); j++)
			{	
				if (states[j].name == name)
					found = true;
			}


			if (!found)
			{
				std::cout << std::endl << "Der Automat ist fehlerhaft!" << std::endl;

				return 1;
			}
		}
	}

	std::cout << std::endl << "M = (Z,Σ,δ,q0,E)" << std::endl;
	std::cout << "Σ = {";

	for (i = 0; i < alphabet.length(); i++)
	{
		std::cout << alphabet[i] << ",";
	}

	std::cout << "\b}" << std::endl << "OK." << std::endl;

	while (true)
	{
		register unsigned int stateIndex = 0;
		for (i = 0; i < states.size(); i++)
		{
			if (states[i].isStart)
			{
				stateIndex = i;
				break;
			}
		}

		std::cout << "Input: ";
		std::string input;
		std::cin >> input;

		bool valid = true;

		for (i = 0; i < input.size(); i++)
		{
			if (alphabet.find(input[i]) != std::string::npos)
			{

			
			}
			else
			{
				std::cout << std::endl << "Das Zeichen '" << input[i] << "' gehört nicht zum Alphabet!" << std::endl;

				valid = false;

				break;
			}
		}

		if (states[stateIndex].isEnd && valid)
			std::cout << "Das Wort wurde akzeptiert." << std::endl << std::endl;
		else
			std::cout << "Das Wort wurde nicht akzeptiert." << std::endl << std::endl;
	}

	return 0;
}

std::vector<std::string> split(std::string s, char delim)
{
	std::stringstream ss(s);
	std::string item;
	std::vector<std::string> elems;
	while (getline(ss, item, delim))
	{
		elems.push_back(item);
	}


	return elems;
}