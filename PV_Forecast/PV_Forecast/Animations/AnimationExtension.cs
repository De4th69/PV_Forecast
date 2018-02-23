using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// This is from the Xamarin Community Toolkit. Since I didn't need everything I just dropped the important bits in here. https://github.com/xamarin/XamarinCommunityToolkit
/// Copyright and everything else belongs to their respective owners
/// </summary>

namespace PV_Forecast.Animations
{
    public static class AnimationExtension
    {
        public static async Task<bool> Animate(this VisualElement visualElement, AnimationBase animation)
        {
            try
            {
                animation.Target = visualElement;

                await animation.Begin();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
