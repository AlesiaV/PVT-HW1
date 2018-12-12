using System;

namespace ConsoleApp7
{
    public class Practice
    {
        /// <summary>
        /// B2-P1/1. TypeConvert. Преобразование типов используя явное, неявное преобразование и класс Convert.
        /// </summary>
        public static void B2_P1_1_TypeConvert()
        {
            string name = "Olga";
            string hasPhoto = "True";
            string flatNumber = "34";

            char sex = 'М';
            char place = '3';
            char hasFingerPrints = '0';
            
            bool hasFree2Pages = false;

            double visaPrice = 60;
            double photoPrice = 7.5;

            int birthYear = 2000;

            //1. CHAR CONVERSION 
            //1.1 CHAR to STRING

            //string charToStringImplicit = sex;                        //IMPLICIT: NOT COMPILING
            //string chartToStringExplicit = (string)sex;               //EXPLICIT: NOT COMPILING
            string charToStringUsingConverter = Convert.ToString(sex);  //CONVERT: "M"

            //1.2 CHAR to BOOL

            //bool charToBoolImplicit = hasFingerPrints;                      //IMPLICIT: NOT COMPILING
            //bool charToBoolExplicit = (bool)hasFingerPrints;                //EXPLICIT: NOT COMPILING 
            //bool charToBoolUsingConverter = Convert.ToBoolean(hasFingerPrints);    //CONVERT: System.InvalidCastException: "Недопустимое приведение "Char" к "Boolean"."
            string charToStringB = Convert.ToString(hasFingerPrints);
            int stringToIntB = Convert.ToInt32(charToStringB);
            bool IntToBoolB = Convert.ToBoolean(stringToIntB);  //CONVERT: false

            //1.3 CHAR to DECIMAL

            decimal charToDecimal1 = place;                  //IMPLICIT: 51 по таблице символов Unicode
            //decimal charToDecimal = (decimal)place;         //EXPLICIT: NOT COMPILING
            //decimal charToDecimal = Convert.ToDecimal(place); //CONVERT: System.InvalidCastException: "Недопустимое приведение "Char" к "Decimal"."
            string charToDecimal = Convert.ToString(place);
            decimal intToDecimal = Convert.ToDecimal(charToDecimal); //CONVERT: 3

            //1.4 CHAR to INT

            int charToIntI = place;       //IMPLICIT: 51 по таблице символов Unicode
            int charToInt2 = (int)place;  //EXPLICIT: 51 по таблице символов Unicode
            int charToInt3 = Convert.ToInt32(place);   //CONVERT: 51 по таблице символов Unicode

            //2. STRING CONVERSION
            //2.1 STRING to CHAR

            //char stringToChar = flatNumber;         //IMPLICIT: NOT COMPILING неявное преобразование
            //char stringToChar = (string)flatNumber; //EXPLICIT: NOT COMPILING 
            //char stringToChar = Convert.ToChar(flatNumber);   //CONVERT: System.FormatException: "Длина строки должна составлять один знак."

            //2.2 STRING to BOOL
            //bool stringToBool = hasPhoto;             //IMPLICIT: NOT COMPILING неявное преобразование
            //bool stringToBool = (bool)hasPhoto;       //EXPLICIT: NOT COMPILING
            bool stringToBool = Convert.ToBoolean(hasPhoto); //CONVERT: True 

            //2.3 STRING to DECIMAL
            //decimal stringToDecimal = flatNumber;           //IMPLICIT: NOT COMPILING неявное преобразование
            //decimal stringToDecimal = (decimal)flatNumber;  //EXPLICIT: NOT COMPILING
            decimal stringToDecimal = Convert.ToDecimal(flatNumber); //CONVERT: 34

            //2.4 STRING to INT
            //int stringToInt = flatNumber;      //IMPLICIT: NOT COMPILING неявное преобразование
            //int stringToInt = (int)flatNumber; //EXPLICIT: NOT COMPILING
            int stringToInt = Convert.ToInt32(flatNumber);   //CONVERT: 34

            //3. BOOL CONVERSION
            //3.1 BOOL to CHAR
            //char boolToChar = hasFree2Pages;          //IMPLICIT: NOT COMPILING неявное преобразование
            //char boolToChar = (char)hasFree2Pages;    //EXPLICIT: NOT COMPILING
            //char boolToChar = Convert.ToChar(hasFree2Pages); //System.InvalidCastException: "Недопустимое приведение "Boolean" к "Char"."
            int boolToChar = Convert.ToInt32(hasFree2Pages);
            char boolToChar2 = Convert.ToChar(boolToChar); //CONVERT: '\0'

            //3.2 BOOL to STRING
            //string boolToString = hasFree2Pages;           //IMPLICIT: NOT COMPILING неявное преобразование
            //string boolToString = (string)hasFree2Pages;   //EXPLICIT: NOT COMPILING
            string boolToString = Convert.ToString(hasFree2Pages); //CONVERT: "false"

            //3.3 BOOL to DECIMAL
            //decimal boolToDecimal = hasFree2Pages;           //IMPLICIT: NOT COMPILING неявное преобразование
            //decimal boolToDecimal = (decimal)hasFree2Pages;  //EXPLICIT: NOT COMPILING
            decimal boolToDecimal = Convert.ToDecimal(hasFree2Pages); //CONVERT: 0

            //3.4 BOOL to INT
            //int boolToInt = hasFree2Pages;       //IMPLICIT: NOT COMPILING неявное преобразование
            //int boolToInt = (int)hasFree2Pages;  //EXPLICIT: NOT COMPILING
            int boolToInt = Convert.ToInt32(hasFree2Pages);  //CONVERT: 0

            //4. Double CONVERSION
            //4.1 Double to CHAR
            //char doubleTochar = photoPrice;     //IMPLICIT: NOT COMPILING неявное преобразование
            char doubleTochar = (char)photoPrice; //EXPLICIT: '\a'
           // char doubleTochar1 = Convert.ToChar(photoPrice); //CONVERT: System.InvalidCastException: "Недопустимое приведение "Double" к "Char"."

            //4.2 Double to BOOL
            //bool doubleToBool = visaPrice;        //IMPLICIT: NOT COMPILING неявное преобразование
            //bool doubleToBool = (bool)visaPrice;  //EXPLICIT: NOT COMPILING
            //bool doubleToBool = Convert.ToBoolean(visaPrice); //CONVERT: System.InvalidCastException: "Недопустимое приведение "Double" к "Char"."
            int doubleToBool = Convert.ToInt32(visaPrice);
            bool doubleToBool1 = Convert.ToBoolean(doubleToBool); //CONVERT: true

            //4.3 Double to STRING
            //string doubleToString = photoPrice;           //IMPLICIT: NOT COMPILING неявное преобразование
            //string doubleToString = (string)photoPrice;   //EXPLICIT: NOT COMPILING
            string doubleToString = Convert.ToString(photoPrice);  //CONVERT: "7,5"

            //4.4 Double to INT
            //int doubleToInt = visaPrice;     //IMPLICIT: NOT COMPILING неявное преобразование
            int doubleToInt = (int)visaPrice;  //EXPLICIT: 60
            int doubleToInt1 = Convert.ToInt32(visaPrice); //CONVERT: 60

            //5. INT CONVERSION         
            //5.1 INT to CHAR
            //char intToChar = birthYear;       //IMPLICIT: NOT COMPILING неявное преобразование
            char intToChar = (char)birthYear;   //EXPLICIT:'ߐ'
            char intToChar1 = Convert.ToChar(birthYear);  //CONVERT: 'ߐ'

            //5.2 INT to BOOL
            //bool intToBool = birthYear;       //IMPLICIT: NOT COMPILING неявное преобразование
            //bool intToBool = (bool)birthYear; //EXPLICIT: NOT COMPILING
            bool intToBool = Convert.ToBoolean(birthYear);  //CONVERT: true

            //5.3 INT to DECIMAL
            decimal intToDecimal1 = birthYear;           //IMPLICIT: 2000
            decimal intToDecimal2 = (decimal)birthYear;  //EXPLICIT: 2000
            decimal intToDecimal3 = Convert.ToDecimal(birthYear);   //CONVERT: 2000

            //5.4 INT to STRING
            //string intToString = birthYear;          //IMPLICIT: NOT COMPILING неявное преобразование
            //string intToString = (string)birthYear;  //EXPLICIT: NOT COMPILING
            string intToString = Convert.ToString(birthYear);   //CONVERT: "2000"

        }
    }
}
