using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SlideToAction.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _dragValue;

        public double DragValue
        {
            get => _dragValue;
            set
            {
                if (_dragValue != value)
                    _dragValue = value;
                OnPropertyChanged(nameof(DragValue));
            }
        }

        private bool _dragCompleted;

        public bool DragCompleted
        {
            get
            {
                return _dragCompleted;
            }
            set
            {
                if (_dragCompleted != value)
                {
                    _dragCompleted = value;
                    OnPropertyChanged(nameof(DragCompleted));
                }
            }
        }

        private bool _hasReachedMaxSlider;
        public bool HasReachedMaxSlider
        {
            get
            {
                return _hasReachedMaxSlider;
            }
            set
            {
                if (_hasReachedMaxSlider != value)
                {
                    _hasReachedMaxSlider = value;
                    OnPropertyChanged(nameof(HasReachedMaxSlider));
                    if (value)
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new Pages.HomePage());
                    }
                }
            }
        }

        private Task OnDragCompleted()
        {
            DragCompleted = true;
            return Task.CompletedTask;
        }

        public ICommand SliderDragCompleted { private set; get; }

        public MainPageViewModel()
        {
            SliderDragCompleted = new Command(execute: () => OnDragCompleted());
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

