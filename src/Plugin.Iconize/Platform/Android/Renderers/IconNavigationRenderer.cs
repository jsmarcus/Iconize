using System;
using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Plugin.Iconize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationRenderer))]
namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="IconNavigationPage" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer" />
    public class IconNavigationRenderer : NavigationPageRenderer
    {
        private Orientation _orientation = Orientation.Portrait;

        /// <summary>
        /// Initializes a new instance of the <see cref="IconNavigationRenderer"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public IconNavigationRenderer(Context context)
            : base(context)
        {
            // Intentionally left blank
        }

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            HandleProperties();
        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            HandleProperties();
        }

        /// <inheritdoc />
        protected override void OnAttachedToWindow()
        {
            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);

            HandleProperties();
            base.OnAttachedToWindow();
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            var toolbarItems = Element.GetToolbarItems();
            if (toolbarItems != null)
            {
                foreach (var item in toolbarItems)
                {
                    item.PropertyChanged -= HandleToolbarItemPropertyChanged;
                }
            }
            MessagingCenter.Unsubscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage);
        }

        private void HandleProperties()
        {
            var toolbarItems = Element.GetToolbarItems();
            if (toolbarItems != null)
            {
                foreach (ToolbarItem item in toolbarItems)
                {
                    item.PropertyChanged -= HandleToolbarItemPropertyChanged;
                    item.PropertyChanged += HandleToolbarItemPropertyChanged;
                }
            }
            OnUpdateToolbarItems(this);
        }

        private void OnUpdateToolbarItems(Object sender)
        {
            Element?.UpdateToolbarItems(this);
        }

        private void HandleToolbarItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MenuItem.IsEnabled)
                || e.PropertyName == nameof(MenuItem.Text)
                || e.PropertyName == nameof(MenuItem.Icon))
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    OnUpdateToolbarItems(this);
                    return false;
                });
            }
        }
    }
}