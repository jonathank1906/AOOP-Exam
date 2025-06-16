var words = new List<string>(); // New string-typed list

var printWords = () => { foreach (string s in words) Console.WriteLine(s); };

words.Add ("melon");
words.Add ("avocado");
words.AddRange (["banana", "plum"]);
printWords();


words.Insert (0, "lemon"); // Insert at start
words.InsertRange (0, ["peach", "nashi"]); // Insert at start
printWords();

words.Remove ("melon");
words.RemoveAt (3); // Remove the 4th element
printWords();

// Remove all strings starting in 'n':
words.RemoveAll (s => s.StartsWith ("n"));
printWords();

Console.WriteLine (words [0]); // first word
Console.WriteLine (words [words.Count - 1]); // last word
foreach (string s in words) Console.WriteLine(s); // all words

List<string> upperCaseWords = words.ConvertAll (s => s.ToUpper());
foreach (string s in upperCaseWords) Console.WriteLine(s);

List<int> lengths = words.ConvertAll (s => s.Length);
foreach (int s in lengths) Console.WriteLine (s);