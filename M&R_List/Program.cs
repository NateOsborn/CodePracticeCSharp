/* 
    Examples of Lists taken from Miller & Ranum (2011, pp12 - pp14)
    Converted to C# for practice excercise.
*/

// Single int repeated in a list
IEnumerable<int> list = Enumerable.Repeat(0, 6);

List<int> myList = list.ToList();

// Prints list contents on one line
Console.WriteLine(string.Join(" ", myList));

/* 
    Enumberable lists cannot be cleared, 
    therefore we cast it to with ToList().
*/
myList.Clear();

// Number sequence added to list. 
for (int i = 1; i < 5; i++)
{
    myList.Add(i);
}

/* 
    Ofcourse you could use loops for all these examples,
    however I am using Enumberable lists to try an recreate 
    the Python repeatition operator.
*/
var enumerable = Enumerable.Repeat(myList, 3);
List<List<int>> A = enumerable.ToList();

/*
    Enumerable lists cannot be used with SelectMany,
    therefore we cast to a list again.
    Note we use a new enumerable list as they cannot be cleared.
*/
Console.WriteLine(string.Join(" ", A.SelectMany(x => x)));

// Change an element of list and you must recast 
myList[2] = 45;
A.Clear();

// Another new enumerable list
var enum2 = Enumerable.Repeat(myList, 3);
A = enum2.ToList();

Console.WriteLine(string.Join(" ", A.SelectMany(x => x)));

// Declare a heterogenous list
List<object> mixList = new List<object> {1024, 3, true, 6.5};

Console.WriteLine(string.Join(" ", mixList));

// List<T> does not have an Append() so use Add() instead
mixList.Add(false);

Console.WriteLine(string.Join(" ", mixList));

mixList.Insert(2, 4.5);

Console.WriteLine(string.Join(" ", mixList));

// List<T> does not have a pop() so I made the following methods
object ListPop(List<object> input)
{
    object output = input[input.Count - 1];
    mixList.RemoveAt(input.Count -1);
    return output;
}

object popped = ListPop(mixList);

Console.WriteLine(popped);

object ListPopAt(List<object> input, int index)
{
    object output = input[index];
    mixList.RemoveAt(index);
    return output;
}

popped = ListPopAt(mixList, 1);

Console.WriteLine(popped);

Console.WriteLine(string.Join(" ", mixList));

popped = ListPopAt(mixList, 2);

Console.WriteLine(popped);

Console.WriteLine(string.Join(" ", mixList));

/* 
    Sorting a heterogenous list causes issues as some items
    do not implement the IComparable interface. Therefore,
    I tried using a custom comparer:
    mixList.Sort((x, y) => x.ToString().CompareTo(y.ToString()));
    But as the integers where now strings it did not work.
    As the list now only contains int and double a custom comparer
    could be one work around. But it is not pretty...
*/

mixList.Sort((x, y) =>
{
    int typeCompare = x.GetType().Name.CompareTo(y.GetType().Name);
    if (typeCompare != 0)
    {
        return typeCompare;
    }
    else if (x is int)
    {
        return ((int)x).CompareTo((int)y);
    }
    else if (x is double)
    {
        return ((double)x).CompareTo((double)y);
    }
    else
    {
        throw new ArgumentException("Unsupported type");
    }
});

Console.WriteLine(string.Join(" ", mixList));

// Reverse the list works well.
mixList.Reverse();

Console.WriteLine(string.Join(" ", mixList));

// Alternative to Python's count(n) 
int indexOf = mixList.IndexOf(6.5);

Console.WriteLine(indexOf);

// Find item index

indexOf = mixList.IndexOf(4.5);

Console.WriteLine(indexOf);

// Remove list item
mixList.Remove(6.5);

Console.WriteLine(string.Join(" ", mixList));

// Remove item by index
mixList.RemoveAt(0);

Console.WriteLine(string.Join(" ", mixList));