using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Plugin.Iconize;
using Plugin.Iconize.Droid.Controls;

namespace Iconize.Sample.Droid
{
    public class IconAdapter : RecyclerView.Adapter
    {
        private readonly IIcon[] _icons;

        public override Int32 ItemCount => _icons.Length;

        public IconAdapter(IIcon[] icons)
        {
            _icons = icons;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, Int32 viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ItemIcon, parent, false);
            return new ViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, Int32 position)
        {
            var icon = _icons[position];
            var viewHolder = holder as ViewHolder;
            viewHolder.Button.Text = $"{{{icon.Key}}}";
            viewHolder.Icon.Text = $"{{{icon.Key}}}";
            viewHolder.Name.Text = icon.Key;
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public AppCompatButton Button;
            public TextView Icon;
            public TextView Name;

            public ViewHolder(View itemView)
                : base(itemView)
            {
                Button = itemView.FindViewById<IconButton>(Resource.Id.button);
                Icon = itemView.FindViewById<IconTextView>(Resource.Id.icon);
                Name = itemView.FindViewById<TextView>(Resource.Id.name);
            }
        }
    }
}