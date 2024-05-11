using System;
using Android.Net.Sip;
using AndroidX.Core.Content;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using SlideToAction.Platforms.Android.Handlers;
using SlideToAction.View;

[assembly: ExportRenderer(typeof(CustomSlideToAction), typeof(SlideToActionHandlerAndroid))]
namespace SlideToAction.Platforms.Android.Handlers
{
	public class SlideToActionHandlerAndroid: SliderHandler
    {
        public SlideToActionHandlerAndroid() : base(CustomSliderMapper)
        {
        }

        public static PropertyMapper<CustomSlideToAction, SlideToActionHandlerAndroid> CustomSliderMapper = new PropertyMapper<CustomSlideToAction, SlideToActionHandlerAndroid>(SliderHandler.ViewMapper)
        {
            [nameof(CustomSlideToAction.IsDragCompleted)] = DecorateView
        };


        public static void DecorateView(SlideToActionHandlerAndroid handler, CustomSlideToAction customeSlider)
        {
            if (handler.PlatformView != null && customeSlider != null)
            {
                handler.PlatformView.ProgressDrawable.Alpha = 0;
                customeSlider.HasMaxSliderReached = false;

                if (customeSlider.IsDragCompleted)
                {
                    if (customeSlider.SliderValue > 70)
                    {
                        SetThumb(handler, Resource.Drawable.max_slider);
                        UpdateSlider(handler, customeSlider, 100);
                        customeSlider.HasMaxSliderReached = true;
                    }
                    else
                    {
                        SetThumb(handler, Resource.Drawable.min_slider);
                        UpdateSlider(handler, customeSlider, 0);
                        customeSlider.IsDragCompleted = false;
                    }
                }
                else
                {
                    SetThumb(handler, Resource.Drawable.min_slider);
                }
            }
        }

        public static void SetThumb(SlideToActionHandlerAndroid handler, int drawable)
        {
            handler.PlatformView.SetThumb(ContextCompat.GetDrawable(handler.PlatformView.Context, drawable));
        }

        public static void UpdateSlider(SlideToActionHandlerAndroid handler, CustomSlideToAction customSlideToAction, int progressValue)
        {
            customSlideToAction.Value = progressValue;
            handler.PlatformView.UpdateValue(customSlideToAction);
        }
    }
}