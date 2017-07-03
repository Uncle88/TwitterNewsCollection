using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using TwitterNewsCollection.ViewModels;
using TwitterNewsCollectionIOS.Views.Cell;

namespace TwitterNewsCollectionIOS.Views
{
    public partial class CollectionView : MvxViewController
    {
        public CollectionView() : base("CollectionView", null)
        {
        }

        public new ListViewModel ViewModel
        {
            get { return (ListViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.CreateBindingSet<CollectionView, ListViewModel>();
            _collectionView.RegisterNibForCell(CollectionViewCell.Nib, CollectionViewCell.Key);
            var sourse = new MvxCollectionViewSource(_collectionView, CollectionViewCell.Key);
            _collectionView.Source = sourse;
            _collectionView.Delegate = new ListDelegateFlowLayout();
            var set = this.CreateBindingSet<CollectionView, ListViewModel>();
            set.Bind(sourse).For(s => s.ItemsSource).To(vm => vm.TwitterFeeds);
            set.Apply();
        }
    }
}

