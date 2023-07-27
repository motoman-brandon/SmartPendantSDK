if [ ! -d gen-csharp ]; then
  thrift -r --gen csharp ../extension.thrift
fi
dotnet build SDK.csproj /t:build
