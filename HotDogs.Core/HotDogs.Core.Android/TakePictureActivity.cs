
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using HotDogs.Core.Droid.Utiltiy;
using Java.IO;
using System;

namespace HotDogs.Core.Droid
{
    [Activity(Label = "TakePictureActivity")]
    public class TakePictureActivity : Activity
    {
        private ImageView ownerImageView;
        private Button takePictureButton;
        private File imageDirectory;
        private File imageFile;
        private Bitmap bitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TakePicWithMe);

            FindViews();
            HandleEvents();

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "HotDogs");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }
        }

        private void FindViews()
        {

            ownerImageView = FindViewById<ImageView>(Resource.Id.takePicImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, $"HotDog_{Guid.NewGuid()}.jpg");
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            int height = ownerImageView.Height;
            int width = ownerImageView.Width;
            bitmap = ImageHelper.GetImageBitmapForFilePath(imageFile.Path, width, height);

            if (bitmap != null)
            {
                ownerImageView.SetImageBitmap(bitmap);
                bitmap = null;
            }

            GC.Collect();
        }
    }
}