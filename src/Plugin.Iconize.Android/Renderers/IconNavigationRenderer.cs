using System;
using Android.Content;
using Android.Content.Res;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconNavigationRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer" />
    public class IconNavigationRenderer : NavigationPageRenderer
    {

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="context"></param>
	    public IconNavigationRenderer(Context context):base(context)
	    {
		    
	    }

        private Orientation _orientation = Orientation.Portrait;

        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);
            OnUpdateToolbarItems(this);

            base.OnAttachedToWindow();
        }

        /// <summary>
        /// Called when the current configuration of the resources being used
        /// by the application have changed.
        /// </summary>
        /// <param name="newConfig">The new resource configuration.</param>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">Called when the current configuration of the resources being used
        /// by the application have changed.  You can use this to decide when
        /// to reload resources that can changed based on orientation and other
        /// configuration characterstics.  You only need to use this if you are
        /// not relying on the normal <c><see cref="T:Android.App.Activity" /></c> mechanism of
        /// recreating the activity instance upon a configuration change.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/view/View.html#onConfigurationChanged(android.content.res.Configuration)" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 8" />
        protected override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            if (newConfig.Orientation != _orientation)
            {
                _orientation = newConfig.Orientation;
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    OnUpdateToolbarItems(this);
                    return false;
                });
            }
        }

        /// <summary>
        /// Called when [detached from window].
        /// </summary>
        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();

            MessagingCenter.Unsubscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage);
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnUpdateToolbarItems(Object sender)
        {
            Element?.UpdateToolbarItems(this);
        }
    }
}