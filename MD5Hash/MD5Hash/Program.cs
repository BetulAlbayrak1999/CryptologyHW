using System;
/*
 * this program is written by Betül ALBAYRAK
 * Here we used MD5Hash on 2 different sentence. Each one of them has 500 character, then we encrypted them and the result was:
 * Hello!
    Your 1.sentence is:
    1. original str:
    MGKBMAVFEAZCPZTDATCLGVCGCBSUIXAAXNOFFKUNOMOPETRMMYAFIWHREDYLHBXHAZFCLNYQZPXTGMCJJGHKXVRAFWBBLJFNPHPEOPBZZKGSZNKRAPBBTMKFHFWOMWEQJKEZXYUUEIKMOYARLJAVHDTCXJWJSMMDFQIPJLUCUHWLCXQIEFCCVIIGQCBNBLBRVGHYQLIAPYBZHIAATOENKKHWHCZGJGBIGEPVPRSSWCMXHJYHCBUNHOHLZKRNLBQJXSTCTEKBVLQIXKPYDSEIMNBSXDWFAFGVLDAPPWNXRSRVXZOOUTJTXIWJQBFPIFBQEVWTKZIHEGRTWGUXPHKHWNXCGQYORYPLRBQCCVEVKBPRRDNKGHZAUUTRXTMTBUPFQFBUPSVUDPWUXGLDDOHKYPRXHYEIIKTQMJAMBSUOLFWFXZURIIQMMFHAOEMQNMLTVFIOFYBKTTYSTLZIENAZTGEHCAYXGDBZTDJSRFMJGGTTGOHCEEM
    1. Hashed str:
    56DFA1F2A81FB7722B8F190B96FBA698



    Your 2.sentence is:
    2. original str:
    ADTOBVXJIMTYMPAVARSXDZGIQXXGQKHQLECFLADZCHKWPFOJNZFHWPEAWKYDXRTYFDMIMUJANSVVPKSLJOSQFZTWABIACZBLNMRMSGWTPETEUILMSMUJYDSFJQIKMJYOQJIDTGSDRZAAGPBRQVIPFSMKTLDCXLGGFFNKZITMUQRZCRZTOQUQAJIXWYJHDPFGSTUBBRSICWUOBMHCMJOHRQGWWPNBYLJFLLHIWXSXXLNEPTWKQHVTBXOCNYELDQKRMPDPFYFOQQJFCBHDTDKQPPDOWFVYTGUGBWRZQGERCHDKNIZMRBSZGTBXLOTZDHVKWCEFJHMMYSOIMTANFIGROUAIVUOBNEOULSNKEUCJOFANESLROFUUAEWBCWKOSLZTEUXTGQJLGWCIUNDCJXNHKTUHWLIIJNRDGGIKVSLXWJODBNHPSHFVXRJLZPWUHBBSFYBNETHQLPLBEQGIESPCHVGOXXKFVRPVHWXCLTLZZPKHFHHIJNQ
    2. Hashed str:
    63E2A32239873606F2D31ADE04D3D7A6
* my comment is: 
* As can see Hashed sentences are different, that is because the sentences that we hashed are not the same
 */

namespace MD5Hash
{
    class Program
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

        public static string GenerateString()
        {
            // Creating object of random class
            Random rand = new Random();

            // Choosing the size of string
            // Using Next() string
            int stringlen = rand.Next(499, 500);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                // Generating a random number.
                randValue = rand.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string.
                str = str + letter;
            }
            return str;
        }

        static void Main(string[] args)
        {
            //1.sentence
            Console.WriteLine("Hello!");
            Console.WriteLine("Your 1.sentence is:");
            Console.WriteLine("1. original str:");
            string currentStr1 = GenerateString();
            Console.WriteLine(currentStr1);
            Console.WriteLine("1. Hashed str:");
            string hashedStr1 = CreateMD5(currentStr1);
            Console.WriteLine(hashedStr1);

            Console.WriteLine("\n\n");
            //2.sentence
            Console.WriteLine("Your 2.sentence is:");
            Console.WriteLine("2. original str:");
            string currentStr2 = GenerateString();
            Console.WriteLine(currentStr2);
            Console.WriteLine("2. Hashed str:");
            string hashedStr2 = CreateMD5(currentStr2);
            Console.WriteLine(hashedStr2);

        }
    }
}
