using Android.Graphics;
using System.Net;

namespace HotDogs.Core.Droid.Utiltiy
{
    public static class ImageHelper
    {
        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        public static Bitmap GetImageBitmapForFilePath(string fileName, int width, int height)
        {
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InJustDecodeBounds = true;
            BitmapFactory.DecodeFile(fileName, options);

            int sampleSize = -1;
            if (options.OutHeight > height || options.OutWidth > width)
            {
                sampleSize = options.OutWidth > options.OutHeight
                    ? options.OutHeight / height
                    : options.OutWidth / width;
            }

            options.InSampleSize = sampleSize;
            options.InJustDecodeBounds = false;

            Bitmap bitmap = BitmapFactory.DecodeFile(fileName, options);

            return bitmap;

        }
    }
}