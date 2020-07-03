using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace football_logo_quiz2
{
    [Activity(Label = "bristol_badge")]
    public class bristol_badge : Activity
    {
        MediaPlayer player;

        public static int[] answer = { 2, 18, 9, 19, 20, 15, 12, 3, 9, 20, 25 };       //This array contains the sequence of numbers that is required for the user to be correct
        public int[] word_array = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };              //This array stores the users letter choices that need to be displayed
        public int[] letter_array = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };            //This array stores the button numbers of the characters that the user selects
        public int[] character_option_array = { 20, 18, 25, 9, 21, 3, 9, 20, 15, 12, 21, 21, 2, 20, 20, 19, 16, 18 };     //This array stores the number of the letter for each button
        public int[] character_option_visibility = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };       //Stores 1 if the user option button is visible and 0 is he user button isnt visible
        public int[] character_ans_visibility = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };                    //Stores 1 if the answer char can be remove and 0 if the answer char cant be removed
        public int[] dash_id_array = { };                       //This stores the id numbers of the dashes so that the program doesnt try to find a button that is a dash
        int letter = 0;                                         //This variable changes depending on the character letter
        int array_location = 0;                                 //This variable is used the pass the array location of the selected character through the program
        int btn_number = 1;                                     //This is used to store the number of the button that was pressed so the program knows what number to put in the letter_array
        public Boolean valid = true;                            //This is used to only allow characters to be guessed when there is a space if the boolean if false then there isnt a space
        int num_chars = 18;                                     //This variables tells the program the amount characters the user can choose from
        public IList btn_answers = new ArrayList() { 13, 2, 4, 16, 1, 9, 10, 6, 7, 8, 3 };            //This variable array stores the ids of the buttons that are required to answer the badge
        public int single_buttons_removed = 0;                  //This variable stores the amount of times that the remove single button has been used
        public int remove_half_letters_count = 0;               //This variable stores the amount of times the remove half letters has been used
        public int random_letter_fill = 0;                      //This variable stores the amount of times that the random letter fill button has been used
        public int[] answer_fill_array = { };                //This array stores the shuffled button option numbers for the fill random letter button
        public int[] num_ID_adjust_array = { };               //This array stores the button ids that occur straight after a dash that have been create when generating the ids for the answer fill array
        public int button_operation = 0;                        //This is used to change the character answer buttons actions depending on the number
        public Boolean coin_count_valid = false;                //This is used to tell the program if the the user has enough coins for the hit that was selected

        public override void OnBackPressed()                        //This tells android what to do on this activity when the back button is pressed
        {
            clear();
        }

        protected override void OnDestroy()
        {
            String bristolTempWordString = "";
            for (int i = 0; i < word_array.Length; i++)                     //This converts the word_array into a string
            {
                bristolTempWordString = bristolTempWordString + ((word_array[i].ToString()));

                if (i < ((word_array.Length) - 1))                      //This adds commas between the numbers in the string
                {
                    bristolTempWordString = bristolTempWordString + (",");
                }
            }

            Preferences.Set("bristolCharInput", bristolTempWordString);                     //This saves the arsenalTempWordString into the sharedpreferences



            String bristolTempChoiceString = "";
            for (int i = 0; i < letter_array.Length; i++)                       //This converts the letter_array into a string
            {
                bristolTempChoiceString = bristolTempChoiceString + ((letter_array[i].ToString()));

                if (i < ((letter_array.Length) - 1))                        //This adds commas between the numbers in the string
                {
                    bristolTempChoiceString = bristolTempChoiceString + (",");
                }
            }

            Preferences.Set("bristolCharChoice", bristolTempChoiceString);         //This saves the arsenalTempChoiceString



            String bristolTempCharOptionVisString = "";
            for (int i = 0; i < character_option_visibility.Length; i++)                        //This converts the letter_array into a string
            {
                bristolTempCharOptionVisString = bristolTempCharOptionVisString + ((character_option_visibility[i].ToString()));

                if (i < ((character_option_visibility.Length) - 1))                     //This adds commas between the numbers in the string
                {
                    bristolTempCharOptionVisString = bristolTempCharOptionVisString + (",");
                }
            }

            Preferences.Set("bristolCharOptionVis", bristolTempCharOptionVisString);         //This saves the arsenalTempCharOptionVisString



            String bristolTempCharAnsVisString = "";
            for (int i = 0; i < character_ans_visibility.Length; i++)                       //This converts the letter_array into a string
            {
                bristolTempCharAnsVisString = bristolTempCharAnsVisString + ((character_ans_visibility[i].ToString()));

                if (i < ((character_ans_visibility.Length) - 1))                        //This adds commas between the numbers in the string
                {
                    bristolTempCharAnsVisString = bristolTempCharAnsVisString + (",");
                }
            }

            Preferences.Set("bristolAnsOptionVis", bristolTempCharAnsVisString);         //This saves the arsenalTempCharAnsVisString



            String bristolTempBtnAnswersString = "";
            for (int i = 0; i < btn_answers.Count; i++)                     //This converts the letter_array into a string
            {
                bristolTempBtnAnswersString = bristolTempBtnAnswersString + ((character_option_visibility[i].ToString()));

                if (i < ((btn_answers.Count) - 1))                      //This adds commas between the numbers in the string
                {
                    bristolTempBtnAnswersString = bristolTempBtnAnswersString + (",");
                }
            }

            Preferences.Set("bristolBtnAnswersStore", bristolTempBtnAnswersString);         //This saves the arsenalTempBtnAnswersString



            Preferences.Set("single_button_removed_store", (single_buttons_removed.ToString()));         //Saves the number of times the single use button has been used in the long term storage
            Preferences.Set("remove_half_letters_store", (remove_half_letters_count.ToString()));         //Saves the number of times the remove half letters button has been used in the long term storage



            base.OnDestroy();

            ImageView badge_image = FindViewById<ImageView>(Resource.Id.appImgbristol);
            badge_image.SetImageDrawable(null);
            ImageView correct_image = FindViewById<ImageView>(Resource.Id.imgCorrect);
            correct_image.SetImageDrawable(null);
            ScrollView scroll_layout = FindViewById<ScrollView>(Resource.Id.scrollLayoutBristol);
            scroll_layout.SetBackgroundResource(0);
            Button left_arrow = FindViewById<Button>(Resource.Id.btnArrowLeft);
            left_arrow.Visibility = ViewStates.Gone;
            Button right_arrow = FindViewById<Button>(Resource.Id.btnArrowRight);
            right_arrow.Visibility = ViewStates.Gone;
            Button remove_letter = FindViewById<Button>(Resource.Id.btnRemoveLetter);
            remove_letter.Visibility = ViewStates.Gone;
            Button fill_random_letter = FindViewById<Button>(Resource.Id.btnFillRandomLetter);
            fill_random_letter.Visibility = ViewStates.Gone;
            Button fill_selected_letter = FindViewById<Button>(Resource.Id.btnFillSelectedLetter);
            fill_selected_letter.Visibility = ViewStates.Gone;
            Button remove_half_letters = FindViewById<Button>(Resource.Id.btnRemoveHalfLetters);
            remove_half_letters.Visibility = ViewStates.Gone;
            Button solve_letters = FindViewById<Button>(Resource.Id.btnSolveLetters);
            solve_letters.Visibility = ViewStates.Gone;

            word_array = null;
            letter_array = null;

            int n = 1;
            for (int a = 0; a < answer.Length; a++)                     //This removes all the character buttons from the screen
            {
                String btnRemove = "btn_correct" + n;
                int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                ImageView btnImage = FindViewById<ImageView>(id);
                btnImage.SetImageDrawable(null);
                n++;
            }

            n = 1;

            for (int a = 0; a < num_chars; a++)                     //This removes all the character buttons from the screen
            {
                String btnRemove = "btn" + n;
                int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                Button button = FindViewById<Button>(id);
                if (button != null)
                {
                    button.Visibility = ViewStates.Gone;
                }
                else
                {
                    a--;
                }
                n++;
            }

            n = 1;

            for (int a = 0; a < answer.Length; a++)                     //This removes all input boxes from the screen
            {
                String btnRemove = "appImgBlankBox" + n;
                int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                Button button = FindViewById<Button>(id);
                if (button != null)
                {
                    button.Visibility = ViewStates.Gone;
                }
                else
                {
                    a--;
                }
                n++;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            SetContentView(Resource.Layout.activity_bristol_badge);

            // Create your application here
            check_correct();        //This checks to see if the user has got the badge correct

            String temp_word_array = Preferences.Get("bristolCharInput", "0,0,0,0,0,0,0,0,0,0,0");
            String[] temp_word_array_split = temp_word_array.Split(",");

            for (int i = 0; i < word_array.Length; i++)
            {
                word_array[i] = Int32.Parse(temp_word_array_split[i]);
            }


            String temp_choice_array = Preferences.Get("bristolCharChoice", "0,0,0,0,0,0,0,0,0,0,0");
            String[] temp_choice_array_split = temp_choice_array.Split(",");

            for (int i = 0; i < letter_array.Length; i++)
            {
                letter_array[i] = Int32.Parse(temp_choice_array_split[i]);
            }


            String temp_char_vis_array = Preferences.Get("bristolCharOptionVis", "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1");
            String[] temp_char_vis_array_split = temp_char_vis_array.Split(",");

            for (int i = 0; i < character_option_visibility.Length; i++)
            {
                character_option_visibility[i] = Int32.Parse(temp_char_vis_array_split[i]);
            }


            String temp_char_ans_vis_array = Preferences.Get("bristolAnsOptionVis", "1,1,1,1,1,1,1,1,1,1,1");
            String[] temp_char_ans_vis_array_split = temp_char_ans_vis_array.Split(",");

            for (int i = 0; i < character_ans_visibility.Length; i++)
            {
                character_ans_visibility[i] = Int32.Parse(temp_char_ans_vis_array_split[i]);
            }

            int id_adjust = 0;

            for (int i = 0; i < character_ans_visibility.Length; i++)                       //This remove the imput boxes above the characters that have already been answered with hints
            {
                if (character_ans_visibility[i] == 0)
                {
                    id_adjust = 0;
                    for (int n = 0; n < dash_id_array.Length; n++)                      //Stops it from try to remove dashes
                    {
                        if ((i + 1) >= dash_id_array[n])
                        {
                            id_adjust = (n + 1);
                        }
                    }

                    String ResId = "appImgBlankBox" + ((i + 1) + id_adjust);
                    int id = Resources.GetIdentifier(ResId, "id", PackageName);
                    Button remove_single_btn = FindViewById<Button>(id);
                    remove_single_btn.Visibility = ViewStates.Gone;
                }
            }

            if (btn_answers.Count == 0)
            {
                String temp_char_btn_answers_array = Preferences.Get("bristolTempBtnAnswersString", "13,2,4,16,1,9,10,6,7,8,3");
                String[] temp_char_btn_answers_array_split = temp_char_btn_answers_array.Split(",");

                for (int i = 0; i < btn_answers.Count; i++)
                {
                    btn_answers.Add(Int32.Parse(temp_char_btn_answers_array_split[i]));
                }
            }

            int single_buttons_removed = Int32.Parse(Preferences.Get("single_buttons_removed_store", "0"));
            check_remove_single_letter_visibility();

            int remove_half_letters_count = Int32.Parse(Preferences.Get("remove_half_letters_store", "0"));

            if (remove_half_letters_count > 0)
            {
                hide_remove_half_letters_btn();
            }



            Boolean answered_correct = Preferences.Get("bristol_correct", false);


            for (int i = 0; i < letter_array.Length; i++)                               //This removes the characters from the options that have already been chosen previously
            {
                if (letter_array[i] != 0)
                {
                    String btnRemove = "btn" + letter_array[i];
                    int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                    Button button = FindViewById<Button>(id);
                    button.Visibility = ViewStates.Invisible;
                }
            }

            for (int i = 0; i < character_option_visibility.Length; i++)                    //This removes all the option characters from view that have been removed from the options or used
            {
                if (character_option_visibility[i] != 1)
                {
                    String btnRemove = "btn" + (i + 1);
                    int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                    Button button = FindViewById<Button>(id);
                    button.Visibility = ViewStates.Invisible;
                }
            }


            read_array();
            update_coins();                 //Updates coin count





            if (answered_correct == true)                           //This runs if the user has got the answer correct
            {
                int n = 1;

                for (int a = 0; a < num_chars; a++)                     //This removes all the character buttons from the screen
                {
                    String btnRemove = "btn" + n;
                    int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                    Button button = FindViewById<Button>(id);
                    button.Visibility = ViewStates.Gone;
                    n++;
                }


                n = 1;

                for (int a = 0; a < answer.Length; a++)                     //This removes all input boxes from the screen
                {
                    String btnRemove = "appImgBlankBox" + n;
                    int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                    Button button = FindViewById<Button>(id);
                    if (button != null)
                    {
                        button.Visibility = ViewStates.Gone;
                    }
                    else
                    {
                        a--;
                    }
                }
            }
            else if (answered_correct != true)                      //This section will run if the user hasnt got the badge correct yet
            {
                Button btn1 = FindViewById<Button>(Resource.Id.btn1);                       //This detects if the character button has been pressed
                btn1.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 20;                        //This decides the character that is displayed in the entry box
                        btn_number = 1;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn1.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn2 = FindViewById<Button>(Resource.Id.btn2);                       //This detects if the character button has been pressed
                btn2.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 18;                        //This decides the character that is displayed in the entry box
                        btn_number = 2;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn2.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn3 = FindViewById<Button>(Resource.Id.btn3);                       //This detects if the character button has been pressed
                btn3.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 25;                        //This decides the character that is displayed in the entry box
                        btn_number = 3;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn3.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn4 = FindViewById<Button>(Resource.Id.btn4);                       //This detects if the character button has been pressed
                btn4.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 9;                        //This decides the character that is displayed in the entry box
                        btn_number = 4;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn4.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn5 = FindViewById<Button>(Resource.Id.btn5);                       //This detects if the character button has been pressed
                btn5.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 21;                        //This decides the character that is displayed in the entry box
                        btn_number = 5;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn5.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn6 = FindViewById<Button>(Resource.Id.btn6);                       //This detects if the character button has been pressed
                btn6.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 3;                        //This decides the character that is displayed in the entry box
                        btn_number = 6;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn6.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn7 = FindViewById<Button>(Resource.Id.btn7);                       //This detects if the character button has been pressed
                btn7.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 9;                        //This decides the character that is displayed in the entry box
                        btn_number = 7;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn7.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn8 = FindViewById<Button>(Resource.Id.btn8);                       //This detects if the character button has been pressed
                btn8.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 20;                        //This decides the character that is displayed in the entry box
                        btn_number = 8;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn8.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn9 = FindViewById<Button>(Resource.Id.btn9);                       //This detects if the character button has been pressed
                btn9.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 15;                        //This decides the character that is displayed in the entry box
                        btn_number = 9;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn9.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn10 = FindViewById<Button>(Resource.Id.btn10);                       //This detects if the character button has been pressed
                btn10.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 12;                        //This decides the character that is displayed in the entry box
                        btn_number = 10;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn10.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn11 = FindViewById<Button>(Resource.Id.btn11);                       //This detects if the character button has been pressed
                btn11.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 21;                        //This decides the character that is displayed in the entry box
                        btn_number = 11;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn11.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn12 = FindViewById<Button>(Resource.Id.btn12);                       //This detects if the character button has been pressed
                btn12.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 21;                        //This decides the character that is displayed in the entry box
                        btn_number = 12;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn12.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn13 = FindViewById<Button>(Resource.Id.btn13);                       //This detects if the character button has been pressed
                btn13.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 2;                        //This decides the character that is displayed in the entry box
                        btn_number = 13;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn13.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn14 = FindViewById<Button>(Resource.Id.btn14);                       //This detects if the character button has been pressed
                btn14.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 20;                        //This decides the character that is displayed in the entry box
                        btn_number = 14;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn14.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn15 = FindViewById<Button>(Resource.Id.btn15);                       //This detects if the character button has been pressed
                btn15.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 20;                        //This decides the character that is displayed in the entry box
                        btn_number = 15;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn15.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn16 = FindViewById<Button>(Resource.Id.btn16);                       //This detects if the character button has been pressed
                btn16.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 19;                        //This decides the character that is displayed in the entry box
                        btn_number = 16;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn16.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn17 = FindViewById<Button>(Resource.Id.btn17);                       //This detects if the character button has been pressed
                btn17.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 16;                        //This decides the character that is displayed in the entry box
                        btn_number = 17;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn17.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btn18 = FindViewById<Button>(Resource.Id.btn18);                       //This detects if the character button has been pressed
                btn18.Click += delegate                      //This section will run if the button is pressed
                {
                    check_array();
                    if (valid == true)
                    {
                        letter = 18;                        //This decides the character that is displayed in the entry box
                        btn_number = 18;
                        write_array();                      //This runs the method the adds the letter variable into the word_array
                        btn18.Visibility = ViewStates.Invisible;                     //This makes the button invisible to the user
                        character_option_visibility[(btn_number - 1)] = 0;          //This sets the loction in visibility array to zero
                    }
                };


                Button btnImg1 = FindViewById<Button>(Resource.Id.appImgBlankBox1);                     //This detects if the input box is pressed
                btnImg1.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 0;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 0;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg2 = FindViewById<Button>(Resource.Id.appImgBlankBox2);                     //This detects if the input box is pressed
                btnImg2.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 1;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 1;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg3 = FindViewById<Button>(Resource.Id.appImgBlankBox3);                     //This detects if the input box is pressed
                btnImg3.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 2;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 2;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg4 = FindViewById<Button>(Resource.Id.appImgBlankBox4);                     //This detects if the input box is pressed
                btnImg4.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 3;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 3;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg5 = FindViewById<Button>(Resource.Id.appImgBlankBox5);                     //This detects if the input box is pressed
                btnImg5.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 4;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 4;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg6 = FindViewById<Button>(Resource.Id.appImgBlankBox6);                     //This detects if the input box is pressed
                btnImg6.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 5;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 5;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg7 = FindViewById<Button>(Resource.Id.appImgBlankBox7);                     //This detects if the input box is pressed
                btnImg7.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 6;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 6;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg8 = FindViewById<Button>(Resource.Id.appImgBlankBox8);                     //This detects if the input box is pressed
                btnImg8.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 7;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 7;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg9 = FindViewById<Button>(Resource.Id.appImgBlankBox9);                     //This detects if the input box is pressed
                btnImg9.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 8;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 8;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg10 = FindViewById<Button>(Resource.Id.appImgBlankBox10);                     //This detects if the input box is pressed
                btnImg10.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 9;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 9;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
                Button btnImg11 = FindViewById<Button>(Resource.Id.appImgBlankBox11);                     //This detects if the input box is pressed
                btnImg11.Click += delegate                       //This will run if the input box is pressed
                {
                    if (button_operation == 0)
                    {
                        array_location = 10;                     //This variable tells the program the loction of the button number in the letter_array so it know what button should become visible
                        show_letter();                      //This runs the method that makes the character re-appear in the users character options
                    }
                    else if (button_operation == 1)
                    {
                        int btnNumID = 10;
                        int btnNumIDAdjust = 0;                     //This variable is used to account for dashes when reading from arrays
                        select_fill_character(btnNumID, btnNumIDAdjust);
                    }
                };
            }

            Button btnArrowRight = FindViewById<Button>(Resource.Id.btnArrowRight);
            btnArrowRight.Click += delegate
            {
                btnArrowRight.Enabled = false;

                Handler h = new Handler();
                Action myAction = () =>
                {
                    btnArrowRight.Enabled = true;
                    Intent intent = new Intent(this, typeof(millwall_badge));
                    intent.AddFlags(ActivityFlags.NoAnimation);
                    intent.SetFlags(ActivityFlags.ClearTop);
                    StartActivity(intent);
                    this.OverridePendingTransition(0, 0);
                    Finish();
                };

                h.PostDelayed(myAction, 18);
            };

            Button btnArrowLeft = FindViewById<Button>(Resource.Id.btnArrowLeft);
            btnArrowLeft.Click += delegate
            {
                btnArrowLeft.Enabled = false;

                Handler h = new Handler();
                Action myAction = () =>
                {
                    btnArrowLeft.Enabled = true;
                    Intent intent = new Intent(this, typeof(middlesbrough_badge));
                    intent.AddFlags(ActivityFlags.NoAnimation);
                    intent.SetFlags(ActivityFlags.ClearTop);
                    StartActivity(intent);
                    this.OverridePendingTransition(0, 0);
                    Finish();
                };

                h.PostDelayed(myAction, 18);
            };

            Button remove_single_letter_btn = FindViewById<Button>(Resource.Id.btnRemoveLetter);
            remove_single_letter_btn.Click += delegate
            {
                AlertDialog.Builder mBuilder = new AlertDialog.Builder(this);                       //This will display the dialog for the remove letter button
                View mView = LayoutInflater.Inflate(Resource.Layout.remove_letter_dialog, null);

                mBuilder.SetView(mView);
                AlertDialog dialog = mBuilder.Create();
                dialog.Show();

                Button dialogCancel = mView.FindViewById<Button>(Resource.Id.btnCancel);
                dialogCancel.Click += delegate
                {
                    dialog.Hide();                      //This hides the dialog box
                };

                Button dialogUse = mView.FindViewById<Button>(Resource.Id.btnUse);
                dialogUse.Click += delegate
                {
                    dialog.Hide();                      //This hides the dialog box

                    int coinCost = 2;

                    change_coins(coinCost);

                    if (coin_count_valid == true)                       //This will run if the user has enough coins
                    {
                        remove_single_letter();     //This runs the method that removes a random letter
                        read_array();               //This displays the users character input
                        update_coins();
                    }
                    else if (coin_count_valid == false)
                    {
                        pay_coins(coinCost);            //This creates the alert box that should appear if the user doesnt have enoguh coins
                    }
                };
            };



            Button fill_random_letter_btn = FindViewById<Button>(Resource.Id.btnFillRandomLetter);
            fill_random_letter_btn.Click += delegate
            {
                AlertDialog.Builder mBuilder = new AlertDialog.Builder(this);                       //This will display the dialog for the remove letter button
                View mView = LayoutInflater.Inflate(Resource.Layout.fill_random_letter_dialog, null);

                mBuilder.SetView(mView);
                AlertDialog dialog = mBuilder.Create();
                dialog.Show();

                Button dialogCancel = mView.FindViewById<Button>(Resource.Id.btnCancel);
                dialogCancel.Click += delegate
                {
                    dialog.Hide();                      //This hides the dialog box
                };

                Button dialogUse = mView.FindViewById<Button>(Resource.Id.btnUse);
                dialogUse.Click += delegate
                {
                    dialog.Hide();                      //This hides the dialog box

                    int coinCost = 4;

                    change_coins(coinCost);

                    if (coin_count_valid == true)
                    {                                          //This will run if the user has enough coins
                        fill_random_letter();     //This runs the method that removes a random letter
                        read_array();               //This displays the users character input
                        update_coins();
                    }
                    else if (coin_count_valid == false)
                    {
                        pay_coins(coinCost);            //This creates the alert box that should appear if the user doesnt have enoguh coins
                    }
                };
            };



            Button fill_selected_letter_btn = FindViewById<Button>(Resource.Id.btnFillSelectedLetter);
            fill_selected_letter_btn.Click += delegate
            {
                AlertDialog.Builder mBuilder = new AlertDialog.Builder(this);                       //This will display the dialog for the remove letter button
                View mView = LayoutInflater.Inflate(Resource.Layout.fill_selected_letter_dialog, null);

                mBuilder.SetView(mView);
                AlertDialog dialog = mBuilder.Create();
                dialog.Show();

                Button dialogCancel = mView.FindViewById<Button>(Resource.Id.btnCancel);
                dialogCancel.Click += delegate
                {
                    dialog.Hide();                      //This hides the dialog box
                };

                Button dialogUse = mView.FindViewById<Button>(Resource.Id.btnUse);
                dialogUse.Click += delegate
                {
                    dialog.Hide();              //This hides the dialog box

                    int coinCost = 6;

                    change_coins(coinCost);

                    if (coin_count_valid == true)                       //This will run if the user has enough coins
                    {
                        for (int i = 0; i < num_chars; i++)                     //This will make all the user option characters invisible
                        {
                            if (character_option_visibility[i] == 1)
                            {
                                String ResId = "btn" + (i + 1);
                                int id = Resources.GetIdentifier(ResId, "id", PackageName);
                                Button select_hide_chars = FindViewById<Button>(id);
                                select_hide_chars.Visibility = ViewStates.Invisible;
                            }

                            String ResIdRemoveLetter = "btnRemoveLetter";                                       //This makes the remove letter button appear
                            int idRemoveLetter = Resources.GetIdentifier(ResIdRemoveLetter, "id", PackageName);
                            Button select_hide_remove_letter = FindViewById<Button>(idRemoveLetter);
                            select_hide_remove_letter.Visibility = ViewStates.Invisible;

                            String ResIdFillRandomLetter = "btnFillRandomLetter";                                       //This makes the random letter button appear
                            int idFillRandomLetter = Resources.GetIdentifier(ResIdFillRandomLetter, "id", PackageName);
                            Button select_fill_random_letter = FindViewById<Button>(idFillRandomLetter);
                            select_fill_random_letter.Visibility = ViewStates.Invisible;

                            String ResIdFillSelectedLetter = "btnFillSelectedLetter";                                       //This makes the selected letter button appear
                            int idFillSelectedLetter = Resources.GetIdentifier(ResIdFillSelectedLetter, "id", PackageName);
                            Button select_fill_selected_letter = FindViewById<Button>(idFillSelectedLetter);
                            select_fill_selected_letter.Visibility = ViewStates.Invisible;

                            String ResIdRemoveHalfLetters = "btnRemoveHalfLetters";                                     //This makes the remove half letters button appear
                            int idRemoveHalfLetters = Resources.GetIdentifier(ResIdRemoveHalfLetters, "id", PackageName);
                            Button select_remove_half_letters = FindViewById<Button>(idRemoveHalfLetters);
                            select_remove_half_letters.Visibility = ViewStates.Invisible;

                            String ResIdSolveLetters = "btnSolveLetters";                                            //This makes the solve letters button appear
                            int idSolveLetters = Resources.GetIdentifier(ResIdSolveLetters, "id", PackageName);
                            Button select_solve_letters = FindViewById<Button>(idSolveLetters);
                            select_solve_letters.Visibility = ViewStates.Invisible;
                        }

                        button_operation = 1;
                        read_array();                   //This displays the users character input
                        update_coins();
                    }
                    else if (coin_count_valid == false)
                    {
                        pay_coins(coinCost);            //This creates the alert box that should appear if the user doesnt have enough coins
                    }
                };
            };



            Button remove_half_letters_btn = FindViewById<Button>(Resource.Id.btnRemoveHalfLetters);
            remove_half_letters_btn.Click += delegate
            {
                AlertDialog.Builder mBuilder = new AlertDialog.Builder(this);                       //This will display the dialog for the remove letter button
                View mView = LayoutInflater.Inflate(Resource.Layout.remove_half_letters_dialog, null);

                mBuilder.SetView(mView);
                AlertDialog dialog = mBuilder.Create();
                dialog.Show();

                Button dialogCancel = mView.FindViewById<Button>(Resource.Id.btnCancel);
                dialogCancel.Click += delegate
                {
                    dialog.Hide();                      //This hides the dialog box
                };

                Button dialogUse = mView.FindViewById<Button>(Resource.Id.btnUse);
                dialogUse.Click += delegate
                {
                    dialog.Hide();              //This hides the dialog box

                    int coinCost = 5;

                    change_coins(coinCost);

                    if (coin_count_valid == true)                   //This will run if the user has enough coins
                    {
                        double repeat_num = (((character_option_array.Length) - (answer.Length)) - single_buttons_removed);          //Finds out home many incorrect letters are in the letter options
                        repeat_num = Math.Ceiling(repeat_num / 2);                                           //Halfs the number of incorrect letters rounds up

                        for (int i = 0; i < repeat_num; i++)            //This loop removes half of the incorrect letters from the users options
                        {
                            remove_single_letter();
                        }

                        remove_half_letters_count = 1;                  //This records the number of times the remove half letters button has been pressed

                        Button btnHalfLetters = FindViewById<Button>(Resource.Id.btnRemoveHalfLetters);
                        btnHalfLetters.Visibility = ViewStates.Gone;                        //Removes the remove half button from the screen
                        read_array();
                        update_coins();
                    }
                    else if (coin_count_valid == false)
                    {
                        pay_coins(coinCost);            //This creates the alert box that should appear if the user doesnt have enough coins
                    }
                };
            };



            Button solve_letters_btn = FindViewById<Button>(Resource.Id.btnSolveLetters);
            solve_letters_btn.Click += delegate
            {
                AlertDialog.Builder mBuilder = new AlertDialog.Builder(this);                       //This will display the dialog for the remove letter button
                View mView = LayoutInflater.Inflate(Resource.Layout.solve_letters_dialog, null);

                mBuilder.SetView(mView);
                AlertDialog dialog = mBuilder.Create();
                dialog.Show();

                Button dialogCancel = mView.FindViewById<Button>(Resource.Id.btnCancel);
                dialogCancel.Click += delegate
                {
                    dialog.Hide();                      //This hides the dialog box
                };

                Button dialogUse = mView.FindViewById<Button>(Resource.Id.btnUse);
                dialogUse.Click += delegate
                {
                    dialog.Hide();              //This hides the dialog box

                    int coinCost = 10;

                    change_coins(coinCost);

                    if (coin_count_valid == true)                   //This will run if the user has enough coins
                    {
                        word_array = answer;            //Sets the users answer to the correct answer
                        check_correct();                //Runs the method that checks if the answer is correct
                        update_coins();
                    }
                    else if (coin_count_valid == false)
                    {
                        pay_coins(coinCost);            //This creates the alert box that should appear if the user doesnt have enoguh coins
                    }
                };
            };
        }



        public void button_buzz()                       //This adds the user character input into the word_array
        {
            Boolean sound_button_setting = Preferences.Get("sound_button_setting", false);

            if (sound_button_setting == false)
            {
                player = MediaPlayer.Create(this, Resource.Raw.click_sound);
                player.Start();
            }

            Boolean button_vibration_setting = Preferences.Get("button_vibration_setting", false);         //This assigns the boolean value for the vibration settings to vibration_setting

            if (button_vibration_setting == false)
            {
                var duration = TimeSpan.FromSeconds(0.2);
                Vibration.Vibrate(duration);        //Vibrate for 200milliseconds
            }
        }



        public void clear()                     //This method changes the activity to the english_premier_league menu without an animation
        {
            Intent intent = new Intent(this, typeof(english_premier_league));
            intent.AddFlags(ActivityFlags.NoAnimation);
            intent.SetFlags(ActivityFlags.ClearTop);
            StartActivity(intent);
            this.OverridePendingTransition(0, 0);
            Finish();
        }



        public void reappear_chars_select_letter()
        {
            for (int i = 0; i < num_chars; i++)
            {
                if (character_option_visibility[i] == 1)
                {
                    String ResId = "btn" + (i + 1);
                    int id = Resources.GetIdentifier(ResId, "id", PackageName);
                    Button select_hide_chars = FindViewById<Button>(id);
                    select_hide_chars.Visibility = ViewStates.Visible;
                }
            }

            String ResIdRemoveLetter = "btnRemoveLetter";                                       //This makes the remove letter button re-appear
            int idRemoveLetter = Resources.GetIdentifier(ResIdRemoveLetter, "id", PackageName);
            Button select_hide_remove_letter = FindViewById<Button>(idRemoveLetter);
            select_hide_remove_letter.Visibility = ViewStates.Visible;

            String ResIdFillRandomLetter = "btnFillRandomLetter";                               //This makes the random letter button re-appear
            int idFillRandomLetter = Resources.GetIdentifier(ResIdFillRandomLetter, "id", PackageName);
            Button select_fill_random_letter = FindViewById<Button>(idFillRandomLetter);
            select_fill_random_letter.Visibility = ViewStates.Visible;

            String ResIdFillSelectedLetter = "btnFillSelectedLetter";                            //This makes the selected letter button re-appear
            int idFillSelectedLetter = Resources.GetIdentifier(ResIdFillSelectedLetter, "id", PackageName);
            Button select_fill_selected_letter = FindViewById<Button>(idFillSelectedLetter);
            select_fill_selected_letter.Visibility = ViewStates.Visible;

            String ResIdRemoveHalfLetters = "btnRemoveHalfLetters";                              //This makes the remove half letters button re-appear
            int idRemoveHalfLetters = Resources.GetIdentifier(ResIdRemoveHalfLetters, "id", PackageName);
            Button select_remove_half_letters = FindViewById<Button>(idRemoveHalfLetters);
            select_remove_half_letters.Visibility = ViewStates.Visible;

            String ResIdSolveLetters = "btnSolveLetters";                                        //This makes the remove solve letters button re-appear
            int idSolveLetters = Resources.GetIdentifier(ResIdSolveLetters, "id", PackageName);
            Button select_solve_letters = FindViewById<Button>(idSolveLetters);
            select_solve_letters.Visibility = ViewStates.Visible;
        }



        public void remove_single_letter()                      //This method removes a single letter that isnt needed for the answer
        {
            int[] btn_answers_array = new int[btn_answers.Count];          //This saves the variable array btn_answers to a fixed size array btn_answer_array
            btn_answers.CopyTo(btn_answers_array, 0);

            Boolean count = false;          //This sets up the boolean variable that is used to keep the random number generator generating a number until it generates a valid number
            int btnNumID = 1;

            do
            {
                Random rnd = new Random();
                btnNumID = rnd.Next(num_chars) + 1;

                int x = 0;
                count = true;

                for (int i = 0; i < btn_answers_array.Length; i++)                  //Checks that the randomly generated id isnt required for the user to be able to answer the question
                {
                    if (count != false)
                    {
                        if (btnNumID == btn_answers_array[x])
                        {
                            count = false;
                        }
                        x++;
                    }
                }
            } while (count != true);

            if (character_option_visibility[(btnNumID - 1)] == 1)                   //This runs if the letter is in the character options
            {
                String ResId = "btn" + btnNumID;
                int id = Resources.GetIdentifier(ResId, "id", PackageName);
                Button remove_single_btn = FindViewById<Button>(id);
                remove_single_btn.Visibility = ViewStates.Gone;         //Removes that character from the screen
                character_option_visibility[(btnNumID - 1)] = 0;          //Updates the array so the program knows that the letter that was removed is no longer visible
            }
            else if (character_option_visibility[(btnNumID - 1)] == 0)                  //This runs if the letter is in the answer
            {
                count = false;

                for (int i = 0; i < (letter_array.Length); i++)                     //This will run for loop for the number of characters in the answer
                {
                    if (count == false)
                    {
                        if (letter_array[i] == btnNumID)                    //This searches the answer for the letter
                        {
                            word_array[i] = 0;                      //This removes the letter from the word array
                            letter_array[i] = 0;                    //This removes the letter from the letter array
                            count = true;
                        }
                    }
                }
            }

            single_buttons_removed = single_buttons_removed + 1;
            btn_answers.Add(btnNumID);                  //Adds the character to the btn_answers array so that the program doesnt try to remove the button again

            check_remove_single_letter_visibility();
        }



        public void hide_remove_half_letters_btn()                              //This method hides the remove half letters button
        {
            Button btn_remove_half_letters = FindViewById<Button>(Resource.Id.btnRemoveLetter);
            btn_remove_half_letters.Visibility = ViewStates.Gone;
        }



        public void check_remove_single_letter_visibility()
        {
            if (single_buttons_removed > ((num_chars - (answer.Length)) - 1))                   //Detects when all the incorrect letters have been removed
            {
                Button btn_remove_single_letter = FindViewById<Button>(Resource.Id.btnRemoveLetter);
                btn_remove_single_letter.Visibility = ViewStates.Gone;

                hide_remove_half_letters_btn();
            }
        }



        public void hide_fill_random_letter_btn()                       //This method hides the fill random letters button
        {
            Button btn_fill_random_letter = FindViewById<Button>(Resource.Id.btnFillRandomLetter);
            btn_fill_random_letter.Visibility = ViewStates.Gone;
        }



        public void fill_random_letter()                        //This method fills a random correct letter in the answer
        {
            Boolean count = true;
            int x = 0;
            List<int> tempBtnNumIDAdjust = new List<int>();
            List<int> variable_answer_fill = new List<int>();

            if (random_letter_fill == 0)                        //This sets up the answer_fill_array with the button ids in a random order
            {
                x = 0;

                for (int i = 0; i < answer.Length; i++)                     //This adds a button number for the amount of buttons that there is in a random order
                {
                    Random rnd = new Random();
                    int num = rnd.Next(10);

                    count = true;

                    do
                    {
                        count = false;

                        for (int n = 0; n < dash_id_array.Length; n++)                  //Checks if x is in the dash array
                        {
                            if (dash_id_array[n] == (x + 1))
                            {
                                count = true;
                            }
                        }

                        if (count == true)
                        {
                            x++;            //Adds 1 to x if it was in the dash array to stop x been entered as a blank button id
                            tempBtnNumIDAdjust.Add(x);
                        }
                    } while (count == true);



                    if (num > 5)                        //If true it adds number to start of the array
                    {
                        variable_answer_fill.Insert(0, x);
                    }
                    else if (num < 6)                       //If True adds number to end of array
                    {
                        variable_answer_fill.Add(x);
                    }
                    x++;
                }

                int[] z = new int[tempBtnNumIDAdjust.Count];          //This saves the variable array tempBtnNumIDAdjusr to a fixed size array num_ID_adjust_array
                z = tempBtnNumIDAdjust.ToArray();
                num_ID_adjust_array = z;      //Seves the array to another array so that the scope of the variable is the whole method

                int[] y = new int[variable_answer_fill.Count];          //This saves the variable array variable_answer_fill to a fixed size array answer_fill_array
                y = variable_answer_fill.ToArray();
                answer_fill_array = y;      //Seves the array to another array so that the scope of the variable is the whole method
            }

            count = true;
            int array_pos_adjust = 0;

            int btnNumID = 0;
            int btnNumIDAdjust = 0;

            do
            {
                btnNumID = answer_fill_array[(random_letter_fill + array_pos_adjust)];       //Gets the button id from the array

                for (int i = 0; i < num_ID_adjust_array.Length; i++)                        //This adjusts the btnNumIDAdjust variable to account for the number of dashes that have been before the character
                {
                    if (btnNumID >= num_ID_adjust_array[i])
                    {
                        btnNumIDAdjust++;
                    }
                }


                String RemoveId = "appImgBlankBox" + (btnNumID + 1);
                int ID = Resources.GetIdentifier(RemoveId, "id", PackageName);
                Button btn_option_remove = FindViewById<Button>(ID);


                if (btn_option_remove.Visibility != ViewStates.Visible)
                {
                    count = true;
                    array_pos_adjust++;
                }
                else
                {
                    count = false;
                    btn_option_remove.Visibility = ViewStates.Gone;
                }
            } while (count == true);

            btnNumIDAdjust = 0;
            for (int i = 0; i < num_ID_adjust_array.Length; i++)                    //This adjusts the btnNumIDAdjust variable to account for the number of dashes that have been before the character
            {
                if (btnNumID >= num_ID_adjust_array[i])
                {
                    btnNumIDAdjust++;
                }
            }

            manager_characters(btnNumID, btnNumIDAdjust);

            word_array[(btnNumID - btnNumIDAdjust)] = answer[(btnNumID - btnNumIDAdjust)];
            random_letter_fill = random_letter_fill + 1;

            if (random_letter_fill > ((word_array.Length) - 1))
            {
                hide_fill_random_letter_btn();

                int n = 1;

                for (int a = 0; a < num_chars; a++)                     //This removes all the character buttons from the screen
                {
                    String btnRemove = "btn" + n;
                    int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                    Button button = FindViewById<Button>(id);
                    button.Visibility = ViewStates.Gone;
                    n++;
                }
            }
        }



        public void select_fill_character(int btnNumID, int btnNumIDAdjust)
        {
            String RemoveId = "appImgBlankBox" + (btnNumID + 1);
            int ID = Resources.GetIdentifier(RemoveId, "id", PackageName);
            Button btn_option_remove = FindViewById<Button>(ID);
            btn_option_remove.Visibility = ViewStates.Gone;

            manager_characters(btnNumID, btnNumIDAdjust);

            word_array[(btnNumID - btnNumIDAdjust)] = answer[(btnNumID - btnNumIDAdjust)];

            reappear_chars_select_letter();
            button_operation = 0;
            check_correct();
        }



        public void manager_characters(int btnNumID, int btnNumIDAdjust)
        {
            int x = 0;
            Boolean fill_random_count = false;

            if (word_array[(btnNumID - btnNumIDAdjust)] != answer[(btnNumID - btnNumIDAdjust)])                     //Checks if the box that has been selected in the word array is the correct letter
            {
                if (word_array[(btnNumID - btnNumIDAdjust)] != 0)                       //Checks if the box in the word array isnt blank
                {
                    String CharId = "btn" + letter_array[btnNumID];                     //Makes the button that was remove from the answer re appear in the options
                    int Charid = Resources.GetIdentifier(CharId, "id", PackageName);
                    Button char_btn = FindViewById<Button>(Charid);
                    char_btn.Visibility = ViewStates.Visible;
                    character_option_visibility[(letter_array[btnNumID] - 1)] = 1;
                }

                for (int i = 0; i < num_chars; i++)                     //This checks to see if the correct letter is in the character options
                {
                    if (character_option_array[x] == answer[(btnNumID - btnNumIDAdjust)])                       //Checks if the letter in the character option is the correct letter
                    {
                        if (character_option_visibility[x] == 1)                        //Checks if the character is visible to the user
                        {
                            if (fill_random_count != true)
                            {
                                String ResId = "btn" + (x + 1);                 //Removes that letter that has been put in the answer from the options
                                int id = Resources.GetIdentifier(ResId, "id", PackageName);
                                Button option_char = FindViewById<Button>(id);
                                option_char.Visibility = ViewStates.Invisible;
                                character_option_visibility[x] = 0;
                                fill_random_count = true;

                                character_ans_visibility[(btnNumID - btnNumIDAdjust)] = 0;
                            }
                        }
                        else if (character_option_visibility[x] == 0)
                        {
                            x++;
                        }
                    }
                    else if (character_option_array[x] != answer[(btnNumID - btnNumIDAdjust)])
                    {
                        x++;
                    }
                }

                x = 0;

                if (fill_random_count != true)                      //This is run if the letter wasnt found in the user options
                {
                    for (int i = 0; i < word_array.Length; i++)
                    {
                        if (fill_random_count != true)
                        {
                            if (word_array[x] == answer[(btnNumID - btnNumIDAdjust)])
                            {
                                word_array[x] = 0;              //Sets the location where the correct letter was so that the box is blank
                                letter_array[x] = 0;            //Removes the button id from the letter array

                                fill_random_count = true;
                            }
                            else if (word_array[x] != answer[(btnNumID - btnNumIDAdjust)])
                            {
                                x++;
                            }
                        }
                    }
                    read_array();
                }
            }
        }



        public void show_letter()
        {
            word_array[array_location] = 0;         //This removes the character from the word_array

            if (letter_array[array_location] != 0)                      //This makes the input character that was pressed re-appear in the users options
            {
                String btnImgId = "btn" + letter_array[array_location];
                int id = Resources.GetIdentifier(btnImgId, "id", PackageName);
                Button button = FindViewById<Button>(id);
                button.Visibility = ViewStates.Visible;
                character_option_visibility[(letter_array[array_location] - 1)] = 1;
                letter_array[array_location] = 0;
            }
            read_array();           //This runs the method that displays the word_array
        }



        public void check_array()                       //This method detects if there is a space in the user input characters
        {
            valid = false;
            for (int a = 0; a < answer.Length; a++)
            {
                if (word_array[a] == 0)
                {
                    valid = true;       //This been valid means there is a space in the input characters
                }
            }
        }



        public void clear_activity_memory()
        {
            ImageView badge_image = FindViewById<ImageView>(Resource.Id.appImgbristol);
            badge_image.SetImageDrawable(null);
            ImageView correctText = FindViewById<ImageView>(Resource.Id.imgCorrect);
            correctText.SetImageDrawable(null);

            int n = 1;

            for (int a = 0; a < answer.Length; a++)                     //This removes all the character buttons from the screen
            {
                String btnRemove = "btn_correct" + n;
                int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                ImageView btnImage = FindViewById<ImageView>(id);
                btnImage.SetImageDrawable(null);
                n++;
            }

            n = 1;

            for (int a = 0; a < num_chars; a++)                     //This removes all the character buttons from the screen
            {
                String btnRemove = "btn" + n;
                int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                Button button = FindViewById<Button>(id);
                button.Visibility = ViewStates.Gone;
                n++;
            }

            n = 1;

            for (int a = 0; a < answer.Length; a++)                     //This removes all input boxes from the screen
            {
                String btnRemove = "appImgBlankBox" + n;

                int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                Button button = FindViewById<Button>(id);
                button.Visibility = ViewStates.Gone;
                n++;
            }
        }



        public void correct_remove_buttons()                        //This method makes any characters that the user hasnt selected invisible when the user get the badge correct
        {
            int n = 1;
            for (int a = 0; a < num_chars; a++)                     //This makes it run the code run for the amount of characters that the user can choose from
            {
                Boolean count = false;
                int x = 0;

                for (int z = 0; z < letter_array.Length; z++)                       //This detects if the user has already chosen the character
                {
                    if (letter_array[x] == n)                       //This means the user has already selected the character so its already invisible
                    {
                        count = true;
                    }
                    else if (letter_array[x] != n)                      //This means the user hasnt selected the character so its visible to the user currently
                    {
                        x++;
                    }
                }

                if (count == false)
                {
                    String btnRemove = "btn" + n;
                    int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                    Button button = FindViewById<Button>(id);
                    button.Visibility = ViewStates.Invisible;
                }
                n++;
            }
        }



        public void pay_coins(int coinCost)
        {
            AlertDialog.Builder mBuilder = new AlertDialog.Builder(this);                       //This will display the dialog for the remove letter button
            View mView = LayoutInflater.Inflate(Resource.Layout.not_enough_coins_dialog, null);

            mBuilder.SetView(mView);
            AlertDialog dialog = mBuilder.Create();
            dialog.Show();

            Button btnCloseDialog = mView.FindViewById<Button>(Resource.Id.btnCloseDialog);
            btnCloseDialog.Click += delegate
            {
                dialog.Hide();                      //This hides the dialog box
            };

            Button btnMoreCoins = mView.FindViewById<Button>(Resource.Id.btnMoreCoins);
            btnMoreCoins.Click += delegate
            {
                dialog.Hide();                      //This hides the dialog box

                Intent intent = new Intent(this, typeof(more_coins_page));
                intent.AddFlags(ActivityFlags.NoAnimation);
                intent.SetFlags(ActivityFlags.ClearTop);
                StartActivity(intent);
                this.OverridePendingTransition(0, 0);
                Finish();
            };
        }



        public void change_coins(int coinCost)
        {
            int current_coins = Preferences.Get("coin_count", 0);         //This reads the number of coins from the coin_count variable and assigns it to coin_count_number

            if (current_coins >= coinCost)
            {
                current_coins = (current_coins - coinCost);

                Preferences.Set("coin_count", current_coins);

                coin_count_valid = true;
            }
            else
            {
                coin_count_valid = false;
            }
        }



        public void update_coins()                      //This method reads the number of coins from the sharedpreferences and displays it
        {
            int coin_count_number = Preferences.Get("coin_count", 0);         //This reads the number of coins from the coin_count variable and assigns it to coin_count_number

            TextView coinCountNum = FindViewById<TextView>(Resource.Id.coinCountText);              //This changes the number of coins text to the number in the coin_count sharedpreferences
            coinCountNum.Text = ((coin_count_number.ToString()));
        }



        public void check_correct()             //This method checks to see if the user has got the badge correct
        {
            if (Enumerable.SequenceEqual(word_array, answer))
            {
                Boolean badge_correct = Preferences.Get("bristol_correct", false);

                if (badge_correct == false)
                {
                    int eplBadgesCorrect = Preferences.Get("epl_correct_count", 0);         //This reads the number of correct epl badges and saves it to the eplBadgesCorrect variable
                    eplBadgesCorrect++;
                    Preferences.Set("epl_correct_count", eplBadgesCorrect);                //Sets the number of correct epl Badges
                }

                Preferences.Set("bristol_correct", true);

                int n = 1;

                for (int a = 0; a < answer.Length; a++)
                {
                    String btnRemove = "appImgBlankBox" + n;
                    int id = Resources.GetIdentifier(btnRemove, "id", PackageName);
                    Button button = FindViewById<Button>(id);
                    if (button != null)
                    {
                        button.Visibility = ViewStates.Gone;
                    }
                    else
                    {
                        a--;
                    }
                    n++;
                }
                View imgCorrect = FindViewById<View>(Resource.Id.imgCorrect);
                imgCorrect.Visibility = ViewStates.Visible;
                correct_remove_buttons();

                View btnRemoveLetter = FindViewById<View>(Resource.Id.btnRemoveLetter);
                btnRemoveLetter.Visibility = ViewStates.Gone;
                View btnFillRandomLetter = FindViewById<View>(Resource.Id.btnFillRandomLetter);
                btnFillRandomLetter.Visibility = ViewStates.Gone;
                View btnFillSelectedLetter = FindViewById<View>(Resource.Id.btnFillSelectedLetter);
                btnFillSelectedLetter.Visibility = ViewStates.Gone;
                View btnRemoveHalfLetters = FindViewById<View>(Resource.Id.btnRemoveHalfLetters);
                btnRemoveHalfLetters.Visibility = ViewStates.Gone;
                View btnSolveLetters = FindViewById<View>(Resource.Id.btnSolveLetters);
                btnSolveLetters.Visibility = ViewStates.Gone;

                Boolean vibration_setting = Preferences.Get("vibration_setting", false);         //This assigns the boolean value for the vibration settings to vibration_setting

                if (vibration_setting == false)
                {
                    var duration = TimeSpan.FromSeconds(0.5);
                    Vibration.Vibrate(duration);        //Vibrate for half a second
                }

                Boolean sound_correct_settings = Preferences.Get("sound_correct_settings", false);         //This assigns the boolean value for the sound correct setting to sound_correct_settings

                if (sound_correct_settings == false)
                {
                    player = MediaPlayer.Create(this, Resource.Raw.correct_sound);
                    player.Start();
                }
            }
            else   //This section will run if the user input isnt correct
            {
                View imgCorrect = FindViewById<View>(Resource.Id.imgCorrect);       //This makes the correct image invisible
                imgCorrect.Visibility = ViewStates.Invisible;
            }
        }



        public void write_array()                       //This adds the user character input into the word_array
        {
            int n = 0;
            Boolean count = false;

            for (int a = 0; a < answer.Length; a++)                     //This section finds the first empty loction in the word_array and then adds the character into it
            {
                while (count == false)
                {
                    if (word_array[n] == 0)
                    {
                        word_array[n] = letter;
                        letter_array[n] = btn_number;
                        count = true;
                    }
                    if (n < answer.Length)
                    {
                        n++;
                    }
                }
            }
            read_array();       //This runs the method that displays the users character inputs
        }



        public void read_array()                //This method interprits the numbers in the word_array to display the users character inputs
        {
            button_buzz();          //Make button presses vibrate


            int num = 1;
            int x = 0;
            for (int a = 0; a < answer.Length; a++)
            {
                String ResId = "appImgBlankBox" + num++;
                int id = Resources.GetIdentifier(ResId, "id", PackageName);
                Button button = FindViewById<Button>(id);

                if (button != null)
                {
                    if (word_array[x] == 0)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_blank_choice);
                    }
                    else if (word_array[x] == 1)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_a_choice);
                    }
                    else if (word_array[x] == 2)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_b_choice);
                    }
                    else if (word_array[x] == 3)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_c_choice);
                    }
                    else if (word_array[x] == 4)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_d_choice);
                    }
                    else if (word_array[x] == 5)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_e_choice);
                    }
                    else if (word_array[x] == 6)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_f_choice);
                    }
                    else if (word_array[x] == 7)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_g_choice);
                    }
                    else if (word_array[x] == 8)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_h_choice);
                    }
                    else if (word_array[x] == 9)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_i_choice);
                    }
                    else if (word_array[x] == 10)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_j_choice);
                    }
                    else if (word_array[x] == 11)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_k_choice);
                    }
                    else if (word_array[x] == 12)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_l_choice);
                    }
                    else if (word_array[x] == 13)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_m_choice);
                    }
                    else if (word_array[x] == 14)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_n_choice);
                    }
                    else if (word_array[x] == 15)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_o_choice);
                    }
                    else if (word_array[x] == 16)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_p_choice);
                    }
                    else if (word_array[x] == 17)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_q_choice);
                    }
                    else if (word_array[x] == 18)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_r_choice);
                    }
                    else if (word_array[x] == 19)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_s_choice);
                    }
                    else if (word_array[x] == 20)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_t_choice);
                    }
                    else if (word_array[x] == 21)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_u_choice);
                    }
                    else if (word_array[x] == 22)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_v_choice);
                    }
                    else if (word_array[x] == 23)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_w_choice);
                    }
                    else if (word_array[x] == 24)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_x_choice);
                    }
                    else if (word_array[x] == 25)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_y_choice);
                    }
                    else if (word_array[x] == 26)
                    {
                        button.SetBackgroundResource(Resource.Drawable.custom_button_normal_z_choice);
                    }
                }
                else
                {
                    x--;                    //Reduces x by 1 to make up for a dash
                    a--;                    //Reduces a by 1 to make up for a dash
                }
                x++;
            }
            check_correct();
        }
    }
}
