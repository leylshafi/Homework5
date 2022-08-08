namespace Homework5;

enum Gender { None, Male, Female };
class Animal
{
    public string Nickname { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public int Energy { get; set; }
    public float Price { get; set; }
    public int MealQuantity { get; set; }

    public Animal()
    {
        Nickname = default;
        Age = default;
        Gender = Gender.None;
        Energy = default;
        Price = default;
        MealQuantity = default;
    }

    public Animal(string nickname, int age, Gender gender, int energy, float price, int mealQuantity)
    {
        Nickname = nickname;
        Age = age;
        Gender = gender;
        Energy = energy;
        Price = price;
        MealQuantity = mealQuantity;
    }

    virtual public void Eat()
    { }

    virtual public void Sleep()
    { }

    virtual public void Play()
    { }
}

class Cat : Animal
{

    int MaxCatEnergy;

    public Cat(string nickname, int age, Gender gender, int energy, float price, int mealQuantity)
        : base(nickname, age, gender, energy, price, mealQuantity)
    {
        MaxCatEnergy = energy;
    }
    public override void Eat()
    {
        if (base.MealQuantity != 0)
        {
            base.Energy += 10;
            base.Age += 1;
            base.Price += 50;
            base.MealQuantity -= 1;
        }
        else Console.WriteLine("No enough meal quantity");
    }

    public override void Play()
    {
        base.Energy -= 50;
        if (base.Energy == 0)
        {
            Console.WriteLine("He went to sleep");
            Sleep();
        }
    }

    public override void Sleep()
    {
        base.Energy = MaxCatEnergy;
    }
}

class Dog : Animal
{
    int MaxDogEnergy;

    public Dog(string nickname, int age, Gender gender, int energy, float price, int mealQuantity)
        : base(nickname, age, gender, energy, price, mealQuantity)
    {
        MaxDogEnergy = energy;
    }
    public override void Eat()
    {
        if (base.MealQuantity != 0)
        {
            base.Energy += 40;
            base.Age += 2;
            base.Price += 100;
            base.MealQuantity -= 1;
        }
        else Console.WriteLine("No enough meal quantity");
    }

    public override void Play()
    {
        base.Energy -= 100;
        if (base.Energy == 0)
        {
            Console.WriteLine("He went to sleep");
            Sleep();
        }
    }

    public override void Sleep()
    {
        base.Energy = MaxDogEnergy;
    }
}





class Program
{
    static public Animal[] RemoveByNickname(Animal[] animals, string nickname)
    {
        int index;
        Animal[] temp = new Animal[animals.Length - 1];
        for (int i = 0, j = 0; i < animals.Length; i++)
        {
            if (animals[i].Nickname == nickname)
            {
                continue;
            }
            else temp[j++] = animals[i];
        }
        return temp;
    }
    static void Main()
    {
        //Cat cat = new Cat("Kitty",1,Gender.Female,200,100,4);
        //cat.Play();
        //Console.WriteLine(cat.Energy);
        //cat.Sleep();
        //Console.WriteLine(cat.Energy);


        Animal[] animals = { new Cat("Kitty", 1, Gender.Female, 200, 100, 4) ,
        new Dog("Toplan",3,Gender.Male,100,300,5),
        new Cat("Mesdan", 2, Gender.Male, 400, 300, 3) };

        animals[1].Play();
        Console.WriteLine(animals[1].Energy);


        animals = RemoveByNickname(animals, "Kitty");

        for (int i = 0; i < animals.Length; i++)
        {
            Console.WriteLine(animals[i].Nickname);
        }

    }
}
