using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TwitterNewsCollectionIOS
{
    public class ListDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(325, 40);
        }
    }
}
