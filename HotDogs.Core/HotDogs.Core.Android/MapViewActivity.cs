
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;
using System;

namespace HotDogs.Core.Droid
{
    [Activity(Label = "MapViewActivity")]
    public class MapViewActivity : Activity
    {
        private Button externalMapButton;
        private FrameLayout externalMapFrameLayout;
        private MapFragment mapFragment;
        private GoogleMap googleMap;
        private LatLng location;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            location = new LatLng(50.84765, 4.35246);
            SetContentView(Resource.Layout.MapView);

            FindViews();
            HandleEvents();

            CreateMapFragment();
            UpdateMapView();
        }

        private void UpdateMapView()
        {
            var mapReadyCallBack = new LocalMapReady();

            mapReadyCallBack.MapReady += (sender, args) =>
            {
                googleMap = (sender as LocalMapReady).maps;

                if (googleMap != null)
                {
                    MarkerOptions options = new MarkerOptions();
                    options.SetPosition(location);
                    options.SetTitle("Hot Dogs");
                    googleMap.AddMarker(options);

                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(location, 15);
                    googleMap.MoveCamera(cameraUpdate);
                }

            };

            mapFragment.GetMapAsync(mapReadyCallBack);
        }

        private void CreateMapFragment()
        {
            mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

            if (mapFragment == null)
            {
                var googleMapOptions = new GoogleMapOptions().InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(true).InvokeCompassEnabled(true);

                FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                mapFragment = MapFragment.NewInstance(googleMapOptions);

                fragmentTransaction.Add(Resource.Id.mapFrameLayout, mapFragment, "map");
                fragmentTransaction.Commit();
            }
        }

        private void HandleEvents()
        {
            externalMapButton.Click += ExternalMapButton_Click;
        }

        private void ExternalMapButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void FindViews()
        {
            externalMapButton = FindViewById<Button>(Resource.Id.externalMapButton);
            externalMapFrameLayout = FindViewById<FrameLayout>(Resource.Id.mapFrameLayout);
        }
    }

    internal class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
    {
        public GoogleMap maps;
        public event EventHandler MapReady;
        public void OnMapReady(GoogleMap googleMap)
        {
            maps = googleMap;
            var handler = MapReady;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

        }
    }
}