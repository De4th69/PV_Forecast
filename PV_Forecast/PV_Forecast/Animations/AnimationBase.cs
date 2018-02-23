using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// This is from the Xamarin Community Toolkit. Since I didn't need everything I just dropped the important bits in here. https://github.com/xamarin/XamarinCommunityToolkit
/// Copyright and everything else belongs to their respective owners
/// </summary>

namespace PV_Forecast.Animations
{
    public abstract class AnimationBase : BindableObject
    {
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(nameof(Target), typeof(VisualElement), typeof(AnimationBase), null, BindingMode.TwoWay, null);

        public static readonly BindableProperty DurationProperty = BindableProperty.Create(nameof(Duration), typeof(string), typeof(AnimationBase), "1000", BindingMode.TwoWay, null);

        public static readonly BindableProperty EasingProperty = BindableProperty.Create(nameof(Easing), typeof(EasingType), typeof(AnimationBase), EasingType.Linear, BindingMode.TwoWay, null);

        public VisualElement Target
        {
            get { return (VisualElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public EasingType Easing
        {
            get { return (EasingType)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        protected abstract Task BeginAnimation();

        public async Task Begin()
        {
            await BeginAnimation();
        }
    }
}
