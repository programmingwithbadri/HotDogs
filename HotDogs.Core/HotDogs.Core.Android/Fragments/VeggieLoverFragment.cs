using Android.OS;
using Android.Views;
using HotDogs.Core.Droid.Adapters;

namespace HotDogs.Core.Droid.Fragments
{
    public class VeggieLoverFragment : BaseFragment
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

            allHotDogs = dataService.GetHotDogsForGroup(2);
            hotDogMenuListView.Adapter = new HotDogListAdapter(allHotDogs, this.Activity);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}