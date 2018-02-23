using System;
using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// This is from the Xamarin Community Toolkit. Since I didn't need everything I just dropped the important bits in here. https://github.com/xamarin/XamarinCommunityToolkit
/// Copyright and everything else belongs to their respective owners
/// </summary>

namespace PV_Forecast.Animations
{
    public class TranslateToAnimation : AnimationBase
    {
        public static readonly BindableProperty TranslateXProperty = BindableProperty.Create(nameof(TranslateX), typeof(double), typeof(TranslateToAnimation), default(double), BindingMode.TwoWay, null);

        public static readonly BindableProperty TranslateYProperty = BindableProperty.Create(nameof(TranslateY), typeof(double), typeof(TranslateToAnimation), default(double), BindingMode.TwoWay, null);

        public double TranslateX
        {
            get { return (double)GetValue(TranslateXProperty); }
            set { SetValue(TranslateXProperty, value); }
        }

        public double TranslateY
        {
            get { return (double)GetValue(TranslateYProperty); }
            set { SetValue(TranslateYProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property");
            }

            return Target.TranslateTo(TranslateX, TranslateY, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}
