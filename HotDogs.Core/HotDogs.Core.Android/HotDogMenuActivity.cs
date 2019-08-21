
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HotDogs.Core.Droid.Fragments;
using HotDogs.Core.Model;
using HotDogs.Core.Service;
using System.Collections.Generic;

namespace HotDogs.Core.Droid
{
    [Activity(Label = "HotDogMenuActivity")]
    public class HotDogMenuActivity : Activity
    {
        private ListView hotDogMenuListView;
        private List<HotDog> allHotDogs;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HotDogMenuView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Favorites", Resource.Drawable.favorite, new FavoriteHotDogFragment());
            AddTab("MeatLover", Resource.Drawable.meatlover, new MeatLoverFragment());
            AddTab("VeggieLover", Resource.Drawable.veggielover, new VeggieLoverFragment());
            //hotDogMenuListView = FindViewById<ListView>(Resource.Id.hotDogListView);


            //dataService = new HotDogDataService();
            //allHotDogs = dataService.GetAllHotDogs();
            //hotDogMenuListView.Adapter = new HotDogListAdapter(allHotDogs, this);
            //hotDogMenuListView.FastScrollEnabled = true;

            //hotDogMenuListView.ItemClick += HotDogMenuListView_ItemClick;


            // Create your application here
        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {

                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        private void HotDogMenuListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = allHotDogs[e.Position];
            var intent = new Intent(this, typeof(HotDogDetailActivity));
            intent.PutExtra("SelectedHotDogId", hotDog.HotDogId);
            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode == 100)
            {
                //Get Selected Hot Dog info from data service
                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage("Your Order is success"); // Add intent data
                dialog.Show();
            }
        }
    }
}