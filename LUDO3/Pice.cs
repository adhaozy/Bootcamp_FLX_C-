using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Ludogame
{
    class Pice
    {
        public string tilstand { get; set; }// Hjemme "home", I spil (på motorvejen) "ingame", I slutspil "endgame", Færdig (i mål) "goal"
        public string color; // Farve
        public int position; // Aktuelle position
        public int startPosition; //StartPosition
        public int slutPosition; //SlutPosition

        public Pice(string color)
        {

            //Fortæller at den her farve er lige med color
            this.color = color; 

            //Sætter alle brikkers tilstand til default at være hjemme
            this.setTilstand("Home");

            //Switch som modtager color som indeholder postion, startposition og slutposition
            switch (color)
            {
                case "Red":
                    this.position = 0;
                    this.startPosition = 0;
                    this.slutPosition = 38;
                    break;
                case "Green":
                    this.position = 10 % 40;
                    this.startPosition = 10;
                    this.slutPosition = 48;
                    break;
                case "Yellow":
                    this.position = 20 % 40;
                    this.startPosition = 20;
                    this.slutPosition = 58;
                    break;
                case "Blue":
                    this.position = 30 % 40;
                    this.startPosition = 30;
                    this.slutPosition = 68;
                    break;
            }
            
        }

        //Move metoden der lægger alle steps til brikkens nuværende position og finder udaf hvad tilstand brikken skal være
        public void move(int steps)
        {
            if(this.color == "Red") {
                this.position += steps;
                WriteLine("Ny position");
                if(this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame");
                    WriteLine("Red piece in endgame");
                }
                if (this.position > this.slutPosition + 5)
                {
                    this.setTilstand("Goal");
                    WriteLine("Red piece in goal");
                }
            }

            if (this.color == "Green")
            {
                this.position += steps;
                WriteLine("Ny position");
                if (this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame");
                    WriteLine("Green Piece in endgame");
                }
                if (this.position > this.slutPosition + 5)
                {
                    this.setTilstand("Goal");
                    WriteLine("Green piece in goal");
                }
            }

            if (this.color == "Yellow")
            {
                this.position += steps;
                WriteLine("Ny position");
                if (this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame");
                    WriteLine("Yellow piece in endgame");
                }
                if(this.position > this.slutPosition + 5)
                {
                    this.setTilstand("Goal");
                    WriteLine("Yellow piece in goal");
                }
            }

            if (this.color == "Blue")
            {
                this.position += steps;
                WriteLine("Ny position");
                if (this.position > this.slutPosition)
                {
                    this.setTilstand("Endgame");
                    WriteLine("Blue piece in endgame");
                }
                if (this.position > this.slutPosition + 5)
                {
                    this.setTilstand("Goal");
                    WriteLine("Blue piece in goal");
                }
            }

        }

        //´Set metode der sætter tilstanden
        public void setTilstand(string tilstand)
        {
            switch (tilstand)
            {
                case "Home":
                    this.tilstand = "Home";
                    break;
                case "Ingame":
                    this.tilstand = "Ingame";
                    break;
                case "Endgame":
                    this.tilstand = "Endgame";
                    break;
                case "Goal":
                    this.tilstand = "Goal";
                    break;
            }
        }

        //Get metode der retunere tilstand
        public string getTilstand()
        {
            return this.tilstand;
        }

        //String metode der retunere brikkens tilstand, position og farve
        public override string ToString()
        {
            return $"[tilstand:{this.tilstand}, pos:{this.position % 40}, color: {this.color}]";
        }
    }
}
