using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using Plugin.Iconize.iOS.Controls;
using UIKit;

namespace Iconize.Sample.iOS
{
    [Register("MainController")]
    public class MainController : UITabBarController
    {
        public override void ViewDidLoad()
        {
            var viewControllers = new List<UIViewController>();
            foreach (var module in Plugin.Iconize.Iconize.Modules)
            {
                viewControllers.Add(new ModuleViewController(module, new UICollectionViewFlowLayout
                {
                    ScrollDirection = UICollectionViewScrollDirection.Vertical,
                    ItemSize = new CGSize(250f, 25f),
                    SectionInset = new UIEdgeInsets(22f, 22f, 22f, 22f)
                }));
            }
            ViewControllers = viewControllers.ToArray();

            base.ViewDidLoad();
        }
    }

    [Register("ModuleViewController")]
    public class ModuleViewController : UICollectionViewController
    {
        static readonly NSString cellId = new NSString("IconViewCell");
        private readonly Plugin.Iconize.IIconModule _module;

        public ModuleViewController(Plugin.Iconize.IIconModule module, UICollectionViewLayout layout)
            : base(layout)
        {
            _module = module;

            CollectionView.BackgroundColor = UIColor.White;

            TabBarItem = new UITabBarItem(module.FontFamily, null, 0);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.RegisterClassForCell(typeof(IconViewCell), cellId);
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _module.Keys.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (IconViewCell)collectionView.DequeueReusableCell(cellId, indexPath);

            var icon = _module.GetIcon(_module.Keys.ToList()[indexPath.Row]);

            cell.Icon = icon;

            return cell;
        }
    }

    public class IconViewCell : UICollectionViewCell
    {
        IconLabel _label;

        public IconViewCell(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        public IconViewCell(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public void Initialize()
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };
            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.White };

            _label = new IconLabel();
            _label.TextColor = UIColor.Black;
            _label.Font = UIFont.SystemFontOfSize(12);
            ContentView.AddSubview(_label);
        }

        public Plugin.Iconize.IIcon Icon
        {
            set
            {
                _label.Text = $"{{{value.Key} 16pt}} {value.Key}";
                _label.SizeToFit();
            }
        }
    }
}