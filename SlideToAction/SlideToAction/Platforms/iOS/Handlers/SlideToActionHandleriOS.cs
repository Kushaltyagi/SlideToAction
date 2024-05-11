using System;
using ARKit;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using SlideToAction.Platforms.iOS.Handlers;
using SlideToAction.Themes.Images;
using SlideToAction.View;
using UIKit;

[assembly: ExportRenderer(typeof(CustomSlideToAction), typeof(SlideToActionHandleriOS))]
namespace SlideToAction.Platforms.iOS.Handlers
{
	public class SlideToActionHandleriOS : SliderHandler
    {
        public SlideToActionHandleriOS() : base(CustomSliderMapper)
        {
        }

        public static PropertyMapper<CustomSlideToAction, SlideToActionHandleriOS> CustomSliderMapper = new PropertyMapper<CustomSlideToAction, SlideToActionHandleriOS>(SliderHandler.ViewMapper)
        {
            [nameof(CustomSlideToAction.IsDragCompleted)] = DecorateView
        };


        public static void DecorateView(SlideToActionHandleriOS handler, CustomSlideToAction customeSlider)
        {
            if (handler.PlatformView != null && customeSlider != null)
            {
                handler.PlatformView.MinimumTrackTintColor = UIColor.Clear;
                handler.PlatformView.MaximumTrackTintColor = UIColor.Clear;
                handler.PlatformView.TintColor = UIColor.Clear;

                customeSlider.HasMaxSliderReached = false;

                if (customeSlider.IsDragCompleted)
                {
                    if (customeSlider.SliderValue > 0.7)
                    {
                        SetThumb(handler, Images.MaxSliderImage);
                        UpdateSlider(handler, customeSlider, 1);
                        customeSlider.HasMaxSliderReached = true;
                    }
                    else
                    {
                        SetThumb(handler, Images.MinSliderImage);
                        UpdateSlider(handler, customeSlider, 0.01);
                        customeSlider.IsDragCompleted = false;
                    }
                }
                else
                {
                    SetThumb(handler, Images.MinSliderImage);
                }
            }
        }

        public static void SetThumb(SlideToActionHandleriOS handler, string drawable)
        {
            handler.PlatformView.SetThumbImage(new UIImage(drawable), UIKit.UIControlState.Normal);
        }

        public static void UpdateSlider(SlideToActionHandleriOS handler, CustomSlideToAction customeSlider, double progressValue)
        {
            customeSlider.Value = progressValue;
            handler.PlatformView.UpdateValue(customeSlider);
        }
    }
}
