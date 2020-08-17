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

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using NoteBook.Droid;
using NoteBook.CustomRenderers;
using Android.Graphics.Drawables;

[assembly: ExportRenderer (typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace NoteBook.Droid
{
    
    class CustomEntryRenderer : EntryRenderer
    {      
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                //GradientDrawable gd = new GradientDrawable();
                //gd.SetColor(global::Android.Graphics.Color.Transparent);
                // Control.SetBackgroundDrawable(gd);
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);               
            }
        }
        
        

    }
}