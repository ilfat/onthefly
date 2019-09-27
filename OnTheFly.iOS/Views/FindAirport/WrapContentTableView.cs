using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace OnTheFly.iOS
{
    public partial class WrapContentTableView : UITableView
    {
        public WrapContentTableView (IntPtr handle) : base (handle)
        {
        }
        public override CGSize ContentSize
        {
            get
            {
                return base.ContentSize;
            }
            set
            {
                base.ContentSize = value;
                InvalidateIntrinsicContentSize();
            }
        }

        public override CGSize IntrinsicContentSize => ContentSize;
    }
}