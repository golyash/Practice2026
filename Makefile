all: test

build:
	dotnet build

test:
	dotnet test $(task)

clean:
	dotnet clean