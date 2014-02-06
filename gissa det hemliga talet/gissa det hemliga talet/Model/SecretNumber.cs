using System;
using System.Collections.Generic;

namespace gissa_det_hemliga_talet.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }

    public class SecretNumber
    {
        //Fält och egenskap
        private int _number;

        private List<int> _previousGuesses;

        public int number
        {
            get
            {
                return _number;//Skickar tillbaka number
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
            Random random = new Random();//Skapar ett random objekt som kommer att slumpa ett tal mellan 1-100
            this._number = random.Next(1, 100);
            this._previousGuesses = new List<int>(7);//Skapar en lista med 7 "platser"
            this.Initialize();
        }

        private void Initialize()
        {
            _previousGuesses.Clear();//Tömmer listan varje gång den körs
            this.status = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (this.previousGuesses.Contains(guess))//Kollar om gissningen är giltig
            {
                this.status = Outcome.PreviousGuess;
                return this.status;
            }

            this.count += 1;//Räknare som plusar varje gång
            this.previousGuesses.Add(guess);//Lägger till vad man har gissat innan

            if (this.count == 7)//Körs om man har slut på gissningar, låser knappen så man inte kan gissa mer
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

            if (guess < this.number)//För låg skickar statusen
            {
                this.status = Outcome.Low;
                return this.status;
            }
            else if (guess > this.number)//För hög skickar statusen
            {
                this.status = Outcome.High;
                return this.status;
            }
            else
            {
                this.status = Outcome.Correct;//Om gissninge var korrekt
                return this.status;
            }
        }
    }
}