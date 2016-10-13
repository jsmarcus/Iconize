using Android.Support.V4.View;
using View = Android.Views.View;

namespace Plugin.Iconize.Droid
{
    /// <summary>
    /// Any TextView subclass that wishes to call <see cref="IconizeExtensions.AddIcons(Android.Widget.TextView[])" /> on it
    /// needs to implement this interface if it ever want to use spinning icons.
    /// IconTextView, IconButton and IconToggleButton already implement it, but if you need to implement it
    /// yourself, please use <see cref="HasOnViewAttachListenerDelegate" />
    /// to help you.
    /// </summary>
    public interface IHasOnViewAttachListener
    {
        /// <summary>
        /// Sets the on view attach listener.
        /// </summary>
        /// <param name="listener">The listener.</param>
        void SetOnViewAttachListener(IOnViewAttachListener listener);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IOnViewAttachListener
    {
        /// <summary>
        /// Called when [attach].
        /// </summary>
        void OnAttach();

        /// <summary>
        /// Called when [detach].
        /// </summary>
        void OnDetach();
    }

    /// <summary>
    /// Defines the <see cref="HasOnViewAttachListenerDelegate" /> delegate.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.Droid.IHasOnViewAttachListener" />
    public class HasOnViewAttachListenerDelegate : IHasOnViewAttachListener
    {
        private readonly View _view;
        private IOnViewAttachListener _listener;

        /// <summary>
        /// Initializes a new instance of the <see cref="HasOnViewAttachListenerDelegate"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public HasOnViewAttachListenerDelegate(View view)
        {
            _view = view;
        }

        /// <summary>
        /// Sets the on view attach listener.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public void SetOnViewAttachListener(IOnViewAttachListener listener)
        {
            if (_listener != null)
                _listener.OnDetach();
            _listener = listener;
            if (ViewCompat.IsAttachedToWindow(_view) && listener != null)
            {
                listener.OnAttach();
            }
        }

        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        public void OnAttachedToWindow()
        {
            if (_listener != null)
                _listener.OnAttach();
        }

        /// <summary>
        /// Called when [detached from window].
        /// </summary>
        public void OnDetachedFromWindow()
        {
            if (_listener != null)
                _listener.OnDetach();
        }
    }
}