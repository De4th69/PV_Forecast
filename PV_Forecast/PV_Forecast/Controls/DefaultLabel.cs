using Xamarin.Forms;

namespace PV_Forecast.Controls
{
    public class DefaultLabel : Label
    {
        public DefaultLabel()
        {
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            TextColor = Color.Aquamarine;
            HorizontalTextAlignment = TextAlignment.Center;
            VerticalTextAlignment = TextAlignment.Center;
            LineBreakMode = LineBreakMode.WordWrap;
        }
    }
}
