Taken from Challenge Email.

This challenge will be presented in 2 parts and will actually take place over a couple of weeks.
 
 
Premise
In your latest task, you’ve been asked to ensure that certain strings within your application are stored securely, but you still need to be able to access the original string. What you need is a way to both encrypt and decrypt abitrary. We all know that security is important, and usually it’s pretty hard. But does it really have to that hard? Surely it doesn’t take a genius to write a foolproof encryption algorithm.
 
Challenge
Create a pair of functions for encrypting and decrypting strings. Submissions will be 3 lines long in the form of:
// <descr>
string Encrypt(string s) => <body>
string Decrypt(string s) => <body>
 
Where <descr> is a short name or description of what your algorithm does, and <body> is a valid C# expression or block. Both <body> and <descr> must be no more than 127 characters in length, including the trailing semicolon or surrounding brackets if present, but excluding any leading or trailing whitespace, composed solely of characters within the range 32‒127. 
 
The following preconditions/postconditions must hold:
•         Input to the Encrypt function may be assumed to be non-null, non-empty strings, up to 127 characters in length, containing only ASCII characters (within the range 0‒127).
•         Input to the Decrypt function may be assumed outputs from the Encrypt function.
•         Output from the Encrypt function must be non-null, non-empty strings: Encrypt(s) != null && Encrypt(s).Length > 0
•         Output from the Encrypt function must contain only ASCII characters: Encrypt(s).All(c => c < 128)
•         Output from the Encrypt function must be nontrivial for strings greater than length 2: s.Length < 3 || Encrypt(s) != s
•         Output from the Encrypt function must be the same if it is called multiple times: Encrypt(s) == Encrypt(s)
•         Output from the Encrypt composed with the Decrypt function is the identity: Decrypt(Encrypt(s)) == s
 
Submissions must also include the a table listing encrypted <body> and <descr> strings, the length of the original strings, and the lengths of the encrypted strings. For the display purposes, non-printable characters art to be expressed as \xhh hexadecimal ASCII escape sequences, and literal backslash characters are to be expressed as \\ escape sequences (this that the encrypted strings are valid C# string literals). Although some encrypted strings may be greater than 127 characters in length, these 3 particular inputs are must not be greater than 127 characters in length.
 
An example submission might be:
// Caesar Cipher (+1)
string Encrypt(string s) => new string(s.Select(c=>(char)((c+1)%128)).ToArray());
string Decrypt(string s) => new string(s.Select(c=>(char)(c<1?127:c-1)).ToArray());
 
Sample	Encrypted	O	E
Descr	Dbftbs!Djqifs!),2*	18	18
Encrypt	ofx!tusjoh)t/Tfmfdu)d>?)dibs*))d,2*&239**/UpBssbz)**<	53	53
Decrypt	ofx!tusjoh)t/Tfmfdu)d>?)dibs*)d=2@238;d.2**/UpBssbz)**<
55	55

 
Only one submission will be accepted per person.
 
Additional Restrictions
•         The attached LINQPad script can be used to develop and test your submission, but the submission itself must be as described above. 
•         You may not read from or write to a file, network path, internet resource, or non-local variable.
•         You may not use any classes in the System.Security namespace. 
•         You may not use any classes in the FsCheck namespace (the library used to generate test data and validate postconditions). 
•         You may use types in the following assemblies (these are the assemblies imported by default within C# LINQPad queries, excluding the LINQPad.exe assembly):
o    mscorlib.dll
o    System.dll
o    Microsoft.CSharp.dll
o    System.Core.dll
o    System.Data.dll
o    System.Data.Entity.dll
o    System.Transactions.dll
o    System.Xml.dll
o    System.Xml.Linq.dll
o    System.Data.Linq.dll
o    System.Drawing.dll
o   System.Data.DataSetExtensions.dll
•         You may not use types from assemblies or NuGet packages not in the above list (this includes loading assemblies at runtime).
•         You may use types in the following namespaces without fully qualifying them (these are the namespaces imported by default within C# LINQPad queries, excluding the LINQPad namespace):
o    System
o    System.IO
o    System.Text
o    System.Text.RegularExpressions
o    System.Diagnostics
o    System.Threading
o    System.Reflection
o    System.Collections
o    System.Collections.Generic
o    System.Linq
o    System.Linq.Expressions
o    System.Data
o    System.Data.SqlClient
o    System.Data.Linq
o    System.Data.Linq.SqlClient
o    System.Transactions
o    System.Xml
o    System.Xml.Linq
o   System.Xml.XPath
•         You may use types in other namespaces not in the above list, but you must fully qualified names, e.g. System.Globalization.CultureInfo.
•         Others must be able to copy the code from your submission and reproduce the table of samples exactly as provided, using the attached LINQPad script as a base. If there are any restrictions on what must be done to reproduce the results (e.g. “must be run at midnight”), they must be disclosed.
 
Judging
 
No judgments shall be passed this week. That will have to wait for Part 2.

