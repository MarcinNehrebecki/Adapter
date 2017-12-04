using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android;

namespace aplikacja_telefon
{
    class ItemListViewAdapter : BaseAdapter<Item>
    {
        private List<Item> mItems;
        private Activity mContext;
        private int Disable = 0;
        private static int number = 0;

        public ItemListViewAdapter(Activity context, List<Item> items)
        {
            mItems = items;
            mContext = context;
            number = 0;
        }

        public ItemListViewAdapter(Activity context, List<Item> items, int disable)
        {
            Disable = disable;
            mItems = items;
            mContext = context;
            number = 0;
        }
        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Item this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View row = convertView;
            if (row == null)
            {
                //row = LayoutInflater.From(mContext).Inflate(Resource.Layout.boxListView, null, true);
                row = mContext.LayoutInflater.Inflate(Resource.Layout.boxListView, null);
                //row = mContext.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                Log.Info("new View", $"item name: {mItems[position].Name} item id: {mItems[position].Id} position: {position}, {number}/ {mItems.Count}");
            }
            try
            {
                TextView txtName = row.FindViewById<TextView>(Resource.Id.itemName);
                txtName.Text = mItems[position].Name + "\n" + mItems[position].State + " (" + mItems[position].Qty + ")";

                TextView itemId = row.FindViewById<TextView>(Resource.Id.itemId);


                EditText Qty = row.FindViewById<EditText>(Resource.Id.itemQtyToNew);
                if (number > -1)
                {
                    if (mItems[number].Changed == false)
                    {
                        Qty.Id = Convert.ToInt32(mItems[number].Id);
                        Qty.Text = mItems[number].QtyToNewBox;
                        mItems[number].Changed = true;
                    }
                }
                if (Disable == 1)
                {
                    Qty.Enabled = false;
                }

                /*//Qty.Id = Convert.ToInt32(mItems[pos].Id);
                Qty.TextChanged += (sender, e) =>
                {
                    //itemId.Text;
                    Log.Info("changeQty_TextChanged", $"{sender.ToString()} - {e.Text.ToString()}");
                    //mItems[position].QtyToNewBox = e.Text.ToString();
                };*/

                Log.Info(position.ToString(), $"item name: {mItems[position].Name} item id: {mItems[position].Id} position: {position}, {number}/ {mItems.Count}");
                if (number <= mItems.Count && number != -1)
                {
                    number++;
                }
                else
                {
                    number = -1;
                }

            }
            catch (Exception)
            {


            }

            return row;
        }

    }

}