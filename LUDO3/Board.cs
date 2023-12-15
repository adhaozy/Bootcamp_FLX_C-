using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Ludogame
{
    class Board
    {
        //Mendapatkan kelas yang berbeda dan membuat array ubin dan bidang.
        private Pice[] brikker = new Pice[16];
        private Felt[] felt = new Felt[40];
        private Dice terning;
        public Board()
        {
            //Memberitahukan bahwa kelas kubus adalah = this.terning
            this.terning = new Dice();

            //Mengisi koordinat X dan Y pada array field
            felt[0] = new Felt(2, 7);
            felt[1] = new Felt(3, 7);
            felt[2] = new Felt(4, 7);
            felt[3] = new Felt(5, 7);
            felt[4] = new Felt(5, 8);
            felt[5] = new Felt(5, 9);
            felt[6] = new Felt(5, 10);
            felt[7] = new Felt(5, 11);
            felt[8] = new Felt(6, 11);
            felt[9] = new Felt(7, 11);
            felt[10] = new Felt(7, 10);
            felt[11] = new Felt(7, 9);
            felt[12] = new Felt(7, 8);
            felt[13] = new Felt(7, 7);
            felt[14] = new Felt(8, 7);
            felt[15] = new Felt(9, 7);
            felt[16] = new Felt(10, 7);
            felt[17] = new Felt(11, 7);
            felt[18] = new Felt(11, 6);
            felt[19] = new Felt(11, 5);
            felt[20] = new Felt(10, 5);
            felt[21] = new Felt(9, 5);
            felt[22] = new Felt(8, 5);
            felt[23] = new Felt(7, 5);
            felt[24] = new Felt(7, 4);
            felt[25] = new Felt(7, 3);
            felt[26] = new Felt(7, 2);
            felt[27] = new Felt(7, 1);
            felt[28] = new Felt(6, 1);
            felt[29] = new Felt(5, 1);
            felt[30] = new Felt(5, 2);
            felt[31] = new Felt(5, 3);
            felt[32] = new Felt(5, 4);
            felt[33] = new Felt(5, 5);
            felt[34] = new Felt(4, 5);
            felt[35] = new Felt(3, 5);
            felt[36] = new Felt(2, 5);
            felt[37] = new Felt(1, 5);
            felt[38] = new Felt(1, 6);
            felt[39] = new Felt(1, 7);

            //Fylder farver i brikker arrayet
            brikker[0] = new Pice("Red");
            brikker[1] = new Pice("Red");
            brikker[2] = new Pice("Red");
            brikker[3] = new Pice("Red");
            brikker[4] = new Pice("Green");
            brikker[5] = new Pice("Green");
            brikker[6] = new Pice("Green");
            brikker[7] = new Pice("Green");
            brikker[8] = new Pice("Yellow");
            brikker[9] = new Pice("Yellow");
            brikker[10] = new Pice("Yellow");
            brikker[11] = new Pice("Yellow");
            brikker[12] = new Pice("Blue");
            brikker[13] = new Pice("Blue");
            brikker[14] = new Pice("Blue");
            brikker[15] = new Pice("Blue");

            //Spilleren angiver antal spillere imellem 2 og 4
            WriteLine("Angiv antal spillere, 2-4");
            int playerAmount = int.Parse(ReadLine());

            //Opretter et string array med de forskellige spiller farver
            string[] players = new string[] { "Red", "Green", "Yellow", "Blue" };

            //Int rounds tæller hvormange spillerunder der har været 
            int rounds = 0;
            
            //While loopet der stopper når der er fundet en winner, det er her spillet køre
            while (!winner())
            {
                rounds++; 
                //Forloop over antal spillere
                for (int o = 0; o < playerAmount; o++)
                {
                    //Metode der styre selve spillet
                    doPlayer(players[o], rounds);
                }
                
            }
            //Fortæller spillet er slut
            WriteLine("Game over");
        }

        public void doPlayer(string colour, int rounds)
        {
            //Læser om der bliver trykket på en tast
            ReadKey();
            
            //Terning kast
            int tk = terning.kast();

            //Udskriver hvormange runder der er spillet, hvad for en farve der rykkede og hvad antal terningen slog            
            WriteLine($"Round {rounds} Move colour {colour} dice: {tk}  ");

            //Bool der er default false
            bool flytUd = false;

            //Tjekker om man har slået en 6'er
            if (tk == 6)
            {

                //Tjekker hvad farve der har slået og bruger så metoden til at tjkke om der skal smides en brik i "Ingame"
                if (colour == "Red")
                {
                    flytUd = this.putRedInGame();
                }
                if (colour == "Green")
                {
                    flytUd = this.putGreenInGame();
                }
                if (colour == "Yellow")
                {
                    flytUd = this.putYellowInGame();
                }
                if (colour == "Blue")
                {
                    flytUd = this.putBlueInGame();
                }
            }

            //Tjekker om flytud stadig er false
            if (!flytUd)
            {
                //
                if (!this.movePieces(tk, colour))
                {
                    WriteLine($"Could neither move " + colour + " piece or set in game!");
                }
            }
            this.status(colour);
        }

        //Metode der udskriver brikkens status
        public void status(string colour)
        {
            if (colour == "Red")
            {
                this.piecesStatusRed();
            }
            if (colour == "Green")
            {
                this.piecesStatusGreen();
            }
            if (colour == "Yellow")
            {
                this.piecesStatusYellow();
            }
            if (colour == "Blue")
            {
                this.piecesStatusBlue();
            }
        }

        //Metode der opretter statusen på rød
        public void piecesStatusRed()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Status på rød");
            for (int n = 0; n < 4; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();
            WriteLine();
        }

        //Metode der opretter statusen på grøn
        public void piecesStatusGreen()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Status på grøn");
            for (int n = 4; n < 8; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();   
            WriteLine();
        }

        //Metode der opretter statusen på gul
        public void piecesStatusYellow()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Status på gul");
            for (int n = 8; n < 12; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();
            WriteLine();
        }

        //Metode der opretter statusen på blå
        public void piecesStatusBlue()
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("Status på blå");
            for (int n = 12; n < 16; n++)
            {
                WriteLine(this.brikker[n]);
            }
            ResetColor();
            WriteLine();
        }

        //Metode der modtager terningskastet og farven på den spiller hvis tur det er, metoden tjekker så om der er nogle brikker på positionen, for derefter at rykke brikken
        public bool movePieces(int eyes, string colour)
        {
            //Forloop med antal brikker
            for (int i = 0; i < 16; i++)
            {
                //Tjekker om brikkens tilstand er "Ingame" og om farven er lige med denne farve
                if (brikker[i].getTilstand() == "Ingame" && this.brikker[i].color == colour)
                {
                    //Tjekker om metoden brikkerOnPos retunere 0     
                    if (this.brikkerOnPos(this.brikker[i].position + eyes) == 0)
                    {
                        //Udskriver hvad terningen slog, rykker brikken og retunere true
                        WriteLine($"Moves piece: {eyes}");
                        this.brikker[i].move(eyes);
                        return true;
                    }
                    //Tjekker om metoden brikkerOnPos retunere noget der der ikke er lige med 0
                    else if (this.brikkerOnPos(this.brikker[i].position + eyes) != 0)
                    {
                        //Int nextPos er lige med brikkens position + terninge slaget
                        int nextPos = this.brikker[i].position + eyes;

                        //Forloop med alle brikkerne
                        for (int n = 0; n < 16; n++)
                        {
                            //Tjekker om der står en brik på den næsten position, at brikkens farve ikke er lige med spillerens farve og om brikken er ingame
                            if (this.brikker[n].position == nextPos && this.brikker[n].color != colour && this.brikker[n].tilstand == "Ingame")
                            {
                                //Sætter brikkerne til tilstand "Home", resetter nuværende positionen og udskriver brikkens farve og "Return to start"
                                this.brikker[n].setTilstand("Home");
                                this.brikker[n].position = this.brikker[n].startPosition;
                                WriteLine(this.brikker[n].color + " Return to start");
                                return true;
                            }
                        }
                        //Rykker brikken og udskriver 
                        this.brikker[i].move(eyes);
                        WriteLine($"Moves piece: {eyes}");
                        return true;
                    }
                    else
                    {
                        //Rykker rbikken
                        this.brikker[i].move(eyes);
                        return true;
                    }
                }
                
                //Tjekker om brikken er i "Endgame" og rykker den
                if (brikker[i].getTilstand() == "Endgame")
                {
                    this.brikker[i].move(eyes);
                    return true;
                }
            }
            return false;
        }

        //Metode der tjekker om rød har nogle brikker i "Home" ellers sætter den tilstanden til "Ingame" og retunere true
        public bool putRedInGame()
        {
            for (int i = 0; i < 4; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts red in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Metode der tjekker om grøn har nogle brikker i "Home" ellers sætter den tilstanden til "Ingame" og retunere true
        public bool putGreenInGame()
        {
            for (int i = 4; i < 8; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts Green in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Metode der tjekker om gul har nogle brikker i "Home" ellers sætter den tilstanden til "Ingame" og retunere true
        public bool putYellowInGame()
        {
            for (int i = 8; i < 12; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts Yellow in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Metode der tjekker om blå har nogle brikker i "Home" ellers sætter den tilstanden til "Ingame" og retunere true
        public bool putBlueInGame()
        {
            for (int i = 12; i < 16; i++)
            {
                if (this.brikker[i].getTilstand() == "Home")
                {
                    WriteLine("Puts Blue in the game!");
                    this.brikker[i].setTilstand("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Tjekker om der er nogle brikker på den næste position du er ved at rykke til og om de brikker er "Ingame"
        public int brikkerOnPos(int pos)
        {
            int antalBrikker = 0;
            foreach (Pice p in this.brikker) {
                if (p.position % 40 == pos && p.tilstand == "Ingame")
                    antalBrikker++;
            }
            return antalBrikker;
        }

        //Metode der tjekker om alle brikker i en bestemt farve er i tilstand "Goal" og retunere true hvis en farve har alle brikker i mål ellers retunere den false
        public bool winner()
        {
            int red = 0;
            for (int n = 0; n < 4; n++)
            {
               if(this.brikker[n].getTilstand() == "Goal")
               {
                    red++;
               }
               if(red == 4)
                {
                    WriteLine("Red wins");
                    return true;
                }
            }
            int green = 0;
            for (int n = 4; n < 8; n++)
            {
                if (this.brikker[n].getTilstand() == "Goal")
                {
                    green++;
                }
                if (green == 4)
                {
                    WriteLine("Green wins");
                    return true;
                }
            }
            int yellow = 0;
            for (int n = 8; n < 12; n++)
            {
                if (this.brikker[n].getTilstand() == "Goal")
                {
                    yellow++;
                }
                if (yellow == 4)
                {
                    WriteLine("Yellow wins");
                    return true;
                }
            }
            int blue = 0;
            for (int n = 12; n < 16; n++)
            {
                if (this.brikker[n].getTilstand() == "Goal")
                {
                    blue++;
                }
                if (blue == 4)
                {
                    WriteLine("Blue wins");
                    return true;
                }
            }
            return false;
        }
    }
}