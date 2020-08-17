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

using Xamarin.Forms.Platform.Android;

using NoteBook.Droid;
using NoteBook.CustomRenderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomEditor),typeof(CustomEditorRenderer))]
namespace NoteBook.Droid
{
    
    public   class CustomEditorRenderer :EditorRenderer
    {        
         public CustomEditorRenderer(Context context) : base(context)
        {

        }

         protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }








   }
}