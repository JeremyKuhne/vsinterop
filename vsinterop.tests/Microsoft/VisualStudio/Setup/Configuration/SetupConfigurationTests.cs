// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Variant;

namespace Microsoft.VisualStudio.Setup.Configuration;

public unsafe class SetupConfigurationTests
{
    [Fact]
    public void CanCreateSetupConfigurationFactory()
    {
        using ComClassFactory factory = new(CLSID.SetupConfiguration);
    }

    [Fact]
    public void CanCreateISetupConfiguration2Instance()
    {
        using ComClassFactory factory = new(CLSID.SetupConfiguration);
        using var setupConfig = factory.CreateInstance<ISetupConfiguration2>();
        Assert.False(setupConfig.IsNull);
    }

    [Fact]
    public void EnumInstances()
    {
        using ComClassFactory factory = new(CLSID.SetupConfiguration);
        using var setupConfig = factory.CreateInstance<ISetupConfiguration2>();

        using ComScope<IEnumSetupInstances> enumInstances = default;
        setupConfig.Pointer->EnumInstances(enumInstances).ThrowOnFailure();
        Assert.False(enumInstances.IsNull);

        using ComScope<ISetupInstance> setupInstance = default;
        uint fetched;
        HRESULT result;

        result = enumInstances.Pointer->Next(1, setupInstance, &fetched);

        using BSTR displayName = default;
        setupInstance.Pointer->GetDisplayName(0, &displayName).ThrowOnFailure();
        string name = displayName.ToString();
        Assert.NotEmpty(name);
    }

    [Fact]
    public void SetupInstance2_PropertyStore()
    {
        using ComClassFactory factory = new(CLSID.SetupConfiguration);
        using var setupConfig = factory.CreateInstance<ISetupConfiguration2>();

        using ComScope<IEnumSetupInstances> enumInstances = default;
        setupConfig.Pointer->EnumInstances(enumInstances).ThrowOnFailure();

        using ComScope<ISetupInstance> setupInstance = default;
        uint fetched;
        enumInstances.Pointer->Next(1, setupInstance, &fetched).ThrowOnFailure();

        using ComScope<ISetupInstance2> setupInstance2 = setupInstance.QueryInterface<ISetupInstance2>();

        using ComScope<ISetupPropertyStore> properties = default;
        setupInstance2.Pointer->GetProperties(properties).ThrowOnFailure();

        using SafeArrayScope<BSTR> namesArray = default;
        properties.Pointer->GetNames(namesArray).ThrowOnFailure();

        Assert.True(namesArray.Length > 0, "There are names.");
        using BSTR name = namesArray[0];
        Assert.False(name.IsNull, "Name is not null");

        using VARIANT value = default;
        properties.Pointer->GetValue(name.Value, &value).ThrowOnFailure();
    }
}
