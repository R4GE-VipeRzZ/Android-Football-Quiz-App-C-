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
    [Activity(Label = "league_menu")]
    public class league_menu : Activity
    {
        public void onBackPressed()
        {       //This tells android what to do on this activity when the back button is pressed
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            SetContentView(Resource.Layout.activity_league_menu);

            // Create your application here

            int epl_badges_correct = Preferences.Get("epl_correct_count", 0);

            TextView eplBadgeCorrect = FindViewById<TextView>(Resource.Id.eplProgressCount);
            eplBadgeCorrect.Text = ((epl_badges_correct.ToString()) + "/20");

            ProgressBar eplProgressBar = FindViewById<ProgressBar>(Resource.Id.eplProgressBar);
            eplProgressBar.Progress = (Convert.ToInt32(epl_badges_correct * 5));



            int efl_champ_badges_correct = Preferences.Get("efl_champ_correct_count", 0);

            TextView eflChampBadgeCorrect = FindViewById<TextView>(Resource.Id.eflChampProgressCount);
            eflChampBadgeCorrect.Text = ((efl_champ_badges_correct.ToString()) + "/24");

            ProgressBar eflChampProgressBar = FindViewById<ProgressBar>(Resource.Id.eflChampProgressBar);
            eflChampProgressBar.Progress = (Convert.ToInt32(efl_champ_badges_correct * 4.16));

            Button advanceToEnglishPrem = FindViewById<Button>(Resource.Id.btnEpl);
            advanceToEnglishPrem.Click += delegate
            {
                Intent intent = new Intent(this, typeof(english_premier_league));
                StartActivity(intent);
            };

            Button advanceToEnglishChamp = FindViewById<Button>(Resource.Id.btnEflChamp);
            advanceToEnglishChamp.Click += delegate
            {
                Intent intent = new Intent(this, typeof(english_champ_league));
                StartActivity(intent);
            };
        }
    }
}