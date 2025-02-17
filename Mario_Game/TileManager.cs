
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Mario_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Mario_Game
{
    static class TileManager//This class will read the file and create the tiles
    {
        //Need a 2D array to store the tiles
        private static int[,] tileArray;

        /// <summary>
        /// Read the file (.txt file) to get the tile values
        /// </summary>
        /// <returns></returns>
        public static int[,] ReadFile(string filename)
        {
            //Create a connection to the text file
            StreamReader sReader = new StreamReader(filename);

            //Read the size of the file so that we can make a dynamic array
            string[] linesInFile = File.ReadAllLines(filename);
            int numberOfLines = linesInFile.Length;
            int charactersPerLine;

            //Works if all lines are the same length - which should be the case each time
            charactersPerLine = linesInFile[0].Length;
            tileArray = new int[numberOfLines, charactersPerLine];

            //A variable needed to store each line of the file (to break up later)
            string line = "";
            //A counter to count the loop number
            int counter = 0;
            //Repeat:
            do
            {
                //Read a line from the text file and store into the line variable
                line = sReader.ReadLine();
                //Iterate through each character in the line
                for (int i = 0; i < line.Length; i++)
                {
                    //Add the character from the line to the 2D array
                    tileArray[counter, i] = int.Parse(line[i].ToString());
                }
                //Check if the counter is less than the length - 1
                if (counter < line.Length - 1)
                {
                    //If it is, increase the counter by one
                    counter++;
                }
                //While the reader has not hit the end of the stream
            } while (!sReader.EndOfStream);
            //Close the streamreader
            sReader.Close();

            //Return the array to wherever the method is called
            return tileArray;
        }

        public static Tile[,] ChooseTile(int[,] tileValuesArray, Texture2D tileSheet, GraphicsDevice graphicsDev)
        {
            Tile[,] tileTypes = new Tile[tileValuesArray.GetLength(0), tileValuesArray.GetLength(1)];
            Rectangle sourceRectangle;
            Color[] data = null;
            Vector2 newPosition;
            bool collides = false;

            for (int i = 0; i < tileTypes.GetLength(0); i++)
            {
                for (int j = 0; j < tileTypes.GetLength(1); j++)
                {
                    collides = true;
                    switch (tileValuesArray[i, j])
                    {
                        case 0:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] * 80, 0, 80, 80);

                            break;
                        case 1:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] * 80, 0, 80, 80);
                            collides = false;

                            break;
                        case 2:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] * 80, 0, 80, 80);
                            break;
                        case 3:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] * 80, 0, 80, 80);
                            break;
                        case 4:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] * 80, 0, 80, 80);
                            break;
                        case 5:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] * 80, 0, 80, 80);
                            break;
                        case 6:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] * 80, 0, 80, 80);
                            break;
                        case 7:
                            sourceRectangle = new Rectangle(tileValuesArray[i, j] + 160, 160, 80, 80);
                            collides = false;
                            break;
                        default:
                            sourceRectangle = new Rectangle(0, 0, 80, 80);//Default to the firt tile in the sheet
                            break;
                    }
                    data = new Color[sourceRectangle.Width * sourceRectangle.Height];
                    tileSheet.GetData(0, sourceRectangle, data, 0, data.Length);
                    newPosition = new Vector2(i * 80, j * 80);
                    Texture2D tileTexture = new Texture2D(graphicsDev, sourceRectangle.Width, sourceRectangle.Height);
                    tileTexture.SetData(data);
                    tileTypes[i, j] = new Tile(tileTexture, 80, newPosition, collides);
                }
            }
            return tileTypes;
        }
    
    private static List<Rectangle> GetNearestBlocks(Rectangle Hitbox, int[,] tileArray)
        {
            int leftTile = (int)Math.Floor((float)Hitbox.Left / 80);
            int rightTile = (int)Math.Ceiling((float)Hitbox.Right / 80) - 1;
            int topTile = (int)Math.Floor((float)Hitbox.Top / 80);
            int bottomTile = (int)Math.Ceiling((float)Hitbox.Bottom / 80) - 1;

            leftTile = MathHelper.Clamp(leftTile, 0, tileArray.GetLength(1));
            rightTile = MathHelper.Clamp(rightTile, 0, tileArray.GetLength(1));
            topTile = MathHelper.Clamp(leftTile, 0, tileArray.GetLength(1));
            bottomTile = MathHelper.Clamp(rightTile, 0, tileArray.GetLength(1));

            List<Rectangle> result= new List<Rectangle>();
            for (int x = topTile; x <= bottomTile; x++)
            {
                for (int y = leftTile; y <= rightTile; y++)
                {
                    if (tileArray[x, y] != 0) result.Add(Coliders[x, y]);
                }
            }
            return result;
        }
    } }


