/*
 * BY: Eve Boulanger, Reina Li, Matthew Zhu, Melody Yang
 * 
 * PURPOSE: This program takes a txt file from HUAWEI Atlas 200 Developer Kit
 * which uses object recognition to recognize each food product within the fridge.
 * This program reads through the txt file and records the quantity of each food item and also accepts input data from the user to search through the file.
 * This user inputted data tells the program what food product they want information about and the desired quantity of this food product.
 * This program then outputs the quantity of everything in the fride as well as the quantity of the specified food product that the user should buy to reach their desired quantity.
 */



using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;

namespace food_info
{

    class FoodInfo
    {
        public string FoodItem     { get; private set; }  // quote
        public string Quantity	   { get; private set; }  // person who said the quote

        public FoodInfo( string foodItem, string quantity )
        {
            FoodItem   = foodItem;
            Quantity   = quantity;
        }
    }

    static class Program
    {
        static void Main( )
        {
            List< FoodInfo > record = new List< FoodInfo >();
            
            const string path = "food_quantity.txt";
            const FileMode mode = FileMode.Open;
            const FileAccess access = FileAccess.Read;
            
            using FileStream file = new FileStream( path, mode, access );
            using StreamReader reader = new StreamReader( file );
            
            WriteLine( "Which food product would you like to get information about (type in lowercase)?");
			string userSearch = ReadLine();
			WriteLine( $"What quantity of {userSearch} do you want to have?");
			int prefQuantity = int.Parse(ReadLine());
			
			string searchOutput ="";
            
            while (! reader.EndOfStream )
            {
				string foodItem = reader.ReadLine( );
				string quantity = reader.ReadLine( );
				int quantity1 = int.Parse(quantity);
				
				if(userSearch == foodItem)
				{
					searchOutput += $"You currently have {quantity} {foodItem}(s).\nYou want {prefQuantity} {foodItem}(s).\nYou should buy {prefQuantity - quantity1} from the grocery store.";
				}
				
				char[] arr = foodItem.ToCharArray();
				string firstChar = "";
				
				firstChar = firstChar + arr[0] ;
				string foodItemUpdated = firstChar.ToUpper();
				
				for(int i = 1; i < arr.Length; i ++)
				{
					foodItemUpdated += arr[i];
				}
				
				WriteLine( "{0} x{1}", foodItemUpdated, quantity );
					
				FoodInfo records = new FoodInfo(foodItem, quantity);
					record.Add( records );
			} 
			
			WriteLine(searchOutput);
			WriteLine();
        }
    }
}
