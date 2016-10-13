using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Plugin.Iconize;

namespace Iconize.Sample.Droid
{
    public class FontIconsViewPagerAdapter : PagerAdapter
    {
        private readonly IList<IIconModule> _fonts;

        public override Int32 Count => _fonts.Count;

        public FontIconsViewPagerAdapter(IList<IIconModule> fonts)
        {
            _fonts = fonts;
        }

        public override void DestroyItem(ViewGroup container, Int32 position, Java.Lang.Object objectValue)
        {
            container.RemoveView((View)objectValue);
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(Int32 position)
        {
            return new Java.Lang.String(_fonts[position].FontFamily);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, Int32 position)
        {
            var context = container.Context;
            var inflater = LayoutInflater.From(context);
            var view = inflater.Inflate(Resource.Layout.ItemFont, container, false);
            var recyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView);
            var nbColumns = Utils.AndroidUtils.GetScreenSize((Activity)context).Width / context.Resources.GetDimensionPixelSize(Resource.Dimension.item_width);
            recyclerView.SetLayoutManager(new GridLayoutManager(context, nbColumns));
            recyclerView.SetAdapter(new IconAdapter(_fonts[position].Characters.ToArray()));
            container.AddView(view);
            return view;
        }

        public override Boolean IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            return view == objectValue;
        }
    }
}