// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using Windows.Win32.Foundation;
using Windows.Win32.System.Com;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

[TestClass]
public unsafe class DiaSourceTests
{
    private static string TestPdbPath => Path.ChangeExtension(typeof(DiaSourceTests).Assembly.Location, ".pdb");

    [TestMethod]
    public void CanCreateDiaSourceFactory()
    {
        using ComClassFactory factory = Msdia.CreateFactory(CLASSID.DiaSource);
        Assert.AreEqual(CLASSID.DiaSource, factory.ClassId);
    }

    [TestMethod]
    public void CanCreateIDiaDataSource()
    {
        using ComClassFactory factory = Msdia.CreateFactory(CLASSID.DiaSource);
        using var dataSource = factory.CreateInstance<IDiaDataSource>();
        Assert.IsFalse(dataSource.IsNull);
    }

    [TestMethod]
    public void LoadDataFromPdb_NonExistentPath_Fails()
    {
        using ComClassFactory factory = Msdia.CreateFactory(CLASSID.DiaSource);
        using var dataSource = factory.CreateInstance<IDiaDataSource>();

        string missing = Path.Combine(AppContext.BaseDirectory, "this_file_does_not_exist.pdb");

        HRESULT result;
        fixed (char* path = missing)
        {
            result = dataSource.Pointer->loadDataFromPdb(path);
        }

        Assert.IsTrue(result.Failed, "Loading a missing PDB returns a failure HRESULT.");
    }

    [TestMethod]
    public void LoadDataFromPdb_OpenSession_GlobalScopeIsExe()
    {
        using ComClassFactory factory = Msdia.CreateFactory(CLASSID.DiaSource);
        using var dataSource = factory.CreateInstance<IDiaDataSource>();

        LoadTestData(dataSource);

        using ComScope<IDiaSession> session = default;
        dataSource.Pointer->openSession(session).ThrowOnFailure();
        Assert.IsFalse(session.IsNull);

        using ComScope<IDiaSymbol> globalScope = default;
        session.Pointer->get_globalScope(globalScope).ThrowOnFailure();
        Assert.IsFalse(globalScope.IsNull);

        uint symTag;
        globalScope.Pointer->get_symTag(&symTag).ThrowOnFailure();
        Assert.AreEqual((uint)SymTagEnum.SymTagExe, symTag);
    }

    [TestMethod]
    public void GlobalScope_HasSymbolName()
    {
        using ComClassFactory factory = Msdia.CreateFactory(CLASSID.DiaSource);
        using var dataSource = factory.CreateInstance<IDiaDataSource>();

        LoadTestData(dataSource);

        using ComScope<IDiaSession> session = default;
        dataSource.Pointer->openSession(session).ThrowOnFailure();

        using ComScope<IDiaSymbol> globalScope = default;
        session.Pointer->get_globalScope(globalScope).ThrowOnFailure();

        using BSTR name = default;
        globalScope.Pointer->get_name(&name).ThrowOnFailure();
        Assert.IsFalse(name.IsNull, "The global (exe) symbol has a name.");
    }

    [TestMethod]
    public void FindChildren_EnumeratesCompilands()
    {
        using ComClassFactory factory = Msdia.CreateFactory(CLASSID.DiaSource);
        using var dataSource = factory.CreateInstance<IDiaDataSource>();

        LoadTestData(dataSource);

        using ComScope<IDiaSession> session = default;
        dataSource.Pointer->openSession(session).ThrowOnFailure();

        using ComScope<IDiaSymbol> globalScope = default;
        session.Pointer->get_globalScope(globalScope).ThrowOnFailure();

        using ComScope<IDiaEnumSymbols> compilands = default;
        globalScope.Pointer->findChildren(
            SymTagEnum.SymTagCompiland,
            name: default,
            compareFlags: 0,
            compilands).ThrowOnFailure();
        Assert.IsFalse(compilands.IsNull);

        int count;
        compilands.Pointer->get_Count(&count).ThrowOnFailure();
        Assert.IsTrue(count > 0, "The module has at least one compiland.");

        using ComScope<IDiaSymbol> compiland = default;
        uint fetched;
        compilands.Pointer->Next(1, compiland, &fetched).ThrowOnFailure();
        Assert.AreEqual(1u, fetched);

        uint symTag;
        compiland.Pointer->get_symTag(&symTag).ThrowOnFailure();
        Assert.AreEqual((uint)SymTagEnum.SymTagCompiland, symTag);
    }

    [TestMethod]
    public void GetEnumTables_ReturnsTables()
    {
        using ComClassFactory factory = Msdia.CreateFactory(CLASSID.DiaSource);
        using var dataSource = factory.CreateInstance<IDiaDataSource>();

        LoadTestData(dataSource);

        using ComScope<IDiaSession> session = default;
        dataSource.Pointer->openSession(session).ThrowOnFailure();

        using ComScope<IDiaEnumTables> tables = default;
        session.Pointer->getEnumTables(tables).ThrowOnFailure();
        Assert.IsFalse(tables.IsNull);

        int count;
        tables.Pointer->get_Count(&count).ThrowOnFailure();
        Assert.IsTrue(count > 0, "A session exposes at least one table.");
    }

    private static void LoadTestData(ComScope<IDiaDataSource> dataSource)
    {
        string pdbPath = TestPdbPath;
        Assert.IsTrue(File.Exists(pdbPath), $"Test PDB not found at '{pdbPath}'.");

        fixed (char* path = pdbPath)
        {
            dataSource.Pointer->loadDataFromPdb(path).ThrowOnFailure();
        }
    }
}
