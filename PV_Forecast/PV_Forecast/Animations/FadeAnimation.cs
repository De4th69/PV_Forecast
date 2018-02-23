﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// This is from the Xamarin Community Toolkit. Since I didn't need everything I just dropped the important bits in here. https://github.com/xamarin/XamarinCommunityToolkit
/// Copyright and everything else belongs to their respective owners
/// </summary>

namespace PV_Forecast.Animations
{
    public class FadeToAnimation : AnimationBase
    {
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(double), typeof(FadeToAnimation), default(double), BindingMode.TwoWay, null);

        public double Opacity
        {
            get { return (double)GetValue(OpacityProperty); }
            set { SetValue(OpacityProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if(Target == null)
            {
                throw new NullReferenceException("Null Target Property");
            }

            return Target.FadeTo(Opacity, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    public class FadeInAnimation : AnimationBase
    {
        public enum FadeDirection
        {
            Up,
            Down
        }

        public static readonly BindableProperty DirectionProperty = BindableProperty.Create(nameof(Direction), typeof(FadeDirection), typeof(FadeInAnimation), FadeDirection.Down, BindingMode.TwoWay, null);

        public FadeDirection Direction
        {
            get { return (FadeDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if(Target == null)
            {
                throw new NullReferenceException("Null Target property");
            }

            return Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("FadeIn", FadeIn(), 16, Convert.ToUInt32(Duration));
                });
            });
        }

        internal Animation FadeIn()
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => Target.Opacity = f, 0, 1, Xamarin.Forms.Easing.CubicOut);

            animation.WithConcurrent(
                (f) => Target.TranslationY = f,
                Target.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50),
                Target.TranslationY,
                Xamarin.Forms.Easing.CubicOut,
                0,
                1);

            return animation;
        }
    }

    public class FadeOutAnimation : AnimationBase
    {
        public enum FadeDirection
        {
            Up,
            Down
        }

        public static readonly BindableProperty DirectionProperty = BindableProperty.Create(nameof(Direction), typeof(FadeDirection), typeof(FadeOutAnimation), FadeDirection.Down, BindingMode.TwoWay, null);

        public FadeDirection Direction
        {
            get { return (FadeDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if(Target == null)
            {
                throw new NullReferenceException("Null Target property");
            }

            return Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("FadeOut", FadeOut(), 16, Convert.ToUInt32(Duration));
                });
            });
        }

        internal Animation FadeOut()
        {
            var animation = new Animation();

            animation.WithConcurrent((f) => Target.Opacity = f, 1, 0);

            animation.WithConcurrent((f) => Target.TranslationY = f,
                Target.TranslationY,
                Target.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50));

            return animation;
        }
    }
}
