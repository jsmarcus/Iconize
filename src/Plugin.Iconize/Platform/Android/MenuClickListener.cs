using System;
using Android.Runtime;
using Android.Views;

namespace Plugin.Iconize
{
    /// <summary>
    /// Defines the <see cref="MenuClickListener" /> type.
    /// </summary>
    /// <seealso cref="Java.Lang.Object" />
    /// <seealso cref="Android.Views.IMenuItemOnMenuItemClickListener" />
    /// <seealso cref="Android.Runtime.IJavaObject" />
    /// <seealso cref="System.IDisposable" />
    public class MenuClickListener : Java.Lang.Object, IMenuItemOnMenuItemClickListener, IJavaObject, IDisposable
    {
        private readonly Action _callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuClickListener"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public MenuClickListener(Action callback)
        {
            _callback = callback;
        }

        /// <summary>
        /// Called when a menu item has been invoked.
        /// </summary>
        /// <param name="item">The menu item that was invoked.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">Called when a menu item has been invoked.  This is the first code
        /// that is executed; if it returns true, no other callbacks will be
        /// executed.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/view/MenuItem.OnMenuItemClickListener.html#onMenuItemClick(android.view.MenuItem)" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        public bool OnMenuItemClick(IMenuItem item)
        {
            _callback?.Invoke();
            return true;
        }
    }
}