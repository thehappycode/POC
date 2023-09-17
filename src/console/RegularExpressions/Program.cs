using System.Diagnostics;
using System.Text.RegularExpressions;

// Stopwatch sw;
// string[] addresses = {
//     "AAAAAAAAAAA@contoso.com",
//     "AAAAAAAAAAaaaaaaaaaab@contoso.com"
// };

// var pattern = @"^[0-9A-Z]([-.\w]*[0-9A-Z])*$";
// string input;

// foreach (var address in addresses)
// {
//     string mailBox = address.Substring(0, address.IndexOf("@"));
//     int index = 0;
//     for (int ctr = mailBox.Length - 1; ctr >= 0; ctr--)
//     {
//         index++;

//         input = mailBox.Substring(ctr, index);
//         sw = Stopwatch.StartNew();
//         Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
//         sw.Stop();

//         if (match.Success)
//             Console.WriteLine("{0,2}. Matched '{1,25}' in {2}",
//                               index, match.Value, sw.Elapsed);
//         else
//             Console.WriteLine("{0,2}. Failed  '{1,25}' in {2}",
//                               index, input, sw.Elapsed);
//     }
// }
// Console.WriteLine();

const string VIETNAMESES_ALPHABET = "aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ";
const string NUMBERS = "0123456789";
const string NON_ALPHANUMERIC = @"@#%&!*:-_\/?.,";
const string PATTERN = VIETNAMESES_ALPHABET + NUMBERS + NON_ALPHANUMERIC;


const string sentence = "Cộng hòa \t 11 xã . hội - chũ + nghĩa ~ việt nam? \n 09 21 ✔ 🐱‍🚀 😂 ' safjlka a;mmj ld jfkal wow..lsei112 4832090)(^^*(*())) \\ \" { ơ } ()[]; Nguyễn Thanh Tâm | / ! @ # $ % ^ & * > < , `";
var words = sentence.Split(" ");

// \u00C0-\u1EF9 các ký tự tiếng Việt https://vietunicode.sourceforge.net/charset/
var pattern = @"^[0-9a-zA-Z\u00C0-\u1EF9\s\t\n`~!@#$%^&*)(\-+_=\][}{\\|;:'"",.></?]*$";
// With isMatch
var regex = new Regex(pattern);
foreach (var word in words)
{
    if (!regex.IsMatch(word))
    {
        Console.WriteLine("Not Match Found '{0}'", word);
    }
}

// With Matchs
foreach(Match match in Regex.Matches(sentence, pattern, RegexOptions.IgnoreCase)){
     Console.WriteLine("Matchs Found '{0}' at position {1}", 
                              match.Value, match.Index);
}