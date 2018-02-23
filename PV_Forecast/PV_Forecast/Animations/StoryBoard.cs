using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// This is from the Xamarin Community Toolkit. Since I didn't need everything I just dropped the important bits in here. https://github.com/xamarin/XamarinCommunityToolkit
/// Copyright and everything else belongs to their respective owners
/// </summary>

namespace PV_Forecast.Animations
{
    [ContentProperty("Animations")]
    public class StoryBoard : AnimationBase
    {
        public List<AnimationBase> Animations
        {
            get;
        }

        public StoryBoard()
        {
            Animations = new List<AnimationBase>();
        }

        public StoryBoard(List<AnimationBase> animations)
        {
            Animations = animations;
        }

        protected override async Task BeginAnimation()
        {
            foreach(var animation in Animations)
            {
                if(animation.Target == null)
                {
                    animation.Target = Target;
                }

                await animation.Begin();
            }
        }
    }
}
