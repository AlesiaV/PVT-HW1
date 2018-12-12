using System;

namespace ConsoleApp7
{
    public partial class Lesson
    {
        public static void StackAndHeapExample()
        {
            bool    hasPhoto = true;
            int     adultAge = 18;
            int     age = 18;

            string  name = "Olga";
            string  surname = "Pupkina";
            string  address = "Минск, Кропоткина 55, оф. 50";

            string  workingAddress = address;
        }

        public static void TypeFromConvertExample()
        {
            string flat = "34";

            int flatNuber = int.Parse(flat);
            int flatNuber2 = Convert.ToInt32(flat);

            

            //int flatNuber3 = int.Parse("ewe");
            //int flatNuber4 = Convert.ToInt32("sdfdf");

            //int flatNumber = flat;

            char sex = 'М';
            //string sexstrin = sex;
            int sexInt = sex;
            string sexstrin = Convert.ToString(sex);

            char place = '3';
            int place2 = place;

            double percent = 75.5;
            int prersent = (int)percent;

            int weight = 55;
            float weihtInt = weight;
        }

        public static void TypeToConvertExample()
        {
            int flat = 34;

            string sex = "М";

            int percent = 75;

            double weight = 55.0f;
        }

        public static void TypeConvertExample()
        {
            string flat = "34";
            char sex = 'М';
            double percent = 75.5;
            int weight = 55;

            int flat2;
            string sex2;
            int precent2;
            double weight2;

            //TODO: Do converting.
        }
    }
}
