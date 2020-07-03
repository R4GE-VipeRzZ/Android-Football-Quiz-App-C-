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
using Xamarin.Essentials;

namespace football_logo_quiz2
{
    [Activity(Label = "english_champ_league")]
    public class english_champ_league : Activity
    {
        public void onBackPressed()
        {       //This tells android what to do on this activity when the back button is pressed
            Intent intent = new Intent(this, typeof(league_menu));
            StartActivity(intent);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            SetContentView(Resource.Layout.activity_english_champ_league);

            // Create your application here
            Boolean barnsley_correct = Preferences.Get("barnsley_correct", false);

            ImageView correct_image_barnsley = FindViewById<ImageView>(Resource.Id.imgCorrectBarnsley);

            if (barnsley_correct == true)
            {
                correct_image_barnsley.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_barnsley.Visibility = ViewStates.Gone;
            }


            Boolean shefwednesday_correct = Preferences.Get("shefwednesday_correct", false);

            ImageView correct_image_shefwednesday = FindViewById<ImageView>(Resource.Id.imgCorrectShefwednesday);

            if (shefwednesday_correct == true)
            {
                correct_image_shefwednesday.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_shefwednesday.Visibility = ViewStates.Gone;
            }


            Boolean hull_correct = Preferences.Get("hull_correct", false);

            ImageView correct_image_hull = FindViewById<ImageView>(Resource.Id.imgCorrectHull);

            if (hull_correct == true)
            {
                correct_image_hull.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_hull.Visibility = ViewStates.Gone;
            }


            Boolean charlton_correct = Preferences.Get("charlton_correct", false);

            ImageView correct_image_charlton = FindViewById<ImageView>(Resource.Id.imgCorrectCharlton);

            if (charlton_correct == true)
            {
                correct_image_charlton.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_charlton.Visibility = ViewStates.Gone;
            }


            Boolean blackburn_correct = Preferences.Get("blackburn_correct", false);

            ImageView correct_image_blackburn = FindViewById<ImageView>(Resource.Id.imgCorrectBlackburn);

            if (blackburn_correct == true)
            {
                correct_image_blackburn.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_blackburn.Visibility = ViewStates.Gone;
            }


            Boolean preston_correct = Preferences.Get("preston_correct", false);

            ImageView correct_image_preston = FindViewById<ImageView>(Resource.Id.imgCorrectPreston);

            if (preston_correct == true)
            {
                correct_image_preston.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_preston.Visibility = ViewStates.Gone;
            }


            Boolean luton_correct = Preferences.Get("luton_correct", false);

            ImageView correct_image_luton = FindViewById<ImageView>(Resource.Id.imgCorrectLuton);

            if (luton_correct == true)
            {
                correct_image_luton.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_luton.Visibility = ViewStates.Gone;
            }


            Boolean fullham_correct = Preferences.Get("fullham_correct", false);

            ImageView correct_image_fullham = FindViewById<ImageView>(Resource.Id.imgCorrectFullham);

            if (fullham_correct == true)
            {
                correct_image_fullham.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_fullham.Visibility = ViewStates.Gone;
            }


            Boolean westbrom_correct = Preferences.Get("westbrom_correct", false);

            ImageView correct_image_westbrom = FindViewById<ImageView>(Resource.Id.imgCorrectWestbrom);

            if (westbrom_correct == true)
            {
                correct_image_westbrom.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_westbrom.Visibility = ViewStates.Gone;
            }


            Boolean reading_correct = Preferences.Get("reading_correct", false);

            ImageView correct_image_reading = FindViewById<ImageView>(Resource.Id.imgCorrectReading);

            if (reading_correct == true)
            {
                correct_image_reading.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_reading.Visibility = ViewStates.Gone;
            }


            Boolean huddersfield_correct = Preferences.Get("huddersfield_correct", false);

            ImageView correct_image_huddersfield = FindViewById<ImageView>(Resource.Id.imgCorrectHuddersfield);

            if (huddersfield_correct == true)
            {
                correct_image_huddersfield.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_huddersfield.Visibility = ViewStates.Gone;
            }


            Boolean cardiff_correct = Preferences.Get("cardiff_correct", false);

            ImageView correct_image_cardiff = FindViewById<ImageView>(Resource.Id.imgCorrectCardiff);

            if (cardiff_correct == true)
            {
                correct_image_cardiff.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_cardiff.Visibility = ViewStates.Gone;
            }


            Boolean birmingham_correct = Preferences.Get("birmingham_correct", false);

            ImageView correct_image_birmingham = FindViewById<ImageView>(Resource.Id.imgCorrectBirmingham);

            if (birmingham_correct == true)
            {
                correct_image_birmingham.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_birmingham.Visibility = ViewStates.Gone;
            }


            Boolean nottsforest_correct = Preferences.Get("nottsforest_correct", false);

            ImageView correct_image_nottsforest = FindViewById<ImageView>(Resource.Id.imgCorrectNottsforest);

            if (nottsforest_correct == true)
            {
                correct_image_nottsforest.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_nottsforest.Visibility = ViewStates.Gone;
            }


            Boolean leeds_correct = Preferences.Get("leeds_correct", false);

            ImageView correct_image_leeds = FindViewById<ImageView>(Resource.Id.imgCorrectLeeds);

            if (leeds_correct == true)
            {
                correct_image_leeds.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_leeds.Visibility = ViewStates.Gone;
            }


            Boolean derby_correct = Preferences.Get("derby_correct", false);

            ImageView correct_image_derby = FindViewById<ImageView>(Resource.Id.imgCorrectDerby);

            if (derby_correct == true)
            {
                correct_image_derby.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_derby.Visibility = ViewStates.Gone;
            }


            Boolean swansea_correct = Preferences.Get("swansea_correct", false);

            ImageView correct_image_swansea = FindViewById<ImageView>(Resource.Id.imgCorrectSwansea);

            if (swansea_correct == true)
            {
                correct_image_swansea.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_swansea.Visibility = ViewStates.Gone;
            }


            Boolean qpr_correct = Preferences.Get("qpr_correct", false);

            ImageView correct_image_qpr = FindViewById<ImageView>(Resource.Id.imgCorrectQpr);

            if (qpr_correct == true)
            {
                correct_image_qpr.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_qpr.Visibility = ViewStates.Gone;
            }


            Boolean middlesbrough_correct = Preferences.Get("middlesbrough_correct", false);

            ImageView correct_image_middlesbrough = FindViewById<ImageView>(Resource.Id.imgCorrectMiddlesbrough);

            if (middlesbrough_correct == true)
            {
                correct_image_middlesbrough.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_middlesbrough.Visibility = ViewStates.Gone;
            }


            Boolean bristol_correct = Preferences.Get("bristol_correct", false);

            ImageView correct_image_bristol = FindViewById<ImageView>(Resource.Id.imgCorrectBristol);

            if (bristol_correct == true)
            {
                correct_image_bristol.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_bristol.Visibility = ViewStates.Gone;
            }


            Boolean millwall_correct = Preferences.Get("millwall_correct", false);

            ImageView correct_image_millwall = FindViewById<ImageView>(Resource.Id.imgCorrectMillwall);

            if (millwall_correct == true)
            {
                correct_image_millwall.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_millwall.Visibility = ViewStates.Gone;
            }


            Boolean stoke_correct = Preferences.Get("stoke_correct", false);

            ImageView correct_image_stoke = FindViewById<ImageView>(Resource.Id.imgCorrectStoke);

            if (stoke_correct == true)
            {
                correct_image_stoke.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_stoke.Visibility = ViewStates.Gone;
            }


            Boolean brentford_correct = Preferences.Get("brentford_correct", false);

            ImageView correct_image_brentford = FindViewById<ImageView>(Resource.Id.imgCorrectBrentford);

            if (brentford_correct == true)
            {
                correct_image_brentford.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_brentford.Visibility = ViewStates.Gone;
            }


            Boolean wigan_correct = Preferences.Get("wigan_correct", false);

            ImageView correct_image_wigan = FindViewById<ImageView>(Resource.Id.imgCorrectWigan);

            if (wigan_correct == true)
            {
                correct_image_wigan.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_wigan.Visibility = ViewStates.Gone;
            }
        }
    }
}