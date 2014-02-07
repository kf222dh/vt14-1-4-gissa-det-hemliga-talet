using System;
using System.Collections.Generic;

namespace gissa_det_hemliga_talet.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }

    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;

        //Fält och egenskap
        private int _number;

        private List<int> _previousGuesses;

        public bool CanMakeGuess
        {
            get { return Count < MaxNumberOfGuesses && !_previousGuesses.Contains(_number); }
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;//Skickar tillbaka number
            }
        }

        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        public Outcome Status
        {
            private set;
            get;
        }

        private int Count
        {
            get { return _previousGuesses.Count; }
        }

        public SecretNumber()
        {
            this._previousGuesses = new List<int>(MaxNumberOfGuesses);//Skapar en lista med 7 "platser"
            this.Initialize();
        }

        public void Initialize()
        {
            Random random = new Random();//Skapar ett random objekt som kommer att slumpa ett tal mellan 1-100
            this._number = random.Next(1, 101);
            _previousGuesses.Clear();//Tömmer listan varje gång den körs
            this.Status = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (this._previousGuesses.Contains(guess))//Kollar om gissningen är giltig
            {
                this.Status = Outcome.PreviousGuess;
                return this.Status;
            }

            this._previousGuesses.Add(guess);//Lägger till vad man har gissat innan

            if (this.Count == MaxNumberOfGuesses)//Körs om man har slut på gissningar, låser knappen så man inte kan gissa mer
            {
                if (guess == this._number)
                {
                    this.Status = Outcome.Correct;
                }
                else
                {
                    this.Status = Outcome.NoMoreGuesses;
                }
                return this.Status;
            }

            if (guess < this._number)//För låg skickar statusen
            {
                this.Status = Outcome.Low;
                return this.Status;
            }
            else if (guess > this._number)//För hög skickar statusen
            {
                this.Status = Outcome.High;
                return this.Status;
            }
            else
            {
                this.Status = Outcome.Correct;//Om gissninge var korrekt
                return this.Status;
            }
        }
    }
}