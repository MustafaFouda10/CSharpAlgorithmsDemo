using System.Collections;
using System.Text;


#region Optimize an algorithm in C#

// ============ finding the best algorithm to return the max number of some given numbers ============

// ---------- the first way: ----------

static int findMaxValue(int a , int b , int c)
{
    if (a > b)
    {
        if (a > c || a == c)
        {
            return a;
        }
    }
        

    if (c > b)
    {
        return c;
    }

    return b;
}

Console.WriteLine("max value: " + findMaxValue(2,5,5));


// ---------- the second way (better way): ----------
static int getMaxValue(int a, int b, int c)
{
    int max = a;

    if (b > max)
        max = b;

    if (c > max)
        max = c;

    return max;
}

Console.WriteLine("max value: " + getMaxValue(11, 8, 9));

#endregion


// ===================================== 1.String Algorithms =====================================

#region Validate strings in C#

//----- we want to check a given string if its letters are all uppercase or not -----

static bool IsUpperCase(string s)
{
    return s.All(char.IsUpper); // true/false
}

static bool IsLowerCase(string s)
{
    return s.All(char.IsLower); // true/false
}

static bool IsLetter(string s)
{
    return s.All(char.IsLetter); // true/false
}

static bool IsDigit(string s)
{
    return s.All(char.IsDigit); // true/false
}

static bool IsPasswordComplex(string s)
{
    return s.Any(char.IsUpper) && s.Any(char.IsLower) && s.Any(char.IsSymbol) && s.Any(char.IsDigit);
}

Console.WriteLine("IsUpperCase: " + IsUpperCase("HELLO")); // true
Console.WriteLine("IsLowerCase: " + IsLowerCase("hello")); // true
Console.WriteLine("IsLetter: " + IsLetter("hello1234")); // false
Console.WriteLine("IsDigit: " + IsDigit("4561"));   // true
Console.WriteLine("IsPasswordComplex: " + IsPasswordComplex("Mustafa96$"));   // true

#endregion

#region Normalize Strings in C#

static string NormalizeString(string input)
{
    return input.ToLower().Trim().Replace(",", "");
}

Console.WriteLine("normalized string: " + NormalizeString("       Hello World, GoodMorning   ")); //hello world goodmorning

#endregion

#region Parse and search strings in C#

/*
    what assumptions can you make ?
    
        1. if you know nothing about the string, you have to check every single character in the string.
        2. if the string's characters are sorted, you can optimize your algorithm based on order.
*/


//---------------------------- Search ----------------------------

//1.Contains(): less complex but less efficient, because it is a case sensitive method

Console.WriteLine("Hello World".Contains("Hel")); //true
Console.WriteLine("Hello World".Contains("hel")); //false (case sensitive)

Console.WriteLine("Hello World".ToLower().Contains("hel")); //true (a solution for case sensitivity problem)



//---------------------------- Parse ----------------------------


static void ParseString(string s)
{
    // foreach: is better for (Read) algorithm only.
    foreach (var c in s)
    {
        Console.WriteLine(c); //Read
    }

    Console.WriteLine();

    // for: is better for (Read) and (Search) algorithms.
    for (int i = 0; i < s.Length; i++)
    {
        char c = s[i];
        Console.WriteLine(c); //Read
    }
}

ParseString("Hello");



static bool IsAtEvenIndex(string s , char c)
{

    if (string.IsNullOrEmpty(s))
    {
        return false;
    }

    //for (int i = 0; i < s.Length; i++)
    //{
    //    if (s[i] == c && i % 2 == 0)
    //        return true;        
    //}

    for (int i = 0; i < s.Length; i+=2) // better algorithm (fewer steps)
    {
        if (s[i] == c)
            return true;
    }

    return false;
}

Console.WriteLine(IsAtEvenIndex("Hello", 'o')); //true
Console.WriteLine(IsAtEvenIndex("Hello", 'e')); //false
Console.WriteLine(IsAtEvenIndex("Hello", 'H')); //true
Console.WriteLine(IsAtEvenIndex("Hello", 'h')); //false
Console.WriteLine(IsAtEvenIndex("Hello".ToLower(), 'h')); //true
Console.WriteLine(IsAtEvenIndex("Hello", 'T')); //false
Console.WriteLine(IsAtEvenIndex("", 'H')); //false
Console.WriteLine(IsAtEvenIndex(null, 'H')); //false


#endregion

#region Create algorithm-driven Strings in C#

static string ReverseString(string input)
{
    if (string.IsNullOrEmpty(input))
        return input;

    StringBuilder reversedString = new StringBuilder(input.Length);

    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversedString.Append(input[i]);
    }

    return reversedString.ToString();
}

Console.WriteLine(ReverseString("Hello"));
Console.WriteLine(ReverseString(null));



static string ReverseString2(string input)
{
    if (string.IsNullOrEmpty(input))
        return input;

    char[] arrayInput = input.ToCharArray();
    Array.Reverse(arrayInput);

    return new String(arrayInput);
}

Console.WriteLine(ReverseString2("Hello"));
Console.WriteLine(ReverseString(null));

#endregion

#region Challenge: Reverse each word of a sentence

// Given...
static string Reverse(string word)
{
    char[] characters = word.ToCharArray();
    Array.Reverse(characters);
    string reversedWord = new string(characters);
    return reversedWord;
}

//Code...
static string ReverseEachWord(string sentence)
{
    // Your code goes here.
    string[] words = sentence.Split(' ');
    string[] reversedWords = words.Select(Reverse).ToArray();
    string reversedSentence = String.Join(" ", reversedWords);
    return reversedSentence;
}

static string ReverseEachWord2(string sentence)
{
    // Your code goes here.
    StringBuilder result = new StringBuilder();

    string[] words = sentence.Split(' ');

    for (int i = 0; i < words.Length; i++)
    {
        result.Append(Reverse(words[i]) + ' ');
    }

    return result.ToString();
}


string sentence = "sally is a great worker";
Console.WriteLine(ReverseEachWord(sentence));
Console.WriteLine(ReverseEachWord2(sentence));

#endregion


// ===================================== 2.Array Algorithms =====================================

#region [Linear Search / Sequential Search] Arrays in C# | time complexity: O(N) | Array.Find(), Array.FindAll()

static bool LinearSearch(int[] ints, int num)
{
    foreach (var item in ints)
    {
        if (item == num)
        {
            return true;
        }
    }

    return false;
}

int[] numbers = { 1, 2, 3, 4, 5, 6 };
Console.WriteLine(LinearSearch(numbers,3)); //true
Console.WriteLine(LinearSearch(numbers,8)); //false


//--------- Note: There are already built in functions used for linear searching in Array like Array.Find(), Array.FindAll(), Array.ForEach()... ---------
int item = Array.Find(numbers, element => element == 3); //returns the value if found in the array
Console.WriteLine(item); //3

int item2 = Array.Find(numbers, element => element == 8); // if value not found, it will return 0
Console.WriteLine(item2); //0

int[] items = Array.FindAll(numbers, element => element > 4);
Array.ForEach(items, Console.WriteLine);


#endregion

#region Binary Search Arrays in C# | time complexity: O(log(N)) | Array.BinarySearch()

static bool BinarySearch(int[] ints, int num)
{
    int min = 0;
    int max = ints.Length - 1;

    while (min <= max)
    {
        int mid = (min + max) / 2;

        if (num == ints[mid])
            return true;

        else if (num < ints[mid])
            max = mid - 1;

        else
            min = mid + 1;
    }

    return false;
}


int[] inputs = { 1, 12, 23, 44, 75, 96, 119 };
Console.WriteLine(BinarySearch(inputs, 75)); //true
Console.WriteLine(BinarySearch(inputs, 84)); //false



//--------- Note: There are already built in functions used for binary searching in Array like Array.BinarySearch()... ---------
int res = Array.BinarySearch(inputs, 23); //returns the index of the value if found in the array
Console.WriteLine(res); // index = 2

int res2 = Array.BinarySearch(inputs, 69); //returns negative index, if the value is not found in the array
Console.WriteLine(res2); // -5


#endregion

#region Aggregate and Filter Arrays in C#

static int[] FindEvenNumbers(int[] arr1 , int[] arr2)
{
    ArrayList result = new ArrayList();

    foreach (var item in arr1)
    {
        if (item%2==0)
        {
            result.Add(item);
        }
    }

    foreach (var item in arr2)
    {
        if (item % 2 == 0)
        {
            result.Add(item);
        }
    }

    return (int[])result.ToArray(typeof(int));
}

int[] nums1 = { 31, 42, 55, 61, -26 };
int[] nums2 = { 87, 91, -44, 22, 34 };

int[] evenNumsArray = FindEvenNumbers(nums1, nums2);
Array.ForEach(evenNumsArray, Console.WriteLine); //  {42, -26, -44, 22, 34}


#endregion

#region Reverse an array in C#

static int[] ReverseArray(int[] ints)
{
    int[] reverse = new int[ints.Length];

    for (int i = ints.Length -1; i >= 0; i--)
    {
        var val = ints[i];
        reverse[ints.Length -i -1] = val;
    }

    return reverse;
}

// other way to reverse is to swap values...
static void ReverseInPlace(int[] ints) 
{

    for (int i = 0; i < ints.Length/2; i++)
    {
        int temp = ints[i];
        ints[i] = ints[ints.Length - i - 1];
        ints[ints.Length - i - 1] = temp;
    }

}


Console.WriteLine();

int[] arr = { 87, 91, -44, 22, 34 };
int[] reversedArray = ReverseArray(arr);
Array.ForEach(reversedArray, Console.WriteLine); //  {34, 22, -44, 91, 87}

Console.WriteLine();
ReverseInPlace(arr);
Array.ForEach(arr, Console.WriteLine); //  {34, 22, -44, 91, 87}
#endregion

#region Challenge: Rotate an array

static int[] RotateArray(int[] numbers)
{
        int temp = numbers[numbers.Length - 1];
        numbers[numbers.Length - 1] = numbers[0];

    for (int i = 0; i < numbers.Length; i++)
    {
        if (i == numbers.Length-2)
        {
            numbers[i] = temp;
        }
        else if (i != numbers.Length-1)
        {
            numbers[i] = numbers[i + 1];
        }

    }

    return numbers;
}

// Another Solution...
static int[] RotateArray2(int[] numbers)
{
    int[] rotatedArray = new int[numbers.Length];

    for (int i = 1; i < numbers.Length; i++)
    {
        rotatedArray[i-1] = numbers[i];
    }

    rotatedArray[rotatedArray.Length - 1] = numbers[0];

    return rotatedArray;
}

int[] inputArray = { 2, 3, 4, 5, 6, 1 };
Console.WriteLine();
Array.ForEach(RotateArray(inputArray), Console.WriteLine); // { 3, 4, 5, 6, 1, 2 }

Console.WriteLine();
Array.ForEach(RotateArray2(inputArray), Console.WriteLine); // { 3, 4, 5, 6, 1, 2 }
#endregion


// ===================================== 3.LinkedList Algorithms =====================================

#region What is a LinkedList

/*
 * 
 * Elements in a LinkedList are linked by pointers (ex: 3 -> 5 -> 8 -> null).
 * Each Element is called a Node, which contains a piece of data and a reference to the next element.
 * (3 [head of the list] -> 5 -> 13 -> 94 -> 8 [tail of the list] -> null)
 * LinkedList size is not fixed as Array
 * we can (Insert) and (Remove) easily from LinkedList.
 * 
 */
#endregion

#region Common LinkedList operations

LinkedList<string> listy = new LinkedList<string>();

// Insert...
listy.AddFirst("Egypt");
listy.AddFirst("Brazil");
listy.AddLast("England");
listy.AddLast("Italy");

listy.AddAfter(listy.First, "France");
listy.AddBefore(listy.Last, "Romania");

Console.WriteLine();
Console.WriteLine("LinkedList: ");

foreach (var l in listy)
{
    Console.Write($"{l} -> ");
}


// Search...
Console.WriteLine();
Console.WriteLine(listy.Contains("Egypt"));


// Remove...
listy.RemoveFirst();
listy.RemoveLast();
listy.Remove("Romania");

foreach (var l in listy)
{
    Console.Write($"{l} -> ");
}


// Read...
Console.WriteLine();
Console.WriteLine(listy.ElementAt(2));

#endregion

#region LinkedList algorithms

//// create empty LinkedList...
//CustomLinkedList linkedList = new CustomLinkedList();

//// create some elements to assign them to the LinkedList...
//Node firstNode = new Node(3);
//Node secondNode = new Node(4);
//Node thirdNode = new Node(5);
//Node fourthNode = new Node(6);

//// assign elements to the LinkedList...
//linkedList.head = firstNode;
//firstNode.next = secondNode;
//secondNode.next = thirdNode;
//thirdNode.next = fourthNode;

//displayContents(linkedList);

//Console.WriteLine();
//deleteBackHalf(linkedList);
//displayContents(linkedList);

//void deleteBackHalf(CustomLinkedList customlinkedList)
//{
//    if (customlinkedList.head == null || customlinkedList.head.next == null)
//    {
//        customlinkedList.head = null;
//    }
//    Node slow = customlinkedList.head;
//    Node fast = customlinkedList.head;
//    Node prev = null;

//    while (fast != null && fast.next != null)
//    {
//        prev = slow;
//        slow = slow.next;
//        fast = fast.next.next;
//    }

//    prev.next = null;
//}


//void displayContents(CustomLinkedList customlinkedList)
//{
//    Node current = customlinkedList.head;

//    while (current != null)
//    {
//        Console.Write(current.data + " -> ");
//        current = current.next;
//    }
//}

//class CustomLinkedList
//{
//    // head of the list...
//    public Node head;

//    public class Node
//    {
//        //element in the list...
//        public int data;

//        //pointer to the next element in the list...
//        public Node next;

//        //ctor...
//        public Node(int d)
//        {
//            data = d;
//        }
//    }
//}

#endregion

#region Challenge: Sum Contents of a LinkedList

//ListNode head = new ListNode(7);
//head.next = new ListNode(5);
//head.next.next = new ListNode(3);
//head.next.next.next = new ListNode(4);
//head.next.next.next.next = new ListNode(1);
//int result = Sum(head);
//Console.WriteLine(result);//20

//// Return the sum of the contents in the LinkedList...
//static int Sum(ListNode head)
//{
//    int sum = 0;
//    ListNode current = head;

//    while (current != null)
//    {
//        sum += current.val;
//        current = current.next;
//    }

//    return sum;
//}

////Given...
//public class ListNode
//{
//    public int val;
//    public ListNode next;

//    public ListNode(int val)
//    {
//        this.val = val;
//        this.next = null;
//    }

//    public override string ToString()
//    {
//        return val.ToString();
//    }
//}


#endregion


// ===================================== 4.Queue & Stack Algorithms =====================================

/* Queue */

#region What is a Queue

/*
 * 
 * A Queue contains the elements in the order they were added
 * elements are added at the end and removed from the front of a Queue, First In First Out (FIFO)
 * Enqueue(): adds an item to the back
 * Dequeue(): removes an item from the front
 * Peek():    accesses the item in the front of the Queue
 * 
 */
#endregion

#region Standard Queue operations in C#

Queue<int> ints = new Queue<int>();

ints.Enqueue(13);
ints.Enqueue(41);
ints.Enqueue(65);
ints.Enqueue(74);

Console.WriteLine();
Console.WriteLine(ints.Dequeue()); // it will remove the first item (13)
Console.WriteLine(ints.Peek()); // it will display the first item which is now (41)

Console.WriteLine();

//  TryDequeue(out T result): Removes the object at the beginning of the Queue, and copies it to the result parameter...
int current;
while (ints.TryDequeue(out current))
{
    Console.WriteLine(current);
}
#endregion

#region Queue algorithms: Generate Binary Numbers

// if bnCount = 3 --> we want to print (1, 10, 11)...
// if bnCount = 5 --> we want to print (1, 10, 11, 100, 101)...
// if bnCount = 7 --> we want to print (1, 10, 11, 100, 101, 110, 111)...
static void PrintBinaryNumbers(int bnCount)
{
    if (bnCount <= 0)
    {
        return;
    }

    Queue<int> queue = new Queue<int>();
    queue.Enqueue(1);

    for (int i = 0; i < bnCount; i++)
    {
        int current = queue.Dequeue();
        Console.WriteLine(current);

        queue.Enqueue(current * 10);
        queue.Enqueue(current * 10 + 1);
    }

    Console.WriteLine();

}

Console.WriteLine();
PrintBinaryNumbers(0);
PrintBinaryNumbers(3);
PrintBinaryNumbers(5);
PrintBinaryNumbers(7);
PrintBinaryNumbers(9);


#endregion



/* Stack */

#region What is a Stack

/*
 * 
 * A Stack contains the elements in the order they were added
 * elements are added and removed from the top of a Stack, Last In First Out (LIFO)
 * Push(): adds an item to the top
 * Pop(): removes an item from the top
 * 
 */
#endregion

#region Basic Stack Operations in C#

Stack<int> nums = new Stack<int>();

nums.Push(13);
nums.Push(41);
nums.Push(65);
nums.Push(74);

Console.WriteLine();
Console.WriteLine(nums.Pop()); // it will remove the last item (74)
Console.WriteLine(nums.Peek()); // it will display the item on top which is now (65)
#endregion

#region Stack algorithms: Theorizing an algorithm
/*
 * 1. if we have for example an array like {15, 8, 4, 10}, we will Push the first element {15} into a stack variable
 * 2. then we will iterate on the remaining elements of the array {8, 4, 10} one by one. 
 * 3. if the next element in the array {8} greater than the element in the stack {15}, we will Pop the element in the stack and print it pointing to the element of the array.
 * 4. if the next element in the array {8} less than the element in the stack {15}, we will Push the element of the array into the stack.
 * 5. we will always have the elements of the stack each one is less than the element below it.
 * 6. we find 8 < 15, so we will Push 8 into the stack.
 * 7. 4 < 8, so we will Push 4 too into the stack.
 * 8. 10 > 4, so we will Pop 4 from the stack and print (4 -> 10).
 * 9. 10 > 8, so we will Pop 8 from the stack and print (8 -> 10).
 * 10. 10 < 15, so we will Push 10 into the stack.
 * 11. there are no remaining elements in the array to compare them with the stack elements {15, 10}.
 * 12. we will print (10 -> -1) and (15 -> -1).
 */
#endregion

#region Stack algorithms: Implementing next greater element

Console.WriteLine();

static void printNextGreaterElement(int[] inputArray)
{
    if (inputArray.Length <=0)
    {
        Console.WriteLine();
        return;
    }

    Stack<int> stack = new Stack<int>();
    stack.Push(inputArray[0]);

    for (int i = 1; i < inputArray.Length; i++)
    {
        int next = inputArray[i];
        
        if (stack.Count > 0)
        {
            int popped = stack.Pop();

            while (next > popped)
            {
                Console.WriteLine(popped + " -> " + next);
                if (stack.Count == 0)
                {
                    break;
                }
                popped = stack.Pop();
            }

            if (next < popped)
            {
                stack.Push(popped);
            }

        }

        stack.Push(next);
    }

    while (stack.Count > 0)
    {
        Console.WriteLine(stack.Pop() + " -> " + -1);
    }
}

int[] arr1 = { 3, 15, 6, 20 };
int[] arr2 = { 6, 7};
int[] arr3 = { 13, 5, 6, 9 };
int[] arr4 = { };

printNextGreaterElement(arr1);
printNextGreaterElement(arr2);
printNextGreaterElement(arr3);
printNextGreaterElement(arr4);
#endregion

#region Stack algorithms: Matching Parentheses

static bool HasMatchingParentheses(string s)
{
    Stack<char> chars = new Stack<char>();

    for (int i = 0; i < s.Length; i++)
    {
        char current = s[i];

        if (current == '(')
        {
            chars.Push(current);
            continue;
        }
        if (current == ')')
        {
            if(chars.Count > 0)
               chars.Pop();
            else
               return false;
        }
    }

    return chars.Count == 0;
}


static bool HasMatchingParentheses2(string s)
{
    int matchingTracker = 0;

    for (int i = 0; i < s.Length; i++)
    {
        char current = s[i];

        if (current == '(')
        {
            matchingTracker++;
            continue;
        }
        if (current == ')')
        {
            if (matchingTracker > 0)
                matchingTracker--;
            else
                return false;
        }
    }

    return matchingTracker == 0;
}


Console.WriteLine();
Console.WriteLine("Matching Parentheses: ");
Console.WriteLine(HasMatchingParentheses("hello()")); // true
Console.WriteLine(HasMatchingParentheses("((hello)())")); // true
Console.WriteLine(HasMatchingParentheses("(hello()")); // false

Console.WriteLine();
Console.WriteLine(HasMatchingParentheses2("hello()")); // true
Console.WriteLine(HasMatchingParentheses2("((hello)())")); // true
Console.WriteLine(HasMatchingParentheses2("(hello()")); // false
#endregion

#region Challenge: Evaluate reverse polish notation (RPN)
/*
 reverse polish notation or postfix notation, is a way of writing mathematical expressions without using parentheses or worrying about operator precedence.
    instead, operators come from their operands. for example, instead of writing "3 + 4", in RPN, you'd write "3 4 +".
*/

/*
 in this challenge, we are given an RPN string and we want to calculate the result from this string. (ex: "3 4 + 6 * 2 /" ----> 21)
 */


//Given...
static bool IsNumber(string token)
{
    try
    {
        double.Parse(token);
        return true;
    }
    catch (FormatException)
    {
        return false;
    }
}

//Given...
static bool IsOperator(string token)
{
    return "+-*/".Contains(token);
}

//Given...
static double PerformOperation(string @operator, double operand1, double operand2)
{
    switch (@operator)
    {
        case "+":
            return operand1 + operand2;
        case "-":
            return operand1 - operand2;
        case "*":
            return operand1 * operand2;
        case "/":
            if (operand2 == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return operand1 / operand2;
        default:
            throw new ArgumentException("Invalid operator: " + @operator);
    }
}

// Return the result of the Reverse Polish notation expression
static double EvaluateRPN(string expression)
{
    // Your code goes here.

    Stack<double> stack = new Stack<double>();
    string[] tokens = expression.Split(" ");

    foreach (var item in tokens)
    {
        if (IsNumber(item))
        {
            stack.Push(double.Parse(item));
        }
        else if (IsOperator(item))
        {
            double operand1 = stack.Pop();
            double operand2 = stack.Pop();
            double result = PerformOperation(item, operand1, operand2);

            stack.Push(result);
        }
    }

    return stack.Pop();
}


string expression = "3 4 + 2 * 42 /";
double result = EvaluateRPN(expression);
Console.WriteLine(result); //   42/14 = 3


#endregion


// ===================================== 5.Hash-Based Structure Algorithms (HashSet & Dictionary) =====================================

#region Hash-Based Structures in C#

/*
 * Hash-Based Structures: are great when working with Collections, Sets, and data formatted as Key-Value Pairs.
 * 
 * HashSet: is an 'unordered collection' of 'unique items' (Set), it doesn't accept duplicates.
 * Dictionary: useful for key-value pairs.
 * 
 * Dictionary:
 *      - Generic
 *      - Type safety
 *      - invalid key results to --> error
 *      - Thread safe only for public static members
 *      
 * HashTable:
 *      - Non Generic
 *      - no Type safety
 *      - invalid key results to --> null
 *      - Thread safe
*/
#endregion

#region Dictionary [keys are unique] & HashSet [values are unique] operations in C#

///* ===== HashSet [values are unique] ===== */

//HashSet<string> hashSet = new HashSet<string>();
//hashSet.Add("JH24");
//hashSet.Add("NB63");
//hashSet.Add("LO17");
//hashSet.Add("JH24"); // the HashSet will neglect the value because it's already found before.

//hashSet.Contains("LO17"); //true

//foreach (var s in hashSet)
//{
//    Console.WriteLine($"hashSet: {s}");
//}

///* ===== Dictionary [keys are unique] ===== */

//Employee employee1 = new Employee(1, "Robert", "IT");
//Employee employee2 = new Employee(2, "Alexander", "Network");
//Employee employee3 = new Employee(3, "John", "Logical Access");

//// we want to store these employees in a dictionary with their id as a unique key...
//Dictionary<int, Employee> employeeById = new Dictionary<int, Employee>();
//employeeById.Add(employee1.Id, employee1);
//employeeById.Add(employee2.Id, employee2);
//employeeById.Add(employee3.Id, employee3);
////employeeById.Add(employee3.Id, employee3); // error: the key is repeated.

//foreach (var emp in employeeById)
//{
//    Console.WriteLine($"key: {emp.Key} | value: {emp.Value.Id}, {emp.Value.Name}, {emp.Value.Department}");
//}

//Console.WriteLine();

////TryGetValue(): check if the given key is already exists and have a given value...
//Employee e;
//employeeById.TryGetValue(3, out e); // true

//if (employeeById.TryGetValue(3, out e))
//{
//    Console.WriteLine($"{e.Name}, {e.Department}"); //John, Logical Access
//}

//class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string Department { get; set; }

//    public Employee(int id, string name, string department)
//    {
//        Id = id;
//        Name = name;
//        Department = department;
//    }
//}


#endregion

#region Leverage (تأثير) the HashSet type in C# algorithms

// we want to check if there are matching values between to arrays

static int[] MatchArrays(int[] arr1, int[] arr2)
{
    ArrayList result = new ArrayList();
    HashSet<int> hashSet1 = new HashSet<int>(arr1);

    for (int i = 0; i < arr2.Length; i++)
    {
        if (!hashSet1.Contains(arr2[i]))
        {
            hashSet1.Add(arr2[1]);
        }
        else
        {
            result.Add(arr2[i]);
        }

    }

    return (int[])result.ToArray(typeof(int));

}


int[] sets1 = { 3, 2, 8, 4, 5 };
int[] sets2 = { 5, 7, 3, 0, 2 };

Array.ForEach(MatchArrays(sets1, sets2), Console.WriteLine); // {5, 3, 2}

#endregion

#region using the Dictionary type in C# algorithm

// we want to track how many times does element found in the array...

static void displayFreqOfEachElement(int[] arr)
{
    Dictionary<int, int> freqDictionary = new Dictionary<int, int>();
    for (int i = 0; i < arr.Length; i++)
    {
        if (freqDictionary.ContainsKey(arr[i]))
        {
            freqDictionary[arr[i]]++;
        }
        else
        {
            freqDictionary[arr[i]] = 1;
        }

    }

    foreach (var item in freqDictionary)
    {
        Console.WriteLine($"key: {item.Key} --> value: {item.Value}");
    }
}


int[] vals = { 3, 0, 2, 4, 7, 3, 4, 5, 7, 6, 7};

displayFreqOfEachElement(vals);

#endregion

#region Challenge: Detect a cyclic LinkedList

//// Return true or false depending on if there's a cycle in the Linked List...

//static bool HasCycle(ListNode head)
//{
//    // Your code goes here.
//    HashSet<ListNode> nodes = new HashSet<ListNode>();
//    ListNode current = head;

//    while (current != null)
//    {
//        if (nodes.Contains(current))
//        {
//            return true;
//        }
//        else
//        {
//            nodes.Add(current);
//        }

//        current = current.Next;
//    }

//    return false;
//}

//// This is how your code will be called...
//ListNode head = new ListNode(1);
//head.Next = new ListNode(2);
//head.Next.Next = new ListNode(3);
//head.Next.Next.Next = head;
//bool learnerResult = HasCycle(head);
//Console.WriteLine(learnerResult);

//public class ListNode
//{
//    public int Val;
//    public ListNode Next;

//    public ListNode(int val)
//    {
//        this.Val = val;
//        this.Next = null;
//    }
//}


#endregion



// ===================================== 6.Tree Algorithms =====================================

#region What is a Tree [A collection of nodes connected by links]

/*
 * Tree: is a collection of nodes where each node might be linked to one, two, or even more nodes.
 * the tree structure is useful for working with nonlinear data.
 * 
 * Tree Structure:
 *                              2 (The Root Node)
 *                             / \
 *                            3   4 (Child Nodes)
 *                           / \   \
 *                          8   3   1
 *                          
 * Every child node has a parent node except the root node.
 * 
 * LinkedList: may be considered as a special type of Tree. (2 -> 5 -> 3 -> null).
 * Binary Tree: each node has no more than two child nodes.
 * Binary Search Tree: a Binary Tree that adds the constraint of order.
 *          - items to the left must be less than the parent.
 *          - items to the right must be greater than the parent.
 *                              6 
 *                             / \
 *                            4   8 
 *                           / \   \
 *                          0   5   19
 *                          
 * Time complexity for Searching in a Tree structure:
 *          - best case: O(Log(N))
 *          - worst case: O(N)
 */
#endregion

#region Create a Binary Search Tree in C#

///*
//    we will have the same idea as LinkedList. 
//        but instead of having a pointer to the next node, 
//            we will have two pointers, one for the left child node and the other for the right child node.
// */


//TreeNode rootNode = new TreeNode();
//rootNode.Data = 4;
//BinarySearchTree.Insert(rootNode, 2);
//BinarySearchTree.Insert(rootNode, 5);
//BinarySearchTree.Insert(rootNode, 6);
//BinarySearchTree.Insert(rootNode, 8);
//BinarySearchTree.Insert(rootNode, 9);


//class TreeNode
//{
//    public int Data { get; set; }
//    public TreeNode LeftNode { get; set; }
//    public TreeNode RightNode { get; set; }
//}

//class BinarySearchTree
//{
//    public static TreeNode Insert(TreeNode root, int value)
//    {
//        if (root == null)
//        {
//            root = new TreeNode();
//            root.Data = value;
//            return root;
//        } else
//        {
//            if (value < root.Data)
//            {
//                // insert to the left
//                root.LeftNode = Insert(root.LeftNode, value);

//            } else if(value > root.Data)
//            {
//                // insert to the right
//                root.RightNode = Insert(root.RightNode, value);

//            }
//        }

//        return root;
//    }
//}


#endregion

#region What are Tree Traversals

/*
    1. with a binary tree, data is not stored with any order, but each node can have at most two direct child nodes.
    2. So, in order to find an element in a binary tree, you must traverse the tree.

                              6 
                             / \
                            7   8 
                           / \   \
                          9   10   
    
    InOrder   (explores data sequentially)   :  Recursively visit left subtree --> then visit the root --> and Recursively visit right subtree  [9, 7, 10, 6, 8].

    PreOrder  (explores roots before leaves) :  visit the root --> then Recursively visit left subtree --> and Recursively visit right subtree  [6, 7, 9, 10, 8].

    PostOrder (explores leaves before roots) :  Recursively visit left subtree --> then Recursively visit right subtree --> and visit the root  [9, 10, 7, 8, 6].
*/
#endregion

#region using Recursion (التكرار) to implement tree traversals (اجتياز) in C#

///*
//                               4 
//                             /   \
//                            1     3 
//                           / \   /
//                          8   9 6
//*/
//BinaryTreeNode rootNode = new BinaryTreeNode();
//rootNode.Data = 4;

//BinaryTreeNode nodeOne = new BinaryTreeNode();
//nodeOne.Data = 1;

//BinaryTreeNode nodeThree = new BinaryTreeNode();
//nodeThree.Data = 3;

//BinaryTreeNode nodeEight = new BinaryTreeNode();
//nodeEight.Data = 8;

//BinaryTreeNode nodeNine = new BinaryTreeNode();
//nodeNine.Data = 9;

//BinaryTreeNode nodeSix = new BinaryTreeNode();
//nodeSix.Data = 6;


//rootNode.LeftNode = nodeOne;
//rootNode.RightNode = nodeThree;

//nodeOne.LeftNode = nodeEight;
//nodeOne.RightNode = nodeNine;

//nodeThree.LeftNode = nodeSix;

//Console.WriteLine();
//Console.WriteLine("Binary Tree PreOrder Traversal: ");
//BinaryTree.PreOrderTraversal(rootNode); // 4 1 8 9 3 6

//Console.WriteLine();
//Console.WriteLine("Binary Tree InOrder Traversal: ");
//BinaryTree.InOrderTraversal(rootNode); // 8 1 9 4 6 3

//Console.WriteLine();
//Console.WriteLine("Binary Tree PostOrder Traversal: ");
//BinaryTree.PostOrderTraversal(rootNode); // 8 9 1 6 3 4



//class BinaryTreeNode
//{
//    public int Data { get; set; }
//    public BinaryTreeNode LeftNode { get; set; }
//    public BinaryTreeNode RightNode { get; set; }
//}

//class BinaryTree
//{ 
//    //preOrder
//    public static void PreOrderTraversal(BinaryTreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }


//        Console.Write(root.Data + " ");
//        PreOrderTraversal(root.LeftNode);
//        PreOrderTraversal(root.RightNode);
//    }

//    //inOrder...
//    public static void InOrderTraversal(BinaryTreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }


//        InOrderTraversal(root.LeftNode);
//        Console.Write(root.Data + " ");
//        InOrderTraversal(root.RightNode);
//    }

//    //postOrder...
//    public static void PostOrderTraversal(BinaryTreeNode root)
//    {
//        if (root == null)
//        {
//            return;
//        }


//        PostOrderTraversal(root.LeftNode);
//        PostOrderTraversal(root.RightNode);
//        Console.Write(root.Data + " ");
//    }

//}


#endregion

#region Challenge: find height of binary tree

//code call...
TreeNode root = new TreeNode(10);
root.Left = new TreeNode(5);
root.Right = new TreeNode(15);
root.Left.Left = new TreeNode(3);
root.Left.Right = new TreeNode(7);
root.Left.Left.Left = new TreeNode(4);

int learnerResult = FindHeight(root);
Console.WriteLine($"Binary Tree Height: {learnerResult}"); //4


// Return the maximum depth of the binary tree
static int FindHeight(TreeNode root)
{
    // write code here
    if (root == null)
    {
        return 0;
    }
    else
    {
        int leftNode = FindHeight(root.Left);
        int rightNode = FindHeight(root.Right);
        return 1 + Math.Max(leftNode, rightNode);
    }
}


public class TreeNode
{
    public int Val { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int val)
    {
        Val = val;
    }
}

#endregion