using System;

namespace ZwiftSteero.Ble.Advertisement
{
    [Flags]
    public enum AttributeType
    {
        ServiceDeclaration = 0x2800,
        CharacteristicDeclaration = 0x2803,
        DescriptorDeclaration = 0x2902
    }
}
