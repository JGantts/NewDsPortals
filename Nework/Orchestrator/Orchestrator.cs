using System.IO;
using Nework.EngineApi;
using System.Collections.ObjectModel;
using Nework.Orchestration.EngineHandlers;

namespace Nework.Orchestration
{
    internal static class Orchestrator
    {
        internal static ObservableCollection<WorldHandler> WorldHandlers { get; }
            = new ObservableCollection<WorldHandler>();

        static Orchestrator()
        {
            WorldHandlers.Add(new WorldHandler());
        }

        private static EngineConnection ConnectToWorld(DirectoryInfo worldDirectory)
        {
            return null;
        }
    }
}
