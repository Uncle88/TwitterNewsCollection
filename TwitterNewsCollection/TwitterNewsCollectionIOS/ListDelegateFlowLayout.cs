using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TwitterNewsCollectionIOS
{
    public class ListDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(350, 40);
        }
    }
}
