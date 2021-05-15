namespace ZwiftSteero.Ble.Advertisement
{
    public enum GattProperty
    {
        Broadcast = 1,
        Read = 2,
        WriteNoResponse = 4,
        Write = 8,
        Notify = 16,
        Indicate = 32,
        SignedWrite = 64,
        ExtendedProps = 128
    }
}