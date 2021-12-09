//01 Introduction to C# and Data Types
//Understanding Data Types
/**
//1.
Console.WriteLine("\nSigned Byte\nSize: " + sizeof(sbyte) + " Min: " + sbyte.MinValue + " Max: " + sbyte.MaxValue);
Console.WriteLine("\nUnsigned Byte\nSize: " + sizeof(byte) + " Min: " + byte.MinValue + " Max: " + byte.MaxValue);
Console.WriteLine("\nSigned Short\nSize: " + sizeof(short) + " Min: " + short.MinValue + " Max: " + short.MaxValue);
Console.WriteLine("\nUnsigned Short\nSize: " + sizeof(ushort) + " Min: " + ushort.MinValue + " Max: " + ushort.MaxValue);
Console.WriteLine("\nSigned Integer\nSize: " + sizeof(int) + " Min: " + int.MinValue + " Max: " + int.MaxValue);
Console.WriteLine("\nUnsigned Integer\nSize: " + sizeof(uint) + " Min: " + uint.MinValue + " Max: " + uint.MaxValue);
Console.WriteLine("\nSigned Long\nSize: " + sizeof(long) + " Min: " + long.MinValue + " Max: " + long.MaxValue);
Console.WriteLine("\nUnsigned Long\nSize: " + sizeof(ulong) + " Min: " + ulong.MinValue + " Max: " + ulong.MaxValue);
Console.WriteLine("\nFloat\nSize: " + sizeof(float) + " Min: " + float.MinValue + " Max: " + float.MaxValue);
Console.WriteLine("\nDouble\nSize: " + sizeof(double) + " Min: " + double.MinValue + " Max: " + double.MaxValue);
Console.WriteLine("\nDecimal\nSize: " + sizeof(decimal) + " Min: " + decimal.MinValue + " Max: " + decimal.MaxValue);

//2.
Console.WriteLine("Enter Number Of Centuries to be converted");
int centuries = Convert.ToInt32(Console.ReadLine());
decimal years = centuries;
years = years * 100;
decimal days = years * 365.25m;
decimal hours = days * 24m;
decimal minutes = hours * 60m;
decimal seconds = minutes * 60m;
decimal milliseconds = seconds * 1000m;
decimal microseconds = milliseconds * 1000m;
decimal nanoseconds = microseconds * 1000m;

String label = "";
if (centuries == 1) label = label + "century";
else label = label + "centuries";
Console.WriteLine("{0} {1} = {2} years = {3} days = {4} hours = {5} minutes = {6} seconds = {7} milliseconds = {8} microseconds = {9} nanoseconds", centuries, label, years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds);

//Controlling Flow and Converting Types
1. A DivideByZeroException is returned 
2. Infinity is returned
3. It loops back to its minimum value from a positive overflow or its maximum from a negative overflow
4. x=y++ increments y after x is set to y's value and x=++y increments y before x is set to y's value
5. break terminates loop, continue skips the remaining statements in a loop's body and goes to the next iteration, and return terminates the loop and it's containing method
6. The initializer, condition and iterator. None are required/
7. = is an assignment operator and == is an equality operator. The latter is used for comparisons.
8. yes
9. the default case
10. IEnumerable
*/