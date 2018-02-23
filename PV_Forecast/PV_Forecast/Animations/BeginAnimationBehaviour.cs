using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// This is from the Xamarin Community Toolkit. Since I didn't need everything I just dropped the important bits in here. https://github.com/xamarin/XamarinCommunityToolkit
/// Copyright and everything else belongs to their respective owners
/// </summary>

namespace PV_Forecast.Animations
{
    public class BeginAnimationBehaviour : Behavior<VisualElement>
    {
        private static VisualElement associatedObject;

        public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), typeof(AnimationBase), typeof(BeginAnimationBehaviour), null, BindingMode.TwoWay, null);

        public AnimationBase Animation
        {
            get { return (AnimationBase)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        protected override async void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            associatedObject = bindable;

            if (Animation == null) return;

            if(Animation.Target == null)
            {
                Animation.Target = associatedObject;
            }

            var delay = Task.Delay(250);
            await Task.WhenAll(delay);
            await Animation.Begin();
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            associatedObject = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
