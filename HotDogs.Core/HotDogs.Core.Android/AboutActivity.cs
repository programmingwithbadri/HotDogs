
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace HotDogs.Core.Droid
{
    [Activity(Label = "AnoutActivity")]
    public class AboutActivity : Activity
    {
        private TextView phoneNumberTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutView);

            phoneNumberTextView.FindViewById<TextView>(Resource.Id.phoneNumberTextView);
            phoneNumberTextView.Click += PhoneNumberTextView_Click;
            // Create your application here
        }

        private void PhoneNumberTextView_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumberTextView.Text));
            StartActivity(intent);

        }
    }
}