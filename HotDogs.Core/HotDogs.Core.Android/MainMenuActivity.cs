
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace HotDogs.Core.Droid
{
    [Activity(Label = "MainMenuActivity", MainLauncher = true)]
    public class MainMenuActivity : Activity
    {
        private ImageView logoImageView;
        private Button orderButton;
        private Button viewMyCartButton;
        private Button takePictureButton;
        private Button mapButton;
        private Button aboutButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenuView);

            FindViews();
            HandleEvents();
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            viewMyCartButton.Click += ViewMyCartButton_Click;
            aboutButton.Click += AboutButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
            mapButton.Click += MapButton_Click;
        }

        private void MapButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void TakePictureButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AboutButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void ViewMyCartButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OrderButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(HotDogMenuActivity));
            StartActivity(intent);
        }

        private void FindViews()
        {
            logoImageView = FindViewById<ImageView>(Resource.Id.logoImageView);

            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            viewMyCartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }
    }
}