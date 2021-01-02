clean:
	rm -rf **/bin **/obj

restore:
	dotnet restore

build: restore
	dotnet build -warnaserror --no-restore

pack: check
	dotnet pack -c Release

check: clean build
	dotnet test --no-build --no-restore

all: build
