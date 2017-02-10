Taken from Challenge Email.

Premise
Oops! Last week you had to write a custom encryption algorithm, but due to an unfortunate source control issue, and you lost the original source code. All you've got is a couple of encrypted samples to try to reconstruct it. Good thing you didn't use any of those “strong” encryption algorithms or you'd be out of luck!

Challenge
The outputs from many of last week's submissions will be listed the next email on this thread. For each submission, the first person to reply-all on this thread with a solution will claim a point. For each person that submitted an algorithm, if at least one of their submitted algorithms remains unsolved by the end of the challenge, they will claim an bonus point (with a maximum of 1 bonus point per person).

Other Conditions
•	To claim a point, reply to this thread using the following format: 
o	The body must begin with the word "Solved" in bold letters on one line
o	The following lines will contain the plain text of the description, the entire Encryption function, and the entire Decrypt function, as it though it would appear in original submission
o	Credit is only given if the entire WCC Group is included on the email (this is to notify all WCC members that not eligible claiming points) 
•	Points will be deducted for 'solving' your own submission (don’t try to deny someone else a point by spoiling their solution to your submission)
•	If you think you've partially solved a submission but are now stuck, you are welcome to ask for help or to offer help to others, including posting partial solutions. However, no points will not be awarded for partial solutions
An example solution might would be:
Solved
// Caesar Cipher (+1)
string Encrypt(string s) => new string(s.Select(c=>(char)((c+1)%128)).ToArray());
string Decrypt(string s) => new string(s.Select(c=>(char)(c<1?127:c-1)).ToArray());

Judging
This challenge ends on 6:00pm, Thursday, February 16. At that time points all points from solutions and bonus points from unsolved submissions will be tallied. The person with the highest total point score will be declared the winner and will receive a prize on Friday, February 19. For the purpose of breaking ties, points will be ignored and the total length the algorithms solved by each person shall be used instead.

It's quite possible that over the course of the week, some of you will see a solution that helps you work out a problem with your own algorithm(s). I would like to encourage you to keep improving your code, so I will continue to accept submissions until 6:00pm, Tuesday, February 14. Such submissions will be eligible for the unsolved point bonus. This also applies to non-trivial improvements (e.g. I would reject an submission that is identical to the Caesar Cypher but changes the +1 to +23) to previous submissions, including previously solved submissions.

Miscellaneous Tips
•	Many of the submissions bear a strong similarity to some classical ciphers. You probably want to familiarize yourself with them.
•	The ciphertext strings presented here are specifically designed so you can copy and paste them into LINQPad for analysis. It's probably a lot easier to find patterns programmatically than trying to work them out by hand. 
o	An easy and very useful trick to look at the numeric values of characters is str.Select(c => new { c, i = (int)c })
o	To see the hex, octal, or binary versions of characters use str.Select(c => new { c, hex = Convert.ToString(c, 16), oct = Convert.ToString(c, 8), bin = Convert.ToString(c, 2) })
o	To compare two strings character by character, try strA.Zip(strB, (charA, charB) => …)
•	Remember that the plaintext of these samples was not permitted to contain control characters and could not have leading or trailing whitespace, i.e. they conform to the pattern /[!-~]([ -~]*[!-~])?/.
•	Most algorithms seem to fall one of 3 categories; knowing which category an algorithm falls into will help immensely when it comes to decrypting it:
o	Mappers transform one character at a time according to some rule.
o	Movers change the position of characters according to some rule.
o	Mirrors provide a different representation of a character or groups of characters according to some rule.
•	The plain text and ciphertext description is provided for your analysis, once you think you've spotted the pattern, focus on decrypting the Decrypt function first.
o	If the Decrypt function doesn't reference the Encrypt function, you can just run the decrypted Decrypt function on the ciphertext of the Encrypt body to get the decrypted Encrypt body.
o	Even if the Decrypt function does reference the Encrypt function, at this point you have a much stronger basis for decrypting the Encrypt body.
