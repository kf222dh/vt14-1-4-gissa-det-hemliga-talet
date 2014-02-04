using System;
using System.Collections.Generic;

namespace gissa_det_hemliga_talet.Modal
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }

    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;

        public int? number
        {
            get
            {
                return _number;
            }
        }

        public List<int> previousGuesses
        {
            get
            {
                return _previousGuesses;
            }
        }

        public Outcome status
        {
            set;
            get;
        }

        private int count
        {
            get;
            set;
        }

        public SecretNumber()
        {
            Random random = new Random();
            this._number = random.Next(1, 100);
            this._previousGuesses = new List<int>(7);
            this.Initialize();
        }

        private void Initialize()
        {
            _previousGuesses.Clear();
            this.status = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (this.previousGuesses.Contains(guess))
            {
                this.status = Outcome.PreviousGuess;
                return this.status;
            }

            this.count += 1;
            this.previousGuesses.Add(guess);

            if (this.count == 7)
            {
                if (guess == this.number)
                {
                    this.status = Outcome.Correct;
                }
                else
                {
                    this.status = Outcome.NoMoreGuesses;
                }
                return this.status;
            }

            if (guess < this.number)
            {
                this.status = Outcome.Low;
                return this.status;
            }
            else if (guess > this.number)
            {
                this.status = Outcome.High;
                return this.status;
            }
            else
            {
                this.status = Outcome.Correct;
                return this.status;
            }
        }
    }
}