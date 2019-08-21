using Android.App;
using Android.Views;
using Android.Widget;
using HotDogs.Core.Droid.Utiltiy;
using HotDogs.Core.Model;
using System.Collections.Generic;

namespace HotDogs.Core.Droid.Adapters
{
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        private List<HotDog> allHotDogs;
        private Activity context;

        public HotDogListAdapter(List<HotDog> allHotDogs, Activity context) : base()
        {
            this.allHotDogs = allHotDogs;
            this.context = context;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            string bitMapUrl = "";
            var item = allHotDogs[position];
            var imageBitMap = ImageHelper.GetImageBitmapFromUrl(bitMapUrl);
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.hotDogTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$" + item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.hotDogTextView).SetImageBitmap(imageBitMap);

            return convertView;
        }

        public override int Count
        {
            get { return allHotDogs.Count; }
        }

        public override HotDog this[int position]
        {
            get { return allHotDogs[position]; }
        }
    }
}