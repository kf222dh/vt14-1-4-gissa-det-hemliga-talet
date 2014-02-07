using gissa_det_hemliga_talet.Model;
using System;
using System.Web.UI.WebControls;

namespace gissa_det_hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get { return Session["secretnumber"] as SecretNumber ?? (SecretNumber)(Session["secretnumber"] = new SecretNumber()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void guess_Click(object sender, EventArgs e)
        {
            //if (Session.IsNewSession)
            //{
            //    // Meddelande...
            //}

            if (IsValid)
            {
                string message_string = "";

                //Gör om tecken som man har matat in till int
                int int_guess = Int32.Parse(TextBox.Text);


                // När en gissning har gjort så sammanfogas den med dom andra till 1 enda sträng
                SecretNumber.MakeGuess(int_guess);
                guesses.Text = string.Join(",", SecretNumber.PreviousGuesses);

                //En switch sats för varje Outcome i SecretNumber klassen
                switch (SecretNumber.Status)
                {
                    case Outcome.Low:
                        message_string = "Du gissade för lågt.";
                        break;//Bryter på satsen så att dom andra inte körs

                    case Outcome.High:
                        message_string = "Du gissade för högt.";
                        break;

                    case Outcome.PreviousGuess:
                        message_string = "Du har redan gissat på det talet.";
                        break;

                    case Outcome.Correct:
                        message_string = String.Format("Helt strålande det var korrekt det hemliga talet var {0}.", int_guess);
                        new_number.Visible = true;
                        TextBox.Enabled = false;
                        guess.Enabled = false;
                        break;

                    case Outcome.NoMoreGuesses:
                        message_string = String.Format("Det hemliga talet var {0}.", SecretNumber.Number);
                        new_number.Visible = true;
                        TextBox.Enabled = false;
                        guess.Enabled = false;
                        break;
                }
                message.Text = message_string;//Meddelande beroende på vad det var för status
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            //Skapar ett nytt hemligt tal och återställer allt.
            //Session["secretnumber"] = new SecretNumber();
            SecretNumber.Initialize();

            new_number.Visible = false;
            TextBox.Enabled = true;
            guess.Enabled = true;
        }
    }
}