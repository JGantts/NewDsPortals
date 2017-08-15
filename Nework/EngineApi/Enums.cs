namespace Nework.EngineApi
{

    public enum ParamaterlessCommandType
    {
        Portal_TurnOn,
        Portal_TurnOff,
        Portal_Ping,
    }

    public enum ParamateredCommandType
    {
        Portal_Import,
        Portal_SetId,
        Portal_SetName,

        Portal_SetRed,
        Portal_SetGreen,
        Portal_SetBlue,
        Portal_SetRotation,
        Portal_SetSwap,
    }

    public enum ParameterlessMessegeType
    {
        Portal_TurnedOn,
        Portal_TurnedOff,
        Portal_PingReply,
        Portal_WorldLoaded,
    }

    public enum ParameteredMessegeType
    {
        Portal_Imported,
        Portal_Exported,
        Portal_NameSet,

        Portal_RedSet,
        Portal_GreenSet,
        Portal_BlueSet,
        Portal_RotationSet,
        Portal_SwapSet,
    }
}
