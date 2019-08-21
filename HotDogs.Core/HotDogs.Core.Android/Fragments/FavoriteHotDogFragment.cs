using Android.OS;
using Android.Views;
using HotDogs.Core.Droid.Adapters;

namespace HotDogs.Core.Droid.Fragments
{
    public class FavoriteHotDogFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();

            HandleEvents();

            allHotDogs = dataService.GetFavoriteHotDogs();
            hotDogMenuListView.Adapter = new HotDogListAdapter(allHotDogs, this.Activity);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.FavoriteHotDogsView, container, false);
        }
    }
}