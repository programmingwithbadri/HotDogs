
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace HotDogs.Core.Droid
{
    [Activity(Label = "HotDog Detail")]
    public class HotDogDetailActivity : Activity
    {

        private ImageView hotDogImageView;
        private TextView hotDogNameTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private TextView priceTextView;
        private EditText quantityTextView;
        private Button cancelButton;
        private Button orderButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogDetail);
            var SelectedHotDog = Intent.Extras.GetInt("SelectedHotDogId");

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);

            hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);

            quantityTextView = FindViewById<EditText>(Resource.Id.quantityTextView);

            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            //string imageUrl = "";
            //hotDogNameTextView.Text = ;
            //shortDescriptionTextView.Text = ;
            //descriptionTextView.Text = "Price:";
            //quantityTextView.Text = ;
            //hotDogImageView.SetImageBitmap(ImageHelper.GetImageBitmapFromUrl(imageUrl));
        }

        private void HandleEvents()
        {
            cancelButton.Click += CancelButton_Click;
            orderButton.Click += OrderButton_Click;
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OrderButton_Click(object sender, System.EventArgs e)
        {
            var price = int.Parse(priceTextView.Text);
            var intent = new Intent();
            intent.PutExtra("SelectedHotDog", 1); // Selected Hot Dog id should be passed from service
            intent.PutExtra("Amount", price);
            SetResult(Result.Ok, intent);
            this.Finish();


        }
    }
}