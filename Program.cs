using System;
using System.Text;
using System.Collections.Generic;
/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

int[] CommonItems(int[][] jaggedArray)
{
   var repetativeArray = new List<int>();

   foreach (var item in jaggedArray[0])
   {
    if(Array.Exists( jaggedArray[1], element => element == item))
    {
        repetativeArray.Add(item);
    }    
   }

   return repetativeArray.ToArray();
}
int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
int[] arr1Common = CommonItems(arr1);
/* write method to print arr1Common */

Console.WriteLine("int [] {0}",String.Join(",", arr1Common));

/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/
void InverseJagged(int[][] jaggedArray)
{   
    for(int i = 0; i < jaggedArray.Length; i++) 
    {
        Array.Reverse(jaggedArray[i]);
    }
}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);
/* write method to print arr2 */
for ( int i = 0; i< arr2.Length; i++ ) {
    foreach(var j in arr2[i]){
        Console.WriteLine(j + " ");
    }
    Console.WriteLine();
}

/*Challenge 3.Find the difference between 2 consecutive elements of an array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
 */
void CalculateDiff(ref int[][] jaggedArray)
{
    int[][] newJaggedArray = new int[jaggedArray.Length][];
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        int[] newArray = new int[jaggedArray[i].Length - 1];
        for (int j = 0; j < jaggedArray[i].Length - 1; j++)
        {
            newArray[j] = jaggedArray[i][j] - jaggedArray[i][j + 1];
        }
        newJaggedArray[i] = newArray;
    }
    jaggedArray = newJaggedArray;
}

int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(ref arr3);

// Print the modified jagged array
for (int k = 0; k < arr3.Length; k++)
{
    for (int m = 0; m < arr3[k].Length; m++)
    {
        Console.WriteLine(arr3[k][m]);
    }
}

/* 
Challenge 4. Inverse column/row of a rectangular array.
For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
Expected result: {{1,4},{2,5},{3,6}}
 */
int[,] InverseRec(int[,] recArray)
{
    int[,] updatedArray = new int[recArray.GetLength(1), recArray.GetLength(0)];
    
    for (int i = 0; i < recArray.GetLength(0); i++)
    {
        for (int j = 0; j < recArray.GetLength(1); j++)
        {
            updatedArray[j, i] = recArray[i, j];
        }
    }
    
    return updatedArray;
}

int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);
/* write method to print arr4Inverse */

for (int i = 0; i < arr4Inverse.GetLength(0); i++)
{
    for (int j = 0; j < arr4Inverse.GetLength(1); j++)
    {
        Console.Write(arr4Inverse[i, j] + " ");
    }
    Console.WriteLine();
}


/* 
Challenge 5. Write a function that accepts a variable number of params of any of these types: 
string, number. 
- For strings, join them in a sentence. 
- For numbers then sum them up. 
- Finally print everything out. 
Example: Demo("hello", 1, 2, "world") 
Expected result: hello world; 3 */
void Demo(params object[] values)
{   
    StringBuilder newString = new StringBuilder();
    int newNumber = 0;
    foreach(var let in values){
        if(let is string){
            newString.Append(let);
        } else if (let is int){
            newNumber += (int)let;
        }
    }
    Console.WriteLine(newString + ": " + newNumber);

}
Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"

/* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
and if they’re string, lengths have to be more than 5. 
If they’re numbers, they have to be more than 18. */
void SwapTwo<T>(ref T obj1, ref T obj2)
{
    if (obj1.GetType() != obj2.GetType())
    {
        Console.WriteLine("Objects are not of the same type. Swap operation aborted.");
        return;
    }

    if (obj1 is string && obj2 is string && ((string)(object)obj1).Length > 5 && ((string)(object)obj2).Length > 5)
    {
        T temp = obj1;
        obj1 = obj2;
        obj2 = temp;
        Console.WriteLine("Strings swapped successfully.");
    }
    else if (obj1 is int && obj2 is int && ((int)(object)obj1) > 18 && ((int)(object)obj2) > 18)
    {
        T temp = obj1;
        obj1 = obj2;
        obj2 = temp;
        Console.WriteLine("Integers swapped successfully.");
    }
    else
    {
        Console.WriteLine("Swap conditions not met. Swap operation aborted.");
    }
}

/* Challenge 7. Write a function that does the guessing game. 
The function will think of a random integer number (lets say within 100) 
and ask the user to input a guess. 
It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
    Random random = new Random();
    int targetNumber = random.Next(1, 101);
    int guess;

    do
    {
        Console.Write("Guess a number between 1 and 100: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out guess))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            continue;
        }

        if (guess == targetNumber)
        {
            Console.WriteLine("Congratulations! You guessed the correct number.");
        }
        else if (guess < targetNumber)
        {
            Console.WriteLine("Too low. Try again.");
        }
        else
        {
            Console.WriteLine("Too high. Try again.");
        }
    } while (guess != targetNumber);
}

GuessingGame();

/* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
Console.WriteLine(subCart);

class Product
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }

    public OrderItem(Product product, int quantity) : base(Id, Price)
    {
        this.Quantity = quantity;
    }

    /* Override ToString() method so the item can be printed out conveniently with Id, Price, and Quantity */
    public override string ToString()
    {
        return $"Product Id: {Id}, Product Price: {Price}, Product Quantity: {Quantity} ";
    }
}

class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    /* Write indexer property to get nth item from _cart */
    public OrderItem this[int index] 
    {
        get 
        { 
            if(index>=0 && index <_cart.Count)
            {
                return _cart[index];
            }
            else 
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }

    /* Write indexer property to get items of a range from _cart */
    public List<OrderItem> this[int startIndex, int endIndex]
    {
        get
        {
            if(startIndex >= 0 && startIndex <= endIndex && endIndex < _cart.Count)
            {
                return _cart.GetRange(startIndex, endIndex - startIndex + 1);
            }
            else 
            {
                throw new IndexOutOfRangeException("Invalid range");
            }

        }
    }

 

     public void AddToCart(params OrderItem[] items)
    {
        /* this method should check if each item exists --> increase value / or else, add item to cart */
        foreach(var item in items)
        {
            var existsItem = _cart.Find(cartItem => item == cartItem);
            if(existsItem != null)
            {
                existsItem.Quantity += item.Quantity;
            }
            else
            {
                _cart.Add(item);
            }
        }
    }

  

    /* Write another method called GetCartInfo(), which out put 2 values: 
    total price, total products in cart*/
    public void GetCartInfo(out int totalPrice, out int totalQuantity)
    {
         totalPrice = 0;
        totalQuantity = 0;

        foreach (var item in _cart)
        {
            totalPrice += item.Price * item.Quantity;
            totalQuantity += item.Quantity;
        }

    }

    /* Override ToString() method so Console.WriteLine(cart) can print
    id, unit price, unit quantity of each item*/
    public override string ToString()
    {
        return string.Join(Environment.NewLine, _cart);
    }

}



