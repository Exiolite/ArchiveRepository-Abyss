using UnityEngine.Events;

namespace System.Gui
{
    public static class GuiEvent
    {
        public static readonly UpdateNavCircleResources UpdateNavCircleResources = new UpdateNavCircleResources();
        public static readonly OnZoomSliderChanged OnZoomSliderChanged = new OnZoomSliderChanged();
        
        public static readonly ShowMarket ShowMarket = new ShowMarket();
    }
    public class UpdateNavCircleResources : UnityEvent {}
    public class OnZoomSliderChanged : UnityEvent <float> {}
    
    public class ShowMarket : UnityEvent {}
}