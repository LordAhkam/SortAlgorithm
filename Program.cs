using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectionSortAlgorithm selectionSortAlgorithm = new SelectionSortAlgorithm();
            selectionSortAlgorithm.SelectionSortAlgorithmMain();

            Console.ReadLine();
        }
    }
    class SelectionSortAlgorithm  //Seçim sıralama algoritmasıdır
    {
        protected int[] Numbers;

        protected Random random = new Random(); //Random sayı oluşturmak için kullanılır.
        protected HashSet<int> UniqueNumbers = new HashSet<int>(); //İçerisine eklenecek olan bütün sayıların benzersiz olması için kullanılır.

        public void SelectionSortAlgorithmMain()
        {
            Numbers = Numbersİnput(); //Sıralanacak sayı alınmmasını sağlayan fonksiyon.

            Console.WriteLine("sırasız yazma");
            foreach (int num in Numbers) //Alınan değerlerin sıralanmadan yazılması.
            {
                Console.Write("{0}, ", num);
            }

            int[] sort = SelectionSort(); //Numbers arrayi içerisindeki değerlerin sıralanmasını sağlayan fonksiyon.

            Console.WriteLine("\nsıralı yazma");
            foreach (int num in Numbers) //Alınan değişkenlerin sıralanmış halini yazdırır.
            {
                Console.Write("{0}, ", num);
            }
        }
        int[] Numbersİnput() //Sıralanacak sayıların eklenmesini sağlayacak algoritma.
        {
            Console.Write("Sayı eklemek istiyor musunuz (eklemek için '1' tuşuna basın)"); //Kullanıcı sayı ekleyecek mi kontrolu yapılır.
            string EklemeKontrolü = Console.ReadLine();

            if (EklemeKontrolü != "1") //Eğer Numbers arrayine sayı eklenmeyecekse Rastgele sayılar oluşturulur ve arraya eklenir.
            {
                Numbers = new int[10];

                while (UniqueNumbers.Count < Numbers.Length)
                {
                    int RandomNumber = random.Next(0, 101); //0 ile 100 arasında rastgele sayılar üretilir.
                    UniqueNumbers.Add(RandomNumber); //Üretilen sayının UniqueNummbers listesine eklenir.
                }

                Numbers = UniqueNumbers.ToArray(); //Listeyi Number arrayine eklenir.

                return Numbers;
            }
            else
            {
                Console.Write("Sıralanacak sayı adedini giriniz: "); //Kaç sayı sıralanmak istenirse adet girilir.
                int NumbersLength = int.Parse(Console.ReadLine());

                Numbers = new int[NumbersLength]; //Uzunluk dizi boyutuna tanımlanır.

                for (int i = 0; i < Numbers.Length; i++)
                {
                    Console.Write("Lütfen sıralanacak {0}. sayıyı giriniz: ", i + 1); //Eklenece sayıların girilmesi için kullanılacak kısım.
                    Numbers[i] = int.Parse(Console.ReadLine());
                }

                return Numbers;
            }
        }
        int[] SelectionSort()
        {
            for (int i = 0; i < Numbers.Length - 1; i++) //En küçük elemanın indexini bulma
            {
                int MinIndex = i;

                for (int j = i + 1; j < Numbers.Length; j++)
                {
                    if (Numbers[j] < Numbers[MinIndex])
                    {
                        MinIndex = j;
                    }
                }
                //Bulunan en küçük elemanın yerini değiştir
                int Temp = Numbers[MinIndex];
                Numbers[MinIndex] = Numbers[i];
                Numbers[i] = Temp;
            }
            return Numbers;
        }
    }
}