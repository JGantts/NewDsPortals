using System.IO;
using Nework.EngineApi;
using System.Collections.ObjectModel;
using Nework.Orchestration.EngineHandlers;

namespace Nework.Orchestration
{
    internal static class Orchestrator
    {
        internal static WorldHandler WorldHandler { get; private set; }


        static Orchestrator()
        { }

        internal static WorldHandler ConnectToWorld(DirectoryInfo worldDirectory)
        {
            return WorldHandler = new WorldHandler(worldDirectory);
        }
    }
}
