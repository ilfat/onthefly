using MvvmCross.Plugin.Messenger;
using System.Collections.Generic;

namespace OnTheFly.Core.ViewModels
{
    public class CreateMarkersMessage : MvxMessage
    {
        public IEnumerable<Marker> Markers { get; protected set; }

        public CreateMarkersMessage(object sender, IEnumerable<Marker> markers): base(sender)
        {
            this.Markers = markers;
        }
    }
}