using System;
namespace SlideToAction.View
{
	public class CustomSlideToAction: Slider
	{
        public static BindableProperty IsDragCompletedProperty = BindableProperty.Create(nameof(IsDragCompleted),
                                                                        typeof(bool),
                                                                        typeof(CustomSlideToAction),
                                                                        false, defaultBindingMode: BindingMode.TwoWay);
        public bool IsDragCompleted
        {
            get => (bool)GetValue(IsDragCompletedProperty);
            set => SetValue(IsDragCompletedProperty, value);
        }

        public static BindableProperty SliderValueProperty = BindableProperty.Create(nameof(SliderValue),
                                                                        typeof(double),
                                                                        typeof(CustomSlideToAction),
                                                                        0.0,
                                                                        defaultBindingMode: BindingMode.TwoWay);
        public double SliderValue
        {
            get => (double)GetValue(SliderValueProperty);
            set => SetValue(SliderValueProperty, value);
        }

        public static BindableProperty HasMaxSliderReachedProperty = BindableProperty.Create(nameof(HasMaxSliderReached),
                                                                       typeof(bool),
                                                                       typeof(CustomSlideToAction),
                                                                       false, defaultBindingMode: BindingMode.TwoWay);
        public bool HasMaxSliderReached
        {
            get => (bool)GetValue(HasMaxSliderReachedProperty);
            set => SetValue(HasMaxSliderReachedProperty, value);
        }

    }
}

