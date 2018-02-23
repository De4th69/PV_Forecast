using Xamarin.Forms;

/// <summary>
/// This is from the Xamarin Community Toolkit. Since I didn't need everything I just dropped the important bits in here. https://github.com/xamarin/XamarinCommunityToolkit
/// Copyright and everything else belongs to their respective owners
/// </summary>

namespace PV_Forecast.Animations
{
    public static class EasingHelper
    {
        public static Easing GetEasing(EasingType type)
        {
            switch (type)
            {
                case EasingType.BounceIn:
                    return Easing.BounceIn;
                case EasingType.BounceOut:
                    return Easing.BounceOut;
                case EasingType.CubicIn:
                    return Easing.CubicIn;
                case EasingType.CubicInOut:
                    return Easing.CubicInOut;
                case EasingType.CubicOut:
                    return Easing.CubicOut;
                case EasingType.Linear:
                    return Easing.Linear;
                case EasingType.SinIn:
                    return Easing.SinIn;
                case EasingType.SinInOut:
                    return Easing.SinInOut;
                case EasingType.SinOut:
                    return Easing.SinOut;
                case EasingType.SpringIn:
                    return Easing.SpringIn;
                case EasingType.SpringOut:
                    return Easing.SpringOut;
            }

            return null;
        }
    }
}
