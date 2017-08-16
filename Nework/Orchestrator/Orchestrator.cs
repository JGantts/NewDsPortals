using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nework.EngineApi;
using System.Diagnostics;
using Nework.Orchestration.Model;

namespace Nework.Orchestration
{
    public static class Orchestrator
    {
        public static IWorldModel World => m_World;
        private static IWorldModel m_World { get; } = new WorldModel();

        static Orchestrator()
        {
            /*
                EngineConnection game = new EngineConnection(new DirectoryInfo(""));
                game.MessageEvent += (object sender, IMessageEventArgs a) =>
                {
                    IParameterlessMessageEventArgs lessArgs = a as IParameterlessMessageEventArgs;
                    IParameteredMessageEventArgs edArgs = a as IParameteredMessageEventArgs;
                    if(lessArgs != null)
                    {
                        Debug.Assert(edArgs == null);

                    }else if (edArgs != null){
                        Debug.Assert(lessArgs == null);

                    }
                    else
                    {
                        throw new OrchestrationException("Internal error");
                    }
                };

                //m_Game.SendCommand(0, blarg, "")*/
        }

        private static EngineConnection ConnectToWorld(DirectoryInfo worldDirectory)
        {
            return null;
        }
    }
}
