
using Android.App;
using Android.Content;
using Android.Widget;
using HotDogs.Core.Service;
using System.Collections.Generic;

namespace HotDogs.Core.Droid.Fragments
{
    public class BaseFragment : Fragment
    {
        protected List<HotDogs.Core.Model.HotDog> allHotDogs;
        protected ListView hotDogMenuListView;
        protected HotDogDataService dataService;
        public BaseFragment()
        {
            dataService = new HotDogDataService();
        }

        protected void HandleEvents()
        {
            hotDogMenuListView.ItemClick += HotDogMenuListView_ItemClick; ;
        }

        protected void HotDogMenuListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = allHotDogs[e.Position];
            var intent = new Intent(this.Activity, typeof(HotDogDetailActivity));
            intent.PutExtra("SelectedHotDogId", hotDog.HotDogId);
            StartActivityForResult(intent, 100);
        }

        protected void FindViews()
        {
            hotDogMenuListView = this.View.FindViewById<ListView>(Resource.Id.hotDogListView);
        }
    }
}