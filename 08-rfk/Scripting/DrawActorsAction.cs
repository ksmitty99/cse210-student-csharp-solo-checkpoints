using System.Collections.Generic;
using _08_rfk.Casting;
using _08_rfk.Services;


namespace _08_rfk.Scripting
{
    public class DrawActorsAction : Action
    {
        OutputService _outputService = new OutputService();
        public void DrawActorsAction(OutputService outputService)
        {
            _outputService = outputService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {

            _outputService.StartDrawing();

            foreach (List<Actor> group in cast.Values)
            {
                _outputService.DrawActors(group);   
            }
            _outputService.EndDrawing();
        }
    }
}