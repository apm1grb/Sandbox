# Readme for xUnit Trait attribute spike

[[_TOC_]]

---

## Build the solution and run tests

1. Provision of **Paket** as a `dotnet` tool (partially necessary depending on the current installation status of **Paket**)
   - install **Paket** (globally or locally?)

     ```bash  
     `dotnet tool install paket --global`  
     `dotnet tool install paket --version 6.2.1`
     ```

1. Restore the NuGet dependencies

   ```bash
   dotnet paket restore
   ```

1. Compile the sources

   ```bash
   dotnet build ./src/Solution.sln
   ```

1. Execute the test with a dedicated `TestCase` trait (`TC2`)

   ```bash
   ./packages/tests/xunit.runner.console/tools/net472/xunit.console.exe ./src/ComponentOne/ComponentOne.Tests/bin/Debug/ComponentOne.Tests.dll -trait "TestCase=TC2"
   ```

---

## Some commands for backup

### Create a manifest for tools

If no `dotnet tool` is already installed a new empty tool-manifest must be created:

```bash
`dotnet new tool-manifest`
```

### Restore Paket as a tool

```bash
dotnet tool restore
```

### Add dependencies

To install a package (`xUnit`) into a dedicated project (`ComponentOne.Tests.csproj`) and dependency-group (`Tests`):

```bash
dotnet paket add xunit -p ./src/ComponentOne/ComponentOne.Tests/ComponentOne.Tests.csproj -g Tests
```
