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
    [Activity(Label = "english_premier_league")]
    public class english_premier_league: Activity
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

            SetContentView(Resource.Layout.activity_english_premier_league);

            // Create your application here
            Boolean arsenal_correct = Preferences.Get("arsenal_correct", false);

            ImageView correct_image_arsenal = FindViewById<ImageView>(Resource.Id.imgCorrectArsenal);

            if (arsenal_correct == true)
            {
                correct_image_arsenal.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_arsenal.Visibility = ViewStates.Gone;
            }


            Boolean mancity_correct = Preferences.Get("mancity_correct", false);

            ImageView correct_image_mancity = FindViewById<ImageView>(Resource.Id.imgCorrectMancity);

            if (mancity_correct == true)
            {
                correct_image_mancity.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_mancity.Visibility = ViewStates.Gone;
            }


            Boolean bournemouth_correct = Preferences.Get("bournemouth_correct", false);

            ImageView correct_image_bournemouth = FindViewById<ImageView>(Resource.Id.imgCorrectBournemouth);

            if (bournemouth_correct == true)
            {
                correct_image_bournemouth.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_bournemouth.Visibility = ViewStates.Gone;
            }


            Boolean manunited_correct = Preferences.Get("manunited_correct", false);

            ImageView correct_image_manunited = FindViewById<ImageView>(Resource.Id.imgCorrectManunited);

            if (manunited_correct == true)
            {
                correct_image_manunited.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_manunited.Visibility = ViewStates.Gone;
            }


            Boolean brighton_correct = Preferences.Get("brighton_correct", false);

            ImageView correct_image_brighton = FindViewById<ImageView>(Resource.Id.imgCorrectBrighton);

            if (brighton_correct == true)
            {
                correct_image_brighton.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_brighton.Visibility = ViewStates.Gone;
            }


            Boolean newcastle_correct = Preferences.Get("newcastle_correct", false);

            ImageView correct_image_newcastle = FindViewById<ImageView>(Resource.Id.imgCorrectNewcastle);

            if (newcastle_correct == true)
            {
                correct_image_newcastle.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_newcastle.Visibility = ViewStates.Gone;
            }


            Boolean burnley_correct = Preferences.Get("burnley_correct", false);

            ImageView correct_image_burnley = FindViewById<ImageView>(Resource.Id.imgCorrectBurnley);

            if (burnley_correct == true)
            {
                correct_image_burnley.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_burnley.Visibility = ViewStates.Gone;
            }


            Boolean southampton_correct = Preferences.Get("southampton_correct", false);

            ImageView correct_image_southampton = FindViewById<ImageView>(Resource.Id.imgCorrectSouthampton);

            if (southampton_correct == true)
            {
                correct_image_southampton.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_southampton.Visibility = ViewStates.Gone;
            }


            Boolean chelsea_correct = Preferences.Get("chelsea_correct", false);

            ImageView correct_image_chelsea = FindViewById<ImageView>(Resource.Id.imgCorrectChelsea);

            if (chelsea_correct == true)
            {
                correct_image_chelsea.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_chelsea.Visibility = ViewStates.Gone;
            }


            Boolean astonvilla_correct = Preferences.Get("astonvilla_correct", false);

            ImageView correct_image_astonvilla = FindViewById<ImageView>(Resource.Id.imgCorrectAstonvilla);

            if (astonvilla_correct == true)
            {
                correct_image_astonvilla.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_astonvilla.Visibility = ViewStates.Gone;
            }


            Boolean crystalpalace_correct = Preferences.Get("crystalpalace_correct", false);

            ImageView correct_image_crystalpalace = FindViewById<ImageView>(Resource.Id.imgCorrectCrystalpalace);

            if (crystalpalace_correct == true)
            {
                correct_image_crystalpalace.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_crystalpalace.Visibility = ViewStates.Gone;
            }


            Boolean norwich_correct = Preferences.Get("norwich_correct", false);

            ImageView correct_image_norwich = FindViewById<ImageView>(Resource.Id.imgCorrectNorwich);

            if (norwich_correct == true)
            {
                correct_image_norwich.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_norwich.Visibility = ViewStates.Gone;
            }


            Boolean everton_correct = Preferences.Get("everton_correct", false);

            ImageView correct_image_everton = FindViewById<ImageView>(Resource.Id.imgCorrectEverton);

            if (everton_correct == true)
            {
                correct_image_everton.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_everton.Visibility = ViewStates.Gone;
            }


            Boolean spurs_correct = Preferences.Get("spurs_correct", false);

            ImageView correct_image_spurs = FindViewById<ImageView>(Resource.Id.imgCorrectSpurs);

            if (spurs_correct == true)
            {
                correct_image_spurs.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_spurs.Visibility = ViewStates.Gone;
            }


            Boolean shefunited_correct = Preferences.Get("shefunited_correct", false);

            ImageView correct_image_shefunited = FindViewById<ImageView>(Resource.Id.imgCorrectShefunited);

            if (shefunited_correct == true)
            {
                correct_image_shefunited.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_shefunited.Visibility = ViewStates.Gone;
            }


            Boolean watford_correct = Preferences.Get("watford_correct", false);

            ImageView correct_image_watford = FindViewById<ImageView>(Resource.Id.imgCorrectWatford);

            if (watford_correct == true)
            {
                correct_image_watford.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_watford.Visibility = ViewStates.Gone;
            }


            Boolean westham_correct = Preferences.Get("westham_correct", false);

            ImageView correct_image_westham = FindViewById<ImageView>(Resource.Id.imgCorrectWestham);

            if (westham_correct == true)
            {
                correct_image_westham.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_westham.Visibility = ViewStates.Gone;
            }


            Boolean wolves_correct = Preferences.Get("wolves_correct", false);

            ImageView correct_image_wolves = FindViewById<ImageView>(Resource.Id.imgCorrectWolves);

            if (wolves_correct == true)
            {
                correct_image_wolves.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_wolves.Visibility = ViewStates.Gone;
            }


            Boolean liverpool_correct = Preferences.Get("liverpool_correct", false);

            ImageView correct_image_liverpool = FindViewById<ImageView>(Resource.Id.imgCorrectLiverpool);

            if (liverpool_correct == true)
            {
                correct_image_liverpool.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_liverpool.Visibility = ViewStates.Gone;
            }


            Boolean leicester_correct = Preferences.Get("leicester_correct", false);

            ImageView correct_image_leicester = FindViewById<ImageView>(Resource.Id.imgCorrectLeicester);

            if (leicester_correct == true)
            {
                correct_image_leicester.Visibility = ViewStates.Visible;
            }
            else
            {
                correct_image_leicester.Visibility = ViewStates.Gone;
            }



            Button advanceToArsenalBadge = FindViewById<Button>(Resource.Id.btnArsenal);
            advanceToArsenalBadge.Click += delegate
            {
                Intent intent = new Intent(this, typeof(arsenal_badge));
                StartActivity(intent);
            };


            Button advanceToMancityBadge = FindViewById<Button>(Resource.Id.btnMancity);
            advanceToMancityBadge.Click += delegate
            {
                Intent intent = new Intent(this, typeof(mancity_badge));
                StartActivity(intent);
            };
        }
    }
}