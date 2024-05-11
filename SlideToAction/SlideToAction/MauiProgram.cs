using Microsoft.Extensions.Logging;
#if ANDROID
using SlideToAction.Platforms.Android.Handlers;
#elif IOS
using SlideToAction.Platforms.iOS.Handlers;
#endif
using SlideToAction.View;

namespace SlideToAction;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .ConfigureMauiHandlers((handlers) =>
            {
#if ANDROID

            handlers.AddHandler(typeof(CustomSlideToAction), typeof(SlideToActionHandlerAndroid));
#elif IOS

            handlers.AddHandler(typeof(CustomSlideToAction), typeof(SlideToActionHandleriOS));
#endif
            });
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

