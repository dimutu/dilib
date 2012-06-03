

#include "DiParser.h"

//using namespace dim::DiParser;

int main(int argc, char** argv)
{
	DiLib::DiParser p;

	if (argc == 3)
	{
		p.GenerateFiles(argv[1], argv[2]);
	}

	return 0;
}
