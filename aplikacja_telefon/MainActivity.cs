using Android.App;
using Android.Widget;
using Android.OS;

using System.Collections.Generic;
using System;
using Android.Util;

namespace aplikacja_telefon
{
    [Activity(Label = "aplikacja_telefon", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Item> mItems;
        private ListView boxItemName;
        ItemListViewAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button buttonBox = FindViewById<Button>(Resource.Id.sendToBox);

            buttonBox.Click += delegate
            {
                checkData();
            };
            get_data();
        }

        protected void checkData()
        {
            try
            {
                foreach (var r in mItems)
                {
                    EditText itemQtyToNew = FindViewById<EditText>(Convert.ToInt32(r.Id));
                    Log.Info("checkData", $"{r.Id.ToString()} - {r.Qty.ToString()} - {r.QtyToNewBox.ToString()}, {itemQtyToNew.Text.ToString()}");

                }
            }
            catch (Exception e)
            {
                Toast.MakeText(ApplicationContext, "Wyjątek " + e.Message.ToString(), ToastLength.Short).Show();
            }
        }
        protected void get_data()
        {
            try
            {
                boxItemName = FindViewById<ListView>(Resource.Id.boxItemView);

                mItems = new List<Item>();
                for (int i = 0; i < 20; i++)
                {
                    mItems.Add(new Item() { Name = $"Text {i}", Id = $"{i}", Qty = $"{0}", State = $"" });
                }
 
                adapter = new ItemListViewAdapter(this, mItems);
                boxItemName.Adapter = adapter;
            }
            catch (Exception)
            {
                Toast.MakeText(ApplicationContext, "Wyjątek", ToastLength.Short).Show();
            }
        }
    }
}

