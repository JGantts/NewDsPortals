namespace Nework.EngineApi
{

    public enum CommandType
    {
        Portal_TurnOn,
        Portal_TurnOff,
        Portal_Ping,

        Portal_Import,
        Portal_SetId,
        Portal_SetName,

        Portal_SetRed,
        Portal_SetGreen,
        Portal_SetBlue,
        Portal_SetRotation,
        Portal_SetSwap,
    }

    public enum MessegeType
    {
        MessageHandler_New,
        CommandHandler_New,
        Portal_New,

        Portal_ExecutedCommand,
        Portal_Exported,
        Portal_Imported,
        Portal_DidntImport,
        Portal_Opened,
        Portal_Closed,
        Portal_WorldLoaded,

        /*Portal_Opened,
        Portal_Closed,

        Portal_TurnedOn,
        Portal_TurnedOff,
        Portal_PingReply,

        Portal_Imported,
        Portal_Exported,
        Portal_NameSet,

        Portal_RedSet,
        Portal_GreenSet,
        Portal_BlueSet,
        Portal_RotationSet,
        Portal_SwapSet,*/
    }
}
